using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BulletController : MonoBehaviour {

	public float speed;
	public GameObject Bullet; //calls the bullet object

	private PlayerControlScript player; //calls the playercontroller
	public GameObject slimeDeathEffect;

	AudioSource audio;
	public AudioClip slimeDeathSound; //set of death effect and death sound are in a pair when facing multiple enimies

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControlScript> ();

		audio = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, 0.0f); //0.0 is used to define the y. Speed is used to define the x. 
		if (player.transform.localScale.x < 0) {
			speed = -speed;
		}
		speed = 20f;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag =="Enemy")
		{
			audio.PlayOneShot (slimeDeathSound, 1.0f);	
			Instantiate (slimeDeathEffect, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
		if (other.tag == "Bullet Container") {
			Destroy (gameObject);
		}
}
}
