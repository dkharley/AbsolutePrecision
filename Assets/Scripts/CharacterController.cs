using UnityEngine;
using System.Collections;

/************************************************
 ***************Absolute Precision***************
 * The dankest 179 game ever!
 * 
 * The base character controller script, handles 
 * movement and rotation so far.
 ***********************************************/

public class CharacterController : MonoBehaviour {

    //Movement Variables
    public float speed;
    public Vector3 maxVelocity;

    //Jumping
    public float jumpForce;
    private bool grounded;

    //Rotation
    private Vector3 camera_Y; //Pivoting left to right
    private Vector3 camera_X; //Pivoting up and down
    public float smoothingX;
    public float smoothingY;
    public float rotationSpeed;
    public float lookAngle;
    
    //Dead
    public bool dead;

    public Camera camera;

	public static float maxHealth;
	public static float health;


    // Use this for initialization
	void Start () 
    {
		maxHealth = 100;
		health = 100;
		Pickup.player = gameObject;
        camera_Y = camera.transform.localEulerAngles;
        grounded = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (!PauseMenu.pauseEnabled) 
		{
	        if (Screen.lockCursor == false)
	        {
	            if (Input.GetMouseButtonDown(0))
	            {
	                Screen.lockCursor = true;
	            }
	        }

	        //Rotation
	        Vector3 deltaY = new Vector3( 0, Input.GetAxis("Mouse X"), 0); //Rotation on Y axis
	        camera_Y = Vector3.Lerp(camera_Y, camera_Y + deltaY * rotationSpeed, Time.deltaTime * smoothingX);
	        transform.localEulerAngles = camera_Y;
	     
	        Vector3 deltaX = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
	        camera_X = Vector3.Lerp(camera_X, camera_X + deltaX * rotationSpeed, Time.deltaTime * smoothingY);

	        //Limiting the angle of looking up and down
	        if (camera_X.x > -90 && camera_X.x < 90)
	        {
	            camera.transform.localEulerAngles = camera_X;
	        }
	        else 
	        {
	            if (camera_X.x < -90) 
	            {
	                camera_X.x = -90;
	            }
	            if (camera_X.x > 90)
	            {
	                camera_X.x = 90;
	            }
	        }
	        

	        //Sprinting
	        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && grounded)
	        {
	            //maxVelocity = new Vector3(5, 5, 5);
	        }
	        else 
	        {
	            //maxVelocity = new Vector3(3, 3, 3);
	        }

	        //Movement
	        if (Input.GetKey("w"))//Forward movement
	        {
	            //Checks to make sure the player has a max speed
	            if (Mathf.Abs(rigidbody.velocity.magnitude) <= maxVelocity.magnitude)
	            {
	                //The actual movement
	                rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
	            }
	        }
	        if (Input.GetKey("s"))//Moving backwards
	        {
	            if (Mathf.Abs(rigidbody.velocity.magnitude) <= maxVelocity.magnitude)
	            {
	                rigidbody.AddForce(transform.forward * -speed * Time.deltaTime);
	            }
	        }
	        if (Input.GetKey("a"))//Move to the left 
	        {
	            if (Mathf.Abs(rigidbody.velocity.magnitude) <= maxVelocity.magnitude)
	            {
	                rigidbody.AddForce(transform.right * -speed * Time.deltaTime);
	            }
	        }
	        if (Input.GetKey("d")) //Move to the right
	        {
	            if (Mathf.Abs(rigidbody.velocity.magnitude) <= maxVelocity.magnitude)
	            {
	                rigidbody.AddForce(transform.right * speed * Time.deltaTime);
	            }
	        }
	        
	        //Dem Hops
	        if (Input.GetKeyDown("space")) 
	        {
	            if (grounded)
	            {
	                rigidbody.AddForce(transform.up * jumpForce);
	                grounded = false;
	            }
	        }

	        if(dead)
	        {
	            enabled = false;
	            Application.LoadLevel("EndGameMenu");
	        }
		}
	}

    //Checks to see if player has landed
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "floor" || other.gameObject.tag == "target") 
        {
            grounded = true;
        }
	
    }

	void OnTriggerEnter(Collider other)
	{
		print ("I hit a trigger");
		if (other.gameObject.tag == "Exit") 
		{
			Application.LoadLevel("EndGameMenu");
		}
	}
}
