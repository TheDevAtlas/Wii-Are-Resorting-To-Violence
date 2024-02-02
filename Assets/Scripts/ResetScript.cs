using System.Collections;
using System.Collections.Generic;
using UnityEngine.WiiU;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour {

	public int channel;
	public int menu;
	public int thisscene;

	void Update()
	{
		RemoteState input = Remote.Access (channel).state;
		PlusPress(ref input, RemoteButton.Plus, "Button/Plus");
		MinusPress(ref input, RemoteButton.Minus, "Button/Minus");
	}

	private void PlusPress(ref RemoteState input, RemoteButton button, string name)
	{
		if (input.IsPressed (button)) {
			SceneManager.LoadScene(menu);
		}

	}

	private void MinusPress(ref RemoteState input, RemoteButton button, string name)
	{
		if (input.IsPressed (button)) {
			SceneManager.LoadScene(thisscene);
		}
	}
}
