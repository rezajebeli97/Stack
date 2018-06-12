using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Move : MonoBehaviour {

	public static int score;
	bool space=false;
	float extraScale, neededScale, extraCenter, neededCenter;
	public Text showScore;

	GameObject neededCube,extraCube=null;
	List<GameObject> extraCubeArr = new List<GameObject>();
	List<GameObject> cubeArr = new List<GameObject>();


/////////////////////////////////////////////////////////////////////////////////////////////

	void Start () {
		cubeArr.Add(this.gameObject);
		score = 0;
		showScore.text = "Score : " + 0.ToString();
	}

	 
//////////////////////////////////////////////////////////////////////////////////////////////


	void Update () {
		


		GameObject lastCube = (GameObject)cubeArr [cubeArr.Count - 1];
		if (transform.name != "Cube")
			return;
		lastCube.transform.position = new Vector3 (Mathf.PingPong (Time.time * 5, 8)+2, lastCube.transform.position.y, lastCube.transform.position.z);

		Material newMat = Resources.Load ("box", typeof(Material)) as Material;
		lastCube.GetComponent<MeshRenderer> ().material = newMat;



		if (Input.GetMouseButtonDown(0)) {
			
			if (cubeArr.Count >= 2) {
				extraScale = Mathf.Abs (cubeArr [cubeArr.Count - 1].transform.position.x - cubeArr [cubeArr.Count - 2].transform.position.x);
				neededScale = cubeArr [cubeArr.Count - 1].transform.localScale.x - extraScale;

				if (neededScale <= 0) {
					Application.LoadLevel (2);
					return;
				}
				else {
					score++;
					showScore.text = "Score : " + score.ToString();
				}

		

				if (cubeArr [cubeArr.Count - 1].transform.position.x > cubeArr [cubeArr.Count - 2].transform.position.x) {
					extraCenter = cubeArr [cubeArr.Count - 2].transform.position.x + ((cubeArr [cubeArr.Count - 2].transform.localScale.x) / 2) + (extraScale / 2);
					neededCenter = cubeArr [cubeArr.Count - 2].transform.position.x + ((cubeArr [cubeArr.Count - 2].transform.localScale.x) / 2) - (neededScale / 2);
				} else {
					extraCenter = cubeArr [cubeArr.Count - 2].transform.position.x - ((cubeArr [cubeArr.Count - 2].transform.localScale.x) / 2) - (extraScale / 2);
					neededCenter = cubeArr [cubeArr.Count - 2].transform.position.x - ((cubeArr [cubeArr.Count - 2].transform.localScale.x) / 2) + (neededScale / 2);
				}

				extraCube = GameObject.CreatePrimitive (PrimitiveType.Cube);						//mokaabe ezafi
				Rigidbody extraRCube = extraCube.AddComponent<Rigidbody> ();
				extraRCube.transform.position = new Vector3 (extraCenter, cubeArr [cubeArr.Count - 1].transform.position.y,	cubeArr [cubeArr.Count - 1].transform.position.z);

				extraRCube.transform.localScale = new Vector3 (extraScale, 0.5f, 2);
				extraCubeArr.Add (extraCube);



				neededCube = GameObject.CreatePrimitive (PrimitiveType.Cube);						//mokaabe moondegar
				//			Rigidbody neededRCube = neededCube.AddComponent<Rigidbody>();
				neededCube.transform.position = new Vector3 (neededCenter, cubeArr [cubeArr.Count - 1].transform.position.y,	cubeArr [cubeArr.Count - 1].transform.position.z);

				neededCube.transform.localScale = new Vector3 (neededScale, 0.5f, 2);
					
					
				Destroy (cubeArr [cubeArr.Count - 1]);
				cubeArr.Remove (cubeArr [cubeArr.Count - 1]);
				cubeArr.Add (neededCube);
				extraCube.GetComponent<MeshRenderer> ().material = newMat;
				extraCube.GetComponent<MeshRenderer> ().material.color = Color.blue;
				neededCube.GetComponent<MeshRenderer> ().material = newMat;

			}

				
			GameObject oneseclastCube = GameObject.CreatePrimitive (PrimitiveType.Cube);



			oneseclastCube.transform.position = new Vector3 (cubeArr [cubeArr.Count - 1].transform.position.x, cubeArr [cubeArr.Count - 1].transform.position.y + 0.5f,	cubeArr [cubeArr.Count - 1].transform.position.z);

			oneseclastCube.transform.localScale = new Vector3 (cubeArr [cubeArr.Count - 1].transform.localScale.x, 0.5f, 2);	

			cubeArr.Add (oneseclastCube);



			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y + 0.5f, Camera.main.transform.position.z);

	
		}


		if (extraCubeArr.Count > 2) {
			Destroy (extraCubeArr [0]);
			extraCubeArr.Remove (extraCubeArr [0]);

		}


	}

}
