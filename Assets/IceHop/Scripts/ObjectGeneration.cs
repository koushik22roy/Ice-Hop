using UnityEngine;
using System.Collections;

public class ObjectGeneration : MonoBehaviour {
	public GameObject[] objects;
	public Transform GenerationPoint;
	public float ObjectWidth;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//When GenerationPoint exceeds the gameobject, a new game object is instantiated. 
		if(transform.position.x<GenerationPoint.position.x){
			transform.position=new Vector3(transform.position.x + ObjectWidth,transform.position.y,transform.position.z);
			GameObject newGameObject=objects[Random.Range (0, objects.Length)];
			Instantiate(newGameObject,transform.position,transform.rotation);
		}
	}	
}
