using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public GameObject multiUI;
	public GameObject scoreUI;
	public static int multi;
	public static int score;
	public static float time;

	public Texture healthTexture;
	public Texture healthBackground;
	public Texture healthTransparentBack;
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

	}

	public static void AddScore(float points)
	{
		score += (int)(points * multi);
	}

	void OnDestroy()
	{
		EndGameToMenuButton.finalScore = score;
	}

	void OnGUI()
	{
		//HealthTransparentBack
		GUI.color = new Color (255, 255, 255);
		GUI.DrawTexture (new Rect (235, 550, (healthTexture.width), healthTexture.height - 1), healthTransparentBack);

		//Health Bar
		float scalar = CharacterController.health / CharacterController.maxHealth;
		GUI.color = Color.Lerp (Color.red, Color.green, CharacterController.health / CharacterController.maxHealth);
		GUI.DrawTexture (new Rect (475 - (healthTexture.width * scalar) / 2, 550, (healthTexture.width * scalar), healthTexture.height - 1), healthTexture);

		//GUI.DrawTexture (new Rect (Screen.width / 2.0f - (healthTexture.width * scalar) / 2.0f, Screen.height - healthTexture.height, (healthTexture.width * scalar), healthTexture.height - 1), healthTexture);

	
		//Health Bar Background
		//GUI.DrawTexture (new Rect (Screen.width / 2.0f - (healthBackground.width * 21) / 2.0f, Screen.height - healthBackground.height, (healthBackground.width * 21), healthBackground.height - 1), healthBackground);
		GUI.color = new Color (255, 255, 255);
		GUI.DrawTexture (new Rect (225, 540, healthBackground.width, healthBackground.height - 1), healthBackground);
	}

}
