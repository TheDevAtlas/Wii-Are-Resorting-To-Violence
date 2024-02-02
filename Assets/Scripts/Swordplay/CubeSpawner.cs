using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	public GameObject[] things;
	public Vector3 spinForce;

	void Start(){
		InvokeRepeating ("Spawn", 1f, 1f);
	}

	void Spawn(){
		GameObject n = Instantiate (things[Random.Range(0,things.Length-1)], new Vector3 (Random.Range(-3,3),transform.position.y, transform.position.z), Quaternion.identity);
		n.transform.localScale = new Vector3 (10f, 10f, 10f);
		n.GetComponent<Rigidbody> ().AddTorque (new Vector3(Random.Range(-spinForce.x,spinForce.x),Random.Range(-spinForce.y,spinForce.y),Random.Range(-spinForce.z, spinForce.z)));
	}
}
