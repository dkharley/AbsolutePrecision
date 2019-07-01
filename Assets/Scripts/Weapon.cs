using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public Vector3 direction;
    public float power;
	public float minPower;
    public float maxPower;
    public GameObject projectile;
    public Camera camera;
    private float timeHeld;
	private bool mouseDown = false;
	private bool rightMouseDown = false;
	private bool maxScaling = false;
	private bool maxPowerbool = false;
	public float timeDown;
	public float timeMax;
	private Vector3 originalScale = new Vector3 (0.1f, 0.1f, 0.1f);
	private Vector3 minScale = new Vector3 (0.05f, 0.05f, 0.05f);

	public GameObject AimPower;
    public GameObject powerBar;
	public AudioClip laser;
	// Use this for initialization
	void Start () 
    {
        Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (Input.GetMouseButtonDown(0) && !PauseMenu.pauseEnabled) 
        {
			mouseDown = true;

			//timeDown = Time.time;
			//timeHeld = timeDown;
			//timeMax = timeDown + 3;
        }
		/*if (Input.GetMouseButtonDown (1)) 
		{
			rightMouseDown = true;
		}*/

        if (Input.GetMouseButtonUp(0) && !PauseMenu.pauseEnabled) 
        {
            //power = Time.time - timeHeld;
            //power = power * 16 + 20;
			AudioSource.PlayClipAtPoint(laser , transform.position);
            if (power > maxPower) 
            {
                power = maxPower;
            }

            

            //Debug.Log("Power " + power);


			print (camera.transform.rotation.eulerAngles);
            GameObject bullet = (GameObject)Instantiate(projectile, camera.transform.position+camera.transform.rotation*Vector3.forward*0.5f, camera.transform.rotation);
            bullet.rigidbody.AddForce(camera.transform.forward * power , ForceMode.Impulse);

			AimPower.transform.localScale = originalScale;
			AimPower.transform.localEulerAngles = new Vector3(0,0,0);
			power = minPower;
			mouseDown = false;
			maxScaling = false;
			maxPowerbool = false;
        }

		/*if (Input.GetMouseButtonUp(1))
		{
			AudioSource.PlayClipAtPoint(laser, transform.position);
			if (power > maxPower) 
			{
				power = maxPower;
			}

			for(int i=0; i<15; i++)
			{
				float value = 0.4f;
				Vector3 alteredForward = (Vector3.forward+new Vector3(Random.Range(-value, value), Random.Range(-value, value), 1));
				Vector3 randAngle = camera.transform.rotation*alteredForward;
				print (camera.transform.rotation.eulerAngles);
				GameObject bullet = (GameObject)Instantiate(projectile, camera.transform.position+randAngle*0.5f, camera.transform.rotation);
				bullet.rigidbody.AddForce(camera.transform.forward * power , ForceMode.Impulse);
			}
			AimPower.transform.localScale = originalScale;
			power = minPower;
			rightMouseDown = false;
			maxScaling = false;
			maxPowerbool = false;
			AimPower.transform.rotation = Quaternion.Euler(0,0,0);
		}*/

		if (mouseDown && maxScaling == false && !PauseMenu.pauseEnabled) 
		{
			Vector3 size = new Vector3();

			size.x = AimPower.transform.localScale.x;
			size.y = AimPower.transform.localScale.y;
			size.z = AimPower.transform.localScale.z;

			size.x -= 0.05f / 30;
			size.y -= 0.05f / 30;
			size.z -= 0.05f / 30;

			Quaternion rotation = new Quaternion(AimPower.transform.rotation.x, AimPower.transform.rotation.y,AimPower.transform.rotation.z,AimPower.transform.rotation.w);
			
			//rotation.eulerAngles.x = AimPower.transform.rotation.x;
			//rotation.y = AimPower.transform.rotation.y;
			rotation *= Quaternion.Euler(0,0,-6);
			AimPower.transform.rotation = Quaternion.Slerp(transform.rotation, rotation,10);// * Time.deltaTime);      
			//AimPower.transform.rotation = rotation;

			//rotation.eulerAngles.z = 20;

			power += 2;
			if (power >= maxPower)
			{
				power = maxPower;
				maxPowerbool = true;
			}

			//if (size.x <= 0.05f && size.y <= 0.05f && size.z <= 0.05f)
			if (maxPowerbool)
			{
				size = minScale;
				maxScaling = true;
			}

			AimPower.transform.localScale = size;
			AimPower.transform.rotation = rotation;
		}
	}

    
}
