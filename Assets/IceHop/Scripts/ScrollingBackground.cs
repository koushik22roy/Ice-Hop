using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
	public float speed;

	void FixedUpdate () {
		Vector2 offset = new Vector2 (Time.time*speed/60f,0f);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
