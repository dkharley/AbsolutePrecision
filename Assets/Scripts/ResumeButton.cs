using UnityEngine;
using System.Collections;

public class ResumeButton : MonoBehaviour {

	public GameObject pauseContainer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick() 
	{
		PauseMenu.pauseEnabled = false;
		TweenPosition.Begin(pauseContainer, 0.1f, pauseContainer.transform.localPosition + new Vector3 (0, 500, 0));
	}
}
