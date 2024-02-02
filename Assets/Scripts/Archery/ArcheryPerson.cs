using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcheryPerson : MonoBehaviour {

	public ArcheryPlayer p1;
	public ArcheryPlayer p2;
	public ArcheryPlayer p3;
	public ArcheryPlayer p4;
	public GameObject explosion;
	public AudioSource sound;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "1") {
			Instantiate (explosion, transform.position, Quaternion.identity);
			p1.score++;
			Destroy (col.gameObject);
			Destroy (gameObject);
			ArcheryController.totalPeople--;
			sound.Play ();
		}else
		if (col.gameObject.tag == "2") {
			Instantiate (explosion, transform.position, Quaternion.identity);
			p2.score++;
			Destroy (col.gameObject);
			Destroy (gameObject);
			ArcheryController.totalPeople--;
				sound.Play ();
		}else
		if (col.gameObject.tag == "3") {
			Instantiate (explosion, transform.position, Quaternion.identity);
			p3.score++;
			Destroy (col.gameObject);
			Destroy (gameObject);
			ArcheryController.totalPeople--;
					sound.Play ();
		}else
		if (col.gameObject.tag == "4") {
			Instantiate (explosion, transform.position, Quaternion.identity);
			p4.score++;
			Destroy (col.gameObject);
			Destroy (gameObject);
			ArcheryController.totalPeople--;
						sound.Play ();
		}
	}
}
