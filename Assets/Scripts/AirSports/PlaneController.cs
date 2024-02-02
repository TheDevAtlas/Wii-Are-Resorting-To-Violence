using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WiiU;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaneController : MonoBehaviour {

	public int channel;
	public float forwardSpeed;
	public Text score;
	public float turnSpeed = 2f;
	public int buildings;
	public GameObject explosion;

	public Rigidbody rb;
	public Transform remoteController;

	public Animator fade;

	// Plane moves forward automagically
	// Turn left + right to turn
	// Turn up + down to up + down
	// Plane Should Always Add Acceleration To Forwa
	//rd Direction
	// Add Drag To Other Directions

	void Update(){

		// Rotate Plane In Direction Of Controller //
		MotionPlusState data = Remote.Access(channel).state.motionPlus;
		Remote.Access(channel).motionPlus.Enable(MotionPlusMode.Standard);

		var look = -data.dir.Y;
		var up = data.dir.Z;

		look.x *= -1;
		up.x *= -1;

		// Instead of setting rotation, lets add to the rotation
		// transform.localRotation = Quaternion.LookRotation(look, up);
		// transform.localRotation *= Quaternion.LookRotation(look* Time.deltaTime, up* Time.deltaTime) ;
		remoteController.localRotation = Quaternion.LookRotation(look, up);
		transform.Rotate (new Vector3 (remoteController.localRotation.x - 0.7f, remoteController.localRotation.y, remoteController.localRotation.z) * Time.deltaTime * turnSpeed);
		//score.text = remoteController.localRotation.x + "";
		remoteController.Rotate(new Vector3(90f, 0f,0f));
		// Move Plane Forward //
		transform.position += transform.forward * forwardSpeed * Time.deltaTime;

		//score.text = look + " : " + up;

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "build") {
			buildings--;
			Instantiate (explosion, col.gameObject.transform.position, Quaternion.identity);
			Destroy (col.gameObject);
			score.text = buildings + " Buildings Left";

			if (buildings <= 0) {
				fade.SetBool("changeScene",true);
				Invoke("ChangeScene",1.5f);
			}
		}
	}

	void ChangeScene()
	{
		SceneManager.LoadScene(0);
	}
}
