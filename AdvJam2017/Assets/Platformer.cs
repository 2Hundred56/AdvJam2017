using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour {	
	// Use this for initialization
	Rigidbody2D rb;
	float rotAngle = 0.0f;
	int rotMode = 0;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		/* Rot modes:
		 * -2 - Above y=0 rotating
		 * -1 - Below y=0 static
		 * 0  - Above y=0 static
		 * 1  - Below y=0 rotating
		 * 
		*/
		if (transform.position.y<0) {
			rb.gravityScale = -1;
			if (rotMode == 0) {
				rotMode = 1;
			}
			if (rotMode == 1) {
				float rotAmount = 360 * Time.deltaTime;
				transform.Rotate (new Vector3 (0, 0, rotAmount));
				rotAngle += rotAmount;
				if (rotAngle >= 180) {
					rotMode = -1;
					rotAngle = 0;
				}
			}

		} else {
			rb.gravityScale = 1;
			if (rotMode == -1) {
				rotMode = -2;
			}
			if (rotMode == -2) {
				float rotAmount = 360 * Time.deltaTime;
				transform.Rotate (new Vector3 (0, 0, rotAmount));
				rotAngle += rotAmount;
				if (rotAngle >= 180) {
					rotMode = 0;
					rotAngle = 0;
				}
			}
		}
	}
	void OnCollisionEnter2D (Collision2D col) {
		
	}
		
}
