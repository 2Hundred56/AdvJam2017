﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour {
	bool touching = false;
	Vector3 grav = new Vector3(0, -.30625f, 0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void onCollisionEnter2D (Collider2D coll) {
		print ("We hit something");
	}
		
}