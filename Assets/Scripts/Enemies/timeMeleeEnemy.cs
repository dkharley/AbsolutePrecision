using UnityEngine;
using System.Collections;

class timeMeleeEnemy : MonoBehaviour
{
    public float explodeRange;
    public CharacterController player;
	public GameObject playerPosition;
    public GameObject explosion;
	private bool suicide;
    NavMeshAgent nav;
    float detonationCounter;

    void Start()
    {
       // nav = GetComponent<NavMeshAgent>();
		playerPosition = GameObject.FindGameObjectWithTag("Player");
		suicide = false;
    }

    void FixedUpdate()
    {
        //nav.SetDestination(playerPosition.transform.position);

		transform.position = Vector3.MoveTowards (transform.position, playerPosition.transform.position, .08f);

        if(Vector3.Distance(gameObject.transform.position, playerPosition.transform.position) < explodeRange)
        {
            GameObject explosion1 = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
            Detonator detonation = explosion1.GetComponent<Detonator>();
			suicide = true;
            Destroy(gameObject);
            detonationCounter += Time.deltaTime;
			if(Vector3.Distance(gameObject.transform.position, playerPosition.transform.position) < explodeRange)
			{
				CharacterController.health -= 10;
			}
        }
    }

    void OnDestroy()
    {
		if (!suicide)
		{
			TimeManager.AddScore(20.0f);
		}
        
    }
}
