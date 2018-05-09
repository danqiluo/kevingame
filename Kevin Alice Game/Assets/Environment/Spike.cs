using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	/**
     * Damages enemies upon impact. 
     */
	void OnCollisionEnter2D (Collision2D collision) {
		Entity collisionGameObjectEntity = collision.gameObject.GetComponent<Entity>();
		if (collisionGameObjectEntity != null) {
			collisionGameObjectEntity.TakeDiscreteDamage(10f);
		}
	}
}
