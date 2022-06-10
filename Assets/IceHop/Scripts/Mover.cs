using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;
	void FixedUpdate () {
		//Controls the movement of main camera.
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0f);
	}
}
