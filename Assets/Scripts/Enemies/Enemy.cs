using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject pickup;
	private Vector3 offSet;
	public AudioClip breaking;

	// Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Projectile")
        {
			AudioSource.PlayClipAtPoint(breaking , transform.position);
            Destroy(gameObject);
            Destroy(other.gameObject);
			ScoreManager.enemiesKilled++;
			ScoreManager.AddScore(20.0f);
            for(int i = 0; i < 3; i++)
            {
				offSet = new Vector3(((float)Random.Range (-5, 5))/ 10.0f, 0, ((float)Random.Range(-5, 5))/ 10.0f);
                GameObject pickup1 = (GameObject)Instantiate(pickup, (transform.position + offSet), transform.rotation);
            }
        }
    }
}
