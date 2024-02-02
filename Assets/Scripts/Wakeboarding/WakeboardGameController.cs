using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WakeboardGameController : MonoBehaviour {

	public float sharkSpawnSpeed;
	public float peopleSpawnSpeed;
	float timerShark;
	float timerPeople;

	public GameObject shark;
	public GameObject[] person;

	public Text p1;
	public Text p2;
	public Text p3;
	public Text p4;
	public int s1;
	public int s2;
	public int s3;
	public int s4;
	public GameObject pl1;
	public GameObject pl2;
	public GameObject pl3;
	public GameObject pl4;
	public Animator fade;

	void Update(){
		timerShark += Time.deltaTime;
		timerPeople += Time.deltaTime;

		if (sharkSpawnSpeed <= timerShark) {
			timerShark = 0f;
			sharkSpawnSpeed *= 0.99f;

			Instantiate (shark, new Vector3 (Random.Range(-10,10),0f,40f), shark.transform.rotation);
		}

		if (peopleSpawnSpeed <= timerPeople) {
			timerPeople = 0f;
			peopleSpawnSpeed *= 0.99f;

			Instantiate (person[Random.Range(0,1)], new Vector3 (Random.Range(-10,10),0f,40f), Quaternion.identity);
		}

		p1.text = s1 + "";
		p2.text = s2 + "";
		p3.text = s3 + "";
		p4.text = s4 + "";

		if(pl1.activeSelf == false && pl2.activeSelf == false && pl3.activeSelf == false && pl4.activeSelf == false){
			fade.SetBool("changeScene",true);
			Invoke("ChangeScene",1.5f);
		}

	}

	void ChangeScene()
	{
		SceneManager.LoadScene(0);
	}
}
