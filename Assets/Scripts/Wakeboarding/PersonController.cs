﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour {

	public float speed;

	void FixedUpdate(){
		transform.position += new Vector3 (0f, 0f, speed * Time.fixedDeltaTime);
	}
}