using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {
	int recharge=10;
	int t=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		t += 1;
	}
	void onTriggerEnter2D(Collider collider) {
		if (t > recharge) {
			t = 0;
			Physics.gravity *= -1;
		}
	}

}
