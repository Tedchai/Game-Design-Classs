using System.Collections;
using System.Collections.Generic; //allows call to core routine
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Stomp : MonoBehaviour {

	public AudioClip enemyDeathSound;
	public float delay;

	AudioSource audio;
	private Rigidbody2D playerBody;
	public float bounceOnEnemy;

	public GameObject enemyDeathEffect;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		playerBody = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> (); // Looks for the game object that has the specific tag, and wants to maniuplate the component inside that object as RigiBody

	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {

			StartCoroutine ("DelayDeath"); //lags cpu and makes things slow
			Instantiate (enemyDeathEffect, coll.transform.position, coll.transform.rotation);
			playerBody.velocity = new Vector2 (playerBody.velocity.x, bounceOnEnemy);
			//problem without putting anything below this is that no sound gets played since everything happens at the same time.
		}
	}

	IEnumerator DelayDeath () { 
		audio.PlayOneShot (enemyDeathSound, 1.0f);
		yield return new WaitForSeconds (delay);
		Destroy (transform.parent.gameObject); //destroys the parent of the slime instead of the box
	}
}
