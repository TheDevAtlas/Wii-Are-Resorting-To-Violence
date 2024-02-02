using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {
	public int gameNum;

	public Animator AButton;
	public Animator BButton;
	public Animator Instructions;
	public Animator MainMenu;
	public Animator GameSelect;
	public Animator Fade;

	public bool startGame;
	public bool endScene;
	bool aRelease;

	public MainMenuPlayerController player1;

	public AudioSource startSound;
	public AudioSource gameSound;

	public Transform camPivot;
	public Transform camTrans;
	public Vector3 pivotRotation;
	public Vector3 camPos;
	public Vector3 camRotation;
	public float smoothSpeed = 0.125f;

	public Image top;
	public Image bot;
	public Sprite topG;
	public Sprite topC;
	public Sprite botG;
	public Sprite botC;

	public Rotate r;

	void Update () {
		if(endScene)
		{
			return;
		}
		if (startGame) {
			Instructions.SetBool ("startGame", true);
			MainMenu.SetBool ("startGame", true);
			GameSelect.SetBool("startGame",true);
			// rotate camera towards rotation target
			Vector3 smoothedRotation = Vector3.Lerp(camPivot.localEulerAngles, pivotRotation, smoothSpeed);
			camPivot.localEulerAngles = smoothedRotation;
			//move camera towards target
			Vector3 smoothedPosition = Vector3.Lerp(camTrans.position, camPos, smoothSpeed);
			camTrans.position = smoothedPosition;
			smoothedRotation = Vector3.Lerp(camTrans.localEulerAngles, camRotation, smoothSpeed);
			camTrans.localEulerAngles = smoothedRotation;
			r.enabled = false;
			// smoothSpeed += Time.deltaTime / 2f;
			if (player1.IsAPress && aRelease == false) {
				//AButton.SetBool ("isPress", true);
				// Change Scene
				Fade.SetBool("changeScene",true);
				gameSound.Play ();
				Invoke("ChangeScene",1.5f);
			}else if(player1.IsAPress == false && aRelease == true)
			{
				aRelease = false;
			}

			return;
		}

		if (player1.IsAPress) {
			AButton.SetBool ("isPress", true);
			top.sprite = topC;
		} else {
			AButton.SetBool ("isPress", false);
			top.sprite = topG;
		}

		if (player1.IsBPress) {
			BButton.SetBool ("isPress", true);
			bot.sprite = botC;
		} else {
			BButton.SetBool ("isPress", false);
			bot.sprite = botG;
		}

		if (player1.IsAPress && player1.IsBPress) {
			aRelease = true;
			startGame = true;
			startSound.Play ();
		}
	}

	void ChangeScene()
	{
		SceneManager.LoadScene(gameNum+1);
	}
}
