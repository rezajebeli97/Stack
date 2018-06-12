using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;

public class leaderboardscript : MonoBehaviour {

	public Text scores;
	public Button home;
	public Button back;
	string url = "http://192.168.137.140:8000/generation/show";

	// Use this for initialization
	void Start () {
		
		home.GetComponent<Button> ();
		back.GetComponent<Button>();
		sendToClient();

	}

	public void sendToClient(){

		WWW www = new WWW(url);

		StartCoroutine(WaitForRequest(www));

	}

	IEnumerator WaitForRequest(WWW www)
	{

		yield return www;

		// check for errors
		if (www.error == null)
		{
			showScore(www.text);
		}
		else
		{
			print("WWW Error: " + www.error);
		}

	}

	public void showScore(string jsonString)
	{

		JsonData jsonvale = JsonMapper.ToObject(jsonString);
		int j = 0;
		for (int i = 0; i < jsonvale.Count; i ++ ){
			JsonData data = jsonvale[i];
			ICollection keys = ((IDictionary)data).Keys;

			foreach( string key in keys ){
				scores.text +=  (j + 1).ToString()+ ".  " + key.ToString() + data [key].ToString() +"\n";

					j=j+1;
				print (j);
			}
		}     
	}

	public void pressHome(){
		Application.LoadLevel(0);
	}

	public void pressBack(){
		Application.LoadLevel(2);
	}
}
