using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float lifeTime; 
	public TrailRenderer trail;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
		if (!PauseMenu.pauseEnabled) 
		{
			lifeTime -= Time.deltaTime;
			if (lifeTime <= 0) 
			{
				Destroy(gameObject);
			}
			if (lifeTime <= 195) 
			{
				print ("turn on");
				trail.enabled = true;
			}
		}
	}

    void FixedUpdate() 
    {
        
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "floor") 
        {
            Destroy(gameObject);
        }
    }
}
