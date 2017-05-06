using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	int t=0;
	int direction=1;
	public int turn=500;
	public float speed=2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (speed * direction*Time.deltaTime, 0);
		t += 1;
		if (t >= turn) {
			t -= turn;
			direction *= -1;
		}

	}
}
