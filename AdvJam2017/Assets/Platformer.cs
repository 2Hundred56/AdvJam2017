using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour {	
	Rigidbody2D rb;
	public bool isTouchingSide = false;
	public bool isTouchingGround = false;
	GameObject floor = null;
	public int jumpForce = 5;
	public bool autoRight = true;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	float angle(Vector2 vector) {
		float ang = Vector2.Angle(new Vector2(1,0), vector);
		Vector3 cross = Vector3.Cross(new Vector2(1, 0), vector);

		if (cross.z < 0)
			ang = 360 - ang;
		return ang;
	}
	// Update is called once per frame
	void Update () {
		if (isTouchingGround || !isTouchingSide) {
			if (Input.GetKey(KeyCode.D)) {
				rb.velocity = new Vector2(0, rb.velocity.y) + (Vector2) transform.right * 4;
			}
			if (Input.GetKey(KeyCode.A)) {
				rb.velocity = new Vector2(0, rb.velocity.y) + (Vector2) transform.right * -4;
			}
		}
		if (isTouchingGround) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				rb.AddForce (transform.up*100*jumpForce);
			}
		}
		if (autoRight && (Vector2)transform.up != (new Vector2 (0, 1) * rb.gravityScale)) {
			transform.localRotation *= Quaternion.Euler (new Vector3 (0, 0, 10));
		}

	}
	void OnCollisionEnter2D (Collision2D col) {
		
	}
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Platform") {
			isTouchingGround = true;
			floor = col.gameObject;
			transform.SetParent (floor.transform);
		}
	}
	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.tag == "Platform") {
			print ("Off");
			isTouchingGround = false;
			floor = null;
			transform.SetParent (null);
		}
	}

		
}
