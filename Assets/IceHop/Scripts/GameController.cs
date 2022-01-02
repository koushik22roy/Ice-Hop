using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
	public GameObject PlayButton;
	public GameObject RestartButton;
	public Image Title;
	public Image GameOverImg;

	void GameOver(){
		//On game over, scrolling backgroud and camera movement is deactivated.
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mover> ().speed=0;
		GameObject.FindGameObjectWithTag("Background").GetComponent<ScrollingBackground> ().speed=0;
		//Game Over title is appeared by fading.
		GameOverImg.DOFade (1,0.5f);
		//restart button is enabled.
		RestartButton.SetActive (true);
		//And time scale is set to 1.
		Time.timeScale = 1;
	}
	public void StartGame(){
		//On pressing start game, scrolling backgroud and camera movement is activated.
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mover> ().speed=2;
		GameObject.FindGameObjectWithTag("Background").GetComponent<ScrollingBackground> ().speed=2;
		//Players controls are activated.
		GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ().GameOn=true;
		//play button is removed.
		PlayButton.SetActive (false);
		//And the title is fade to disapear.
		Title.DOFade (0,0.5f);
	}
	public void RestartGame(){
		//Restarts the game.
		Application.LoadLevel(Application.loadedLevel);
	}
}
