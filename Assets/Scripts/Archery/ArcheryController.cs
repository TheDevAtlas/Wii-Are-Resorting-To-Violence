using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcheryController : MonoBehaviour {

	public Animator Fade;
	public int people;

	public static int totalPeople;

	bool isDone;

	void Start(){
		totalPeople = people;
	}

	void Update(){
		if (isDone) {
			return;
		}

		if (totalPeople <= 0) {
			Fade.SetBool("changeScene",true);
			isDone = true;
			Invoke("ChangeScene",1.5f);
		}

		people = totalPeople;
	}

	void ChangeScene()
	{
		SceneManager.LoadScene(0);
	}
}
