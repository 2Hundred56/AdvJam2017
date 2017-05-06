using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTrigger : MonoBehaviour {
	Platformer player;
	// Use this for initialization
	void Start () {
		player = transform.parent.gameObject.GetComponent<Platformer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnDetect(Collider2D col) {
		if (col.gameObject == transform.parent.gameObject || player.isTouchingGround) {
			return;
		}
		player.isTouchingSide = true;
	}
	void OnTriggerEnter2D(Collider2D col) {
		OnDetect (col);

	}
	void OnTriggerStay2D(Collider2D col) {
		OnDetect (col);

	}
	void OnTriggerExit2D(Collider2D col) {
		player.isTouchingSide = false;
	}
}
