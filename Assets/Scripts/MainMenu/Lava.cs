using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

	// Scroll main texture based on time

    public float scrollSpeed = 0.5f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer> ();
    }

    void FixedUpdate()
    {
        float offset = Time.fixedTime * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
