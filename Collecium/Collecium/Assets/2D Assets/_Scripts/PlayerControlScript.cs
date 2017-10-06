using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Every script will have its own script
[RequireComponent(typeof(AudioSource))]
public class PlayerControlScript : MonoBehaviour {
	//First place we declare variables is after ^ and before start
	public float speed;
	public float maxspeed;
	public float jumpForce;

	public bool isGrounded;
    public bool m_deathCheck;
    public bool m_hurt;
    //A ridgid body is put on an object in order to have physics

    public AudioClip jumpSfx;
	public GameObject respawn;

    private Rigidbody2D rigiBody;
	private Animator anim;

	public AudioSource jumpAudio;

    AudioSource audio;//audio source setup

	//projectitle
	public Transform bulletPoint;
	public GameObject bullet;
	// Use this for initialization
	void Start () {

		rigiBody = gameObject.GetComponent<Rigidbody2D> (); //get gives us accesss to Rigifbody 2d Component
		anim = gameObject.GetComponent<Animator>(); //get access to animator component

		audio = GetComponent<AudioSource> (); //get access to Audio component


	}


	// Update is called once per frame
	void Update ()
    {
		anim.SetBool ("isGrounded", isGrounded);//setting grounded value in animation
		anim.SetFloat ("Speed", Mathf.Abs(rigiBody.velocity.x)); // setting speed value in animation by using an ABS value to prevent negative values.

		float h = Input.GetAxis ("Horizontal"); //nonmember variable, it is not declared up above for the script to use.

		if (Input.GetAxis("Horizontal") < -0.001f) {

			transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f); //transform is the space in the game world.
	}
		if (isGrounded) {
			rigiBody.AddForce ((Vector2.right * speed) * h); //allows movement of left and right.
		}

		if (Input.GetAxis("Horizontal") > 0.001f) {
           transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f); //transform is the space in the game world.
		}
		if (isGrounded) {
			rigiBody.AddForce ((Vector2.right * speed) * h); //allows movement of left and right.
		}
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			rigiBody.AddForce (Vector2.up * jumpForce); // adding force vertically to jump		
			audio.PlayOneShot( jumpSfx, 1.0f);  //Play oneshot will only play once and this line will play the jump sound.
		}

		if (!isGrounded) {
			speed = 30f;
	}
		else {
			speed = 40f;
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			Instantiate (bullet, bulletPoint.position, bulletPoint.rotation);
		} /* */

		if (Input.GetKeyDown (KeyCode.Z)) {
			Instantiate (bullet, bulletPoint.position, bulletPoint.rotation);
		}
	}

    void FixedUpdate()
    {
        Vector3 easeVelocity = rigiBody.velocity;
        easeVelocity.y = rigiBody.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= .75f;

        if (isGrounded)
        {
            rigiBody.velocity = easeVelocity;
        }
        if (rigiBody.velocity.x > maxspeed)
        {
            rigiBody.velocity = new Vector2(maxspeed, 0f);
        }
        if (rigiBody.velocity.x < -maxspeed)
        {
            rigiBody.velocity = new Vector2(-maxspeed, 0f);
    }
        
       
    }

    void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("KillVolume")) {
            transform.position = respawn.transform.position;
			}
	}	
			}



// Script was a courtesy of Elaine Gomez's youtube channel.
/*Updates that are being put in at a certain time or when you are using a delay.
void FixedUpdate () {
No code would go here but this is where you would load up the processes
void Awake() {
		
}

	}*/


