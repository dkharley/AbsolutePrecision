using UnityEngine;
using System.Collections;

class MeleeEnemy : MonoBehaviour
{
    public float explodeRange;
    public CharacterController player;
	public GameObject playerPosition;
    public GameObject explosion;
    NavMeshAgent nav;
    float detonationCounter;
	public AudioClip splosion;

    void Start()
    {
       // nav = GetComponent<NavMeshAgent>();
		playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        //nav.SetDestination(playerPosition.transform.position);
		if ( !PauseMenu.pauseEnabled) 
		{

			transform.position = Vector3.MoveTowards (transform.position, playerPosition.transform.position, .08f);

	        if(Vector3.Distance(gameObject.transform.position, playerPosition.transform.position) < explodeRange)
	        {

	            GameObject explosion1 = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
	            Detonator detonation = explosion1.GetComponent<Detonator>();
				AudioSource.PlayClipAtPoint(splosion , transform.position);
				Destroy(gameObject);
	            detonationCounter += Time.deltaTime;

				if(Vector3.Distance(gameObject.transform.position, playerPosition.transform.position) < explodeRange)
				{
					CharacterController.health -= 10;
				}
	        }
		}
    }

}
