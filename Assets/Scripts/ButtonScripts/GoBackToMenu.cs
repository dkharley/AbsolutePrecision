using UnityEngine;
using System.Collections;

public class GoBackToMenu : MonoBehaviour {

	public GameObject menuContainer;
	public GameObject buttonContainer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		TweenPosition.Begin (menuContainer, 1.0f, menuContainer.transform.localPosition + new Vector3 (1000, 0, 0));
		TweenPosition.Begin(buttonContainer, 1.0f, buttonContainer.transform.localPosition + new Vector3 (1000, 0, 0));
	}
}
