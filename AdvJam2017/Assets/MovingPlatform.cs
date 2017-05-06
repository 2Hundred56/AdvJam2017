using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	int t=0;
	int direction=1;
	int turn=100;
	float speed=0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (speed * direction, 0);
		t += 1;
		if (t >= turn) {
			t -= turn;
			direction *= -1;
		}

	}
}
