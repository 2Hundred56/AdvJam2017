using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour {	
	// Use this for initialization
	Rigidbody2D rb;
	bool isRotating = false;
	int hasRotated = 0; // 0 for no (top) 1 for yes (top) 2 for no (bottom) 3 for yes (bottom)
	Quaternion rotLast;
	Quaternion rotTarget;
	Quaternion upsideDown = Quaternion.Euler(new Vector3(0,0,180f));
	Quaternion rightSideUp = Quaternion.identity;
	float t;
	int flip = 1;
	public bool isTouchingSide = false;
	public bool isTouchingGround = false;
	GameObject floor = null;
	Vector3 positionRelative;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y<0) {
			rb.gravityScale = -1;
			flip = -1;
			if (!isRotating && (hasRotated == 1 || hasRotated == 2)) {
				isRotating = true;
				rotLast = transform.rotation;
				rotTarget = upsideDown;
			}

		} else {
			rb.gravityScale = 1;
			flip = 1;
			if (!isRotating && (hasRotated == 0 || hasRotated == 3)) {
				isRotating = true;
				rotLast = transform.rotation;
				rotTarget = rightSideUp;
			}
		}
		if (isRotating) {
			transform.rotation = Quaternion.Lerp (rotLast, rotTarget,t);
			t += 3 * Time.deltaTime;
			if (t>=1) {
				transform.rotation = Quaternion.Slerp (rotLast, rotTarget,1);
				isRotating = false;
				if (transform.position.y < 0) {
					hasRotated = 3;
				} else {
					hasRotated = 1;
				}
				t = 0;
			}
		}
		if (isTouchingGround || !isTouchingSide) {
			if (Input.GetKey(KeyCode.D)) {
				rb.velocity = new Vector2 (4 * flip, rb.velocity.y);
			}
			if (Input.GetKey(KeyCode.A)) {
				rb.velocity = new Vector2 (-4 * flip, rb.velocity.y);
			}
		}
		if (isTouchingGround) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				rb.AddForce (new Vector2 (0, 200));
			}
		}



	}
	void OnCollisionEnter2D (Collision2D col) {
		
	}
	void OnTriggerEnter2D (Collider2D col) {
		isTouchingGround = true;
		floor = col.gameObject;
		transform.SetParent (floor.transform);
	}
	void OnTriggerExit2D (Collider2D col) {
		isTouchingGround = false;
		floor = null;
		transform.SetParent (null);
	}
		
}
