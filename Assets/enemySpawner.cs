using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public GameObject spawnPoint1, spawnPoint2, spawnPoint3, spawnPoint4;
	float myTime;

	public GameObject enemyPrefab;
	public float spawnRate;
	public bool increased;
	public int enemyKillChange;


	// Use this for initialization
	void Start () 
	{
		increased = false;
		spawnRate = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!PauseMenu.pauseEnabled) 
		{

			myTime += Time.deltaTime;


			if (ScoreManager.enemiesKilled % 10 == 0 && !increased) {
					if (spawnRate > 0) {
						increased = true;
						spawnRate -= .10f;
						}			
				} 
			else if (ScoreManager.enemiesKilled % 10 == 1 && increased)
			{
				increased = false;		
			}
			if (myTime >= spawnRate) 
			{
				myTime = 0;

				int spawnLocation = Random.Range (0, 4);
				if(spawnLocation == 0)
				{
					GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint1.transform.position, transform.rotation);
				}
				if(spawnLocation == 1)
				{
					GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint2.transform.position, transform.rotation);
				}
				if(spawnLocation == 2)
				{
					GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint3.transform.position, transform.rotation);
				}
				if(spawnLocation == 3)
				{
					GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint4.transform.position, transform.rotation);
				}
			}
		}
	}
}
