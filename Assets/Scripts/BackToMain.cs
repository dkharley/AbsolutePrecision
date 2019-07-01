using UnityEngine;
using System.Collections;

public class BackToMain : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick()
	{
		Application.LoadLevel ("mainMenu");
		PauseMenu.pauseEnabled = false;
		Screen.showCursor = true;
	}
}
