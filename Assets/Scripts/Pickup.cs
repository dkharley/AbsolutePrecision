using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public static GameObject player;
	public float speed;
	public float range;
	public float hoverMax;
	public float hoverMin;
	public float hoverForce;
	public Vector3 direction;
	public AudioClip nom;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(Vector3.Distance(transform.position, player.transform.position) < range)
		{
			//Debug.Log("In range");

			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
		}

	}

	void FixedUpdate()
	{	
		if (transform.position.y >= hoverMax) 
		{
			rigidbody.AddForce(Vector3.down * hoverForce);
		} else if (transform.position.y <= hoverMin) {
			rigidbody.AddForce(Vector3.up * hoverForce);
		}
	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") 
        {
	
			AudioSource.PlayClipAtPoint(nom , transform.position);
            ScoreManager.multi++;
			TimeManager.multi++;
            Destroy(gameObject);
        }
        
    }
}
