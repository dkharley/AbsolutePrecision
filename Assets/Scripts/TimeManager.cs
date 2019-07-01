using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

	public GameObject multiUI;
	public GameObject scoreUI;
	public GameObject timeUI;
	public static int multi;
	public static int score;
	public static float time;


	public static int enemiesKilled;

    


	// Use this for initialization
	void Start () 
    {
        multi = 1;
		time = 120;
		score = 0;
		enemiesKilled = 1;

		RetryScript.PreviousLevel = Application.loadedLevelName;
		//float tempX = health.transform.position.x;
		//health.transform.position = new Vector3 (Screen.width/2, 0, 0);

	}
	
	// Update is called once per frame
	void Update () 
    {
		if (!PauseMenu.pauseEnabled)
		{
			time -= Time.deltaTime;
			int tempTime = (int)time;

			if (CharacterController.health <= 0) 
			{
				Application.LoadLevel("EndGameMenu");
			}


	        string multiplyerText = multi.ToString();
			UILabel multiText = multiUI.GetComponent<UILabel> ();
			multiText.text = "X " + multiplyerText;

			string scoreText = score.ToString ();
			UILabel scoreUIText = scoreUI.GetComponent<UILabel> ();
			scoreUIText.text = "Score : " + scoreText;

			string timeText = time.ToString("###.000");
			UILabel tText = timeUI.GetComponent<UILabel> ();
			tText.text = timeText;
		}
	}

	public static void AddScore(float points)
	{
		score += (int)(points * multi);
	}

	void OnDestroy()
	{
		score = score + (int)(time * 1000);
		EndGameToMenuButton.finalScore = score;
	}


	
}
