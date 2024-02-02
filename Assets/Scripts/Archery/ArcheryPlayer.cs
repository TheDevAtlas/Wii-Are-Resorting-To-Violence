using System.Collections;
using System.Collections.Generic;
using UnityEngine.WiiU;
using UnityEngine;
using UnityEngine.UI;

public class ArcheryPlayer : MonoBehaviour {

	public int channel;

	public int score;
	public Text sText;

	public Vector2 pointerPos;

	public RectTransform pointer;

	public GameObject bulletPrefab;
	public float shootSpeed;
	bool shot;
	bool IsBPress;
	public Camera mainCamera;
	public Transform bulletSpawnPoint;

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
		RemoteState input = Remote.Access (channel).state;

		pointerPos = new Vector2((input.pos.x * 1920f / 3f + 1920f/2f), (-input.pos.y * 1080f / 3f + 1080f/2f));

		BPressed(ref input, RemoteButton.B, "Button/B");

		sText.text = score + "";
	}

	void FixedUpdate ()
	{
		pointer.position = pointerPos;
		ShootBullet ();
	}

	public void ShootBullet()
	{
		if((IsBPress || Input.GetMouseButton(0)))
		{
			if(shot == false)
			{
				Vector3 cursorWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(pointer.position.x, pointer.position.y, mainCamera.nearClipPlane));
				Vector3 direction = (cursorWorldPosition - bulletSpawnPoint.position).normalized;
				GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
				bullet.GetComponent<Rigidbody>().velocity = direction * shootSpeed; // Set the speed of your bullet
				shot = true;
			}
		}
		else{
			shot = false;
		}

	}

	private void BPressed(ref RemoteState input, RemoteButton button, string name)
	{
		IsBPress = input.IsPressed (button);
	}
}
