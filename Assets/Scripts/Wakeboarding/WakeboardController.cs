using UnityEngine;
using UnityEngine.WiiU;
using System.Collections;

public class WakeboardController : MonoBehaviour {

	public int channel;
	public float speed;
	public Vector2 bounds;
	public WakeboardGameController gc;

	void Start(){
		RemoteDevType type = RemoteDevType.Unknown;
		Remote rem = Remote.Access (channel);
		RemoteError err = rem.Probe (out type);
		if (err == RemoteError.NoController) {
			gameObject.SetActive (false);
		}
	}

    void Update()
    {

        MotionPlusState data = Remote.Access(channel).state.motionPlus;
        //data.Enable(MotionPlusMode.ENABLED);
        Remote.Access(channel).motionPlus.Enable(MotionPlusMode.Standard);

        var look = -data.dir.Y;
        var up = data.dir.Z;

        look.x *= -1;
        up.x *= -1;

//        transform.localRotation = Quaternion.LookRotation(look, up);

		transform.position = transform.position + new Vector3(up.y * speed * Time.deltaTime,0f,0f);
		if (transform.position.x > bounds.y) {
			transform.position = new Vector3 (bounds.y, transform.position.y, transform.position.z);
		}
		if (transform.position.x < bounds.x) {
			transform.position = new Vector3 (bounds.x, transform.position.y, transform.position.z);
		}
    }

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Shark") {
			Destroy (other.gameObject);
			gameObject.SetActive (false);
		}

		if (other.gameObject.tag == "Person") {
			Destroy (other.gameObject);

			if (channel == 0) {
				gc.s1++;
			}
			if (channel == 1) {
				gc.s2++;
			}
			if (channel == 2) {
				gc.s3++;
			}
			if (channel == 3) {
				gc.s4++;
			}

		}
	}
}
