using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameoverscript : MonoBehaviour {

	public Canvas gameOverMenu;
	public Text showScore;
	string name=menuscript.userName;

	void Start () {
		showScore.text = "Your Score : " + Move.score.ToString();
		name = menuscript.userName;
		if (name == "") name = "unknown";
		sentToServer();
	}
		

	public void sentToServer()
	{	
		//http://saleh-khazaei.com/pacman/index.php?name=saleh&score=100
	//	string url = "http://saleh-khazaei.com/pacman/index.php?name="+ name + "&score=" + Move.score.ToString();
		//
		string url = "http://192.168.137.140:8000/generation/get?name="+ name +"&score=" + Move.score.ToString();

//		WWWForm form = new WWWForm();
//		form.AddField("name",name);
//		form.AddField("Score", Move.score.ToString());
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www){
		yield return www;

		// check for errors
		if (www.error == null)
		{
			print("WWW Ok!: " + www.text);
		}
		else
		{
			print("WWW Error: " + www.error);
		}
	}


	public void leaderboardpress(){
		Application.LoadLevel (3);
	}

	public void restartpress(){
		Application.LoadLevel (1);
	}

	public void homepress(){
		Application.LoadLevel (0);
	} 

}
