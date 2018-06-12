using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuscript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	public InputField myField;
	public static string userName;
	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		myField = myField.GetComponent<InputField> ();
		quitMenu.enabled = false;
	}

	public void ExitPress(){
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress(){
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void StartLevel(){
		userName= myField.text;
		Application.LoadLevel (1);
	 }

	public void ExitGame(){
		Application.Quit ();
	
	}
}
