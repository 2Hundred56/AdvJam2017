using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flips : MonoBehaviour {
	Rigidbody2D rb;
	int d = 0;
	int delay = 3;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		d += 1;
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Mirror") {
			if (d<delay) {
				flip ();
			}
			d = 0;
		}
	}
	void OnTriggerExit2D(Collider2D col) {
	}

	void flip() {
		rb.gravityScale *= -1;

	}
}
