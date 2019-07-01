using UnityEngine;
using System.Collections;

public class TargetSpawn : MonoBehaviour {

    public Vector3 spawnPoint;
    public int maxTargets;
    private int currentTargets;
    public GameObject target;
    public float timePassed;



	// Use this for initialization
	void Start () 
    {
        currentTargets = 0;
        StartCoroutine(spawnTarget());
	}

    void FixedUpdate() 
    {
        
    }

	// Update is called once per frame
	void Update () 
    {
        
	}

    public IEnumerator spawnTarget() 
    {
        while(true){    
            spawnPoint.x = Random.Range(-20, 20);
            spawnPoint.y = Random.Range(5, 8);
            spawnPoint.z = Random.Range(-20, 20);
            GameObject target1 = (GameObject)Instantiate(target, spawnPoint, transform.rotation);
            yield return new WaitForSeconds(10f);
        }
    }
}
