using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public Vector3 speed;

	void FixedUpdate()
	{
		transform.Rotate (speed * Time.fixedDeltaTime);
	}
}
