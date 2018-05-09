using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	protected Rigidbody2D rb2D;

	public float maxHealth;
	public float health;
	protected float healthRegenerationRate;
	protected float speed;

	// Use this for initialization
	protected void Start () {
		rb2D = GetComponent<Rigidbody2D>();

		maxHealth = 100f;
		health = maxHealth;
		healthRegenerationRate = 0f;
		speed = 25f;
	}
	
	// Update is called once per frame
	protected void Update () {
		
	}

	protected void FixedUpdate () {
		if (health < maxHealth) {
			health += healthRegenerationRate * Time.deltaTime;
		}
		if (health > maxHealth) {
			health = maxHealth;
		}

		if (Input.GetKey(KeyCode.W)) {

		}

		Move(Input.GetKey(KeyCode.W), Input.GetKey(KeyCode.S), Input.GetKey(KeyCode.D), Input.GetKey(KeyCode.A));
	}

	public void TakeDiscreteDamage (float damage) {
		health -= damage;
		Debug.Log(health);
	}

	/**
     * Moves up for W, down for S, right for D, and left for A. 
     * Diagonal movement for orthogonal combinations of WASD. 
     */
	public void Move (bool W, bool S, bool D, bool A) {
		float verticalDirection = 0;
		verticalDirection += W ? 1 : 0;
		verticalDirection += S ? -1 : 0;

		float horizontalDirection = 0;
		horizontalDirection += D ? 1 : 0;
		horizontalDirection += A ? -1 : 0;

		float verticalForce = 0;
		float horizontalForce = 0;
		if ((new Vector2(horizontalDirection, verticalDirection).magnitude > 0)) {
			double direction = Math.Atan2(verticalDirection, horizontalDirection);
			verticalForce = speed * (float)Math.Sin(direction);
			horizontalForce = speed * (float)Math.Cos(direction);
		}
		//Debug.Log(new Vector2(horizontalForce, verticalForce));
		//if (relative) {
		//    rb2D.AddRelativeForce(power * new Vector2(horizontalForce, verticalForce));
		//} else {
		rb2D.AddForce(new Vector2(horizontalForce, verticalForce));
		//}
	}
}
