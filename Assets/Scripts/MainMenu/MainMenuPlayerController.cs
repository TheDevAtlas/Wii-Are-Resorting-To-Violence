using UnityEngine;
using UnityEngine.WiiU;
using System.Collections;
using UnityEngine.UI;

public class MainMenuPlayerController : MonoBehaviour {

	public int channel;

	public bool IsAPress;
	public bool IsBPress;

	public Vector2 pointerPos;

	public RectTransform pointer;

	void Update()
	{
		RemoteState input = Remote.Access (channel).state;

		APressed(ref input, RemoteButton.A, "Button/A");
		BPressed (ref input, RemoteButton.B, "Button/B");

		pointerPos = new Vector2((input.pos.x * 1920f / 3f + 1920f/2f), (-input.pos.y * 1080f / 3f + 1080f/2f));
	}

	void FixedUpdate()
	{
		pointer.position = pointerPos;
	}

	private void APressed(ref RemoteState input, RemoteButton button, string name)
	{
		IsAPress = input.IsPressed (button);
	}

	private void BPressed(ref RemoteState input, RemoteButton button, string name)
	{
		IsBPress = input.IsPressed (button);
	}
}
