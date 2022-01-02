using UnityEngine;
using System.Collections;

public class ObjectDestruction : MonoBehaviour {
	GameObject Destructor;
	// Use this for initialization
	void Start () {
		//assigning Destructor to DestructionPoint GameObject.
		Destructor = GameObject.FindGameObjectWithTag ("Destructor");
	}
	
	// Update is called once per frame
	void Update () {
		//if the game object excedes the destruction point, it gets destroyed.
		if(transform.position.x < Destructor.transform.position.x ){
			Destroy (this.gameObject);
		}
	}
}
