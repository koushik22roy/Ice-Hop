  using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class Player : MonoBehaviour {
	public GameObject Score;
	public GameObject HighScore;
	int score;
	int highscore;
	public bool GameOn; 
	private SFXmanager sfx;
	// Use this for initialization
	void Start () {
		//get value of highscore and show on highscore text.
		//highscore=PlayerPrefs.GetInt ("HighScore",0);
		//HighScore.GetComponent<Text>().text =highscore.ToString ();
		//stimulate touches as mouse click.
		Input.simulateMouseWithTouches = true;
		sfx = FindObjectOfType<SFXmanager> ();
	}

	void Update () {
		if (!GameOn) {
			//on pressing left key, jump and move to next iceberg while playing small jump audio.
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				transform.DOMoveX (transform.position.x + 1.1f, 0.1f);
				transform.DOMoveY (transform.position.y + 0.2f, 0.05f);
				sfx.JumpingSmall.Play ();
			}
			//on pressing right key, jump and move to two iceberg ahead while playing big jump audio.
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				transform.DOMoveX (transform.position.x + 2.2f, 0.1f);
				transform.DOMoveY (transform.position.y + 0.2f, 0.05f);
				sfx.JumpingBig.Play ();
			}
			//On android and ios touching left side of the screen will perform small jump whereas right side of screen will perform big jump.
			#if UNITY_IOS || UNITY_ANDROID
			if (Input.GetMouseButtonDown (0) && Input.mousePosition.x <= Screen.width / 2) {
				transform.DOMoveX (transform.position.x + 1.1f, 0.1f);
				transform.DOMoveY (transform.position.y + 0.2f, 0.05f);
			sfx.JumpingSmall.Play ();
			} else if (Input.GetMouseButtonDown (0) && Input.mousePosition.x > Screen.width / 2) {
				transform.DOMoveX (transform.position.x + 2.2f, 0.1f);
				transform.DOMoveY (transform.position.y + 0.2f, 0.05f);
			sfx.JumpingBig.Play ();
			}
#endif

			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mover>().speed = 2;
		//	GameObject.FindGameObjectWithTag("Background").GetComponent<ScrollingBackground>().speed = 2;
		}
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		//If the player gets out of the gameplay area, end the game.
		if (screenPosition.x > Screen.width || screenPosition.x < 0)
		{
			//GameOn = false;
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ().GameOver();
			sfx.GameOver.Play ();
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		//On steping on next iceberg add score and increase time scale by 0.02.
		if(coll.gameObject.tag=="Iceberg")
		{
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Score();
		}
	}
	void OnTriggerEnter2D(Collider2D other) {	
		//GameOn = false;
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GameOver();
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mover>().speed = 0;
		sfx.Sinking.Play ();
		//slowly sink the player and destroy afterwards.
		transform.DOMoveY (-6f,1.5f);
		Destroy(this.gameObject,1.5f);
	}
}
