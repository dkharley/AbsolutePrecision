using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    public GameObject pickup;
    public int pickupCount;
	private Vector3 offSet;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
       
	}

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Projectile") 
        {
			TimeManager.AddScore(100.0f);
            Destroy(gameObject);
            Destroy(other.gameObject);

			for(int i = 0; i < 3; i++)
			{
				offSet = new Vector3(((float)Random.Range (-5, 5))/ 10.0f, 0, ((float)Random.Range(-5, 5))/ 10.0f);
				GameObject pickup1 = (GameObject)Instantiate(pickup, (transform.position + offSet), transform.rotation);
			}
        }
    }
}
