using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	static public bool pauseEnabled = false;	

	public GameObject pauseContainer;
	
	void  Start (){
		pauseEnabled = false;
		Time.timeScale = 1;
		AudioListener.volume = 1;
		Screen.showCursor = false;
	}
	
	void  Update (){

		if (Input.GetButtonDown ("Escape")) {
				if (pauseEnabled == true) {
					pauseEnabled = false;
					TweenPosition.Begin(pauseContainer, 0.1f, pauseContainer.transform.localPosition + new Vector3 (0, 500, 0));
				} else if (pauseEnabled == false) {
					pauseEnabled = true;
					TweenPosition.Begin(pauseContainer, 0.1f, pauseContainer.transform.localPosition + new Vector3 (0, -500, 0));
				}
		}

		if (pauseEnabled) {
			Screen.showCursor = true;
		}
		else
		{
			Screen.showCursor = false;
		}
	}
}
