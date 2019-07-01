using UnityEngine;
using System.Collections;

public class GoToModesButton : MonoBehaviour {

	public GameObject menuContainer;
	public GameObject buttonContainer;

	// Use this for initialization
	void Start () {
		ScoreManager.score = 0;
		TimeManager.score = 0;
		TimeManager.time = 0;
		EndGameToMenuButton.finalScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!Screen.showCursor)
		{
			Screen.showCursor = true;
		}
	}

	void OnClick()
	{
		TweenPosition.Begin (menuContainer, 1.0f, menuContainer.transform.localPosition - new Vector3 (1000, 0, 0));
		TweenPosition.Begin(buttonContainer, 1.0f, buttonContainer.transform.localPosition - new Vector3 (1000, 0, 0));
	}
}
