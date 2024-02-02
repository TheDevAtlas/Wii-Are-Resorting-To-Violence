using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwordGame : MonoBehaviour {

	public Text score;
	public Text timer;
	public float timeLeft = 60f;
	public float scoreTotal = 0f;

	public Animator fade;

	void Update(){
		// Convert timeLeft to minutes and seconds
		int minutes = Mathf.FloorToInt(timeLeft / 60F);
		int seconds = Mathf.FloorToInt(timeLeft % 60F);

		// Update the timer text to show minutes:seconds
		timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

		// Update the score text
		score.text = scoreTotal.ToString();

		// Decrease timeLeft by the time passed since the last frame
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) {
			timeLeft = 0;
			fade.SetBool("changeScene",true);
			Invoke("ChangeScene",1.5f);
		}
	}

	void ChangeScene()
	{
		SceneManager.LoadScene(0);
	}

}
