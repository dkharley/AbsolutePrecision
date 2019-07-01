using UnityEngine;
using System.Collections;

public class RetryScript : MonoBehaviour {

	public static string PreviousLevel = "";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnClick()
	{
		Application.LoadLevel (PreviousLevel);
	}

}
