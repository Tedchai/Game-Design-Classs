using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public float speed; //what makes the sprite move

	Rigidbody2D enemyBody;
	Transform enemyPostion;
	float enemyWidth;
	float enemyHeight;

	public LayerMask enemyMask;

	// Use this for initialization
	void Start () {
	
		SpriteRenderer enemySprite = this.GetComponent<SpriteRenderer> ();
		enemyBody = this.GetComponent<Rigidbody2D> ();

		enemyWidth = enemySprite.bounds.extents.x;  //.extends helps the program to look at all the points in between it acts as the incapsula of everything between the points
		enemyHeight = enemySprite.bounds.extents.y; 

		enemyPostion = this.transform;
	}

	void FixedUpdate () //tracks an update during each interval not each frame.
	{
		Vector2 lineCastPos = enemyPostion.position.toVector2 () - enemyPostion.right.toVector2 () * enemyWidth + Vector2.up*enemyHeight; //look at the xyz coordinate of this position

		bool isGrounded = Physics2D.Linecast (lineCastPos, lineCastPos + Vector2.down*1.5f, enemyMask);

		bool isBlocked = Physics2D.Linecast (lineCastPos, lineCastPos - enemyPostion.right.toVector2 () * .09f); //line casted in the physics is the same line that we are drawing

		Debug.DrawLine (lineCastPos, lineCastPos - enemyPostion.right.toVector2() * .09f);

		Debug.DrawLine (lineCastPos, lineCastPos + Vector2.down *1.5f);

		// if enemy is blocked or is not grounded

		// always move forward

		Vector2 myVelocity = enemyBody.velocity;
		myVelocity.x = enemyPostion.right.x * -speed;
		enemyBody.velocity = myVelocity; 

		if (!isGrounded || isBlocked) {
			Vector3 currRot = enemyPostion.eulerAngles; //rotation property of transform
			currRot.y += 180;
			enemyPostion.eulerAngles = currRot;
	}

	// Update is called once per frame
	
}
}
//Sprite Render is what 
