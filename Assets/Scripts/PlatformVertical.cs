using UnityEngine;
using System.Collections;

public class PlatformVertical : MonoBehaviour {

	public Vector3 direction;
	public int pushSpeed;
	public int maxHeight;
	public int minHeight;

	// Use this for initialization
	void Start () {
		direction = new Vector3 (0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= maxHeight) 
		{
			direction = new Vector3 (0, -1, 0);
		} else if (transform.position.y <= minHeight) {
			direction = new Vector3 (0, 1, 0);
		}
	}

	void FixedUpdate()
	{	
		transform.position += direction * pushSpeed * Time.deltaTime;
	}
}
