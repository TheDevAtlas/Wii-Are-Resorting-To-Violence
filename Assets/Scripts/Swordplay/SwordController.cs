using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WiiU;

public class SwordController : MonoBehaviour {

	public int channel;

	void Update(){

		// Rotate Plane In Direction Of Controller //
		MotionPlusState data = Remote.Access(channel).state.motionPlus;
		Remote.Access(channel).motionPlus.Enable(MotionPlusMode.Standard);

		var look = -data.dir.Y;
		var up = data.dir.Z;

		look.x *= -1;
		up.x *= -1;

		transform.localRotation = Quaternion.LookRotation(look, up);
	}
}
