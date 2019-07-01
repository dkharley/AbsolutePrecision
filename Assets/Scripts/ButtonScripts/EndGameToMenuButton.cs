using UnityEngine;
using System.Collections;

public class EndGameToMenuButton : MonoBehaviour {

	public GameObject finalScoreUI;
	public GameObject timeLeftUI;
	public static int finalScore;
	// Use this for initialization
	void Start () {

		string timeLeftText = "Time Left : " + TimeManager.time.ToString ("###.000") + " seconds";
		UILabel fTimeLeftText = timeLeftUI.GetComponent<UILabel> ();
		fTimeLeftText.text = timeLeftText;

		if (TimeManager.time == 0)
		{
			Destroy(timeLeftUI);
		}

		if (Screen.lockCursor == true)
		{
			Screen.lockCursor = false;
			Screen.showCursor = true;
		}
		Debug.Log ("Score : " + finalScore);
		string finalScoreText = "Final Score : \n\n " + finalScore.ToString ();
		UILabel fScoreText = finalScoreUI.GetComponent<UILabel> ();
		fScoreText.text = finalScoreText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		Application.LoadLevel ("mainMenu");
	}
}
