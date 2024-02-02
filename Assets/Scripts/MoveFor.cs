using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFor : MonoBehaviour {

	public Vector3 move;

	void Update(){
		transform.Translate (move * Time.deltaTime);
	}

}
