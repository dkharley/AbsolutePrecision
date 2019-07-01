using UnityEngine;
using System.Collections;

public class GoToHordeMode : MonoBehaviour {
	
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
		Application.LoadLevel ("HordeMode");
	}
}
