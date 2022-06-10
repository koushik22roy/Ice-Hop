using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameController : MonoBehaviour {

    public bool gameon;
    //bool promtToContinue;
    //private int diamonds = 0;
    private int score = 0;
    private int highscore;
    public float timeLeftToDie = 1f;
    public float timeToDie = 5f;

    //private string diamondsstr = "Diamond";
    private string scorestr = "Score";
    private string highscorestr = "HighScore";
    private string volumestr = "Volume";

    //diamondsText,, volumeOff, volumeOn, pausePannel,scoreOverText 
    [SerializeField] TextMeshProUGUI  scoreText,overScoreText,highScoreText;
    [SerializeField] GameObject adsToContinuePannel, adsToPlayPannel, gameOverPannel,hudCanvas;

    //public Slider slider;
    //public Tweener textPopUp;
    private void Start()
    {
       //diamonds = PlayerPrefs.GetInt(diamondsstr, 0);
       //diamondsText.text = "" + diamonds;

        score = PlayerPrefs.GetInt(scorestr, 0);
        scoreText.text = "" + score;

        highscore = PlayerPrefs.GetInt(highscorestr, 0);
        highScoreText.text = "" + highscore;

        var vol = PlayerPrefs.GetInt(volumestr, 1);
        AudioListener.volume = vol;
        if (AudioListener.volume == 0f)
        {
            //volumeOff.SetActive(false);
            //volumeOn.SetActive(true);
        }
        else
        {
            //volumeOff.SetActive(true);
            //volumeOn.SetActive(false);
        }
    }

    private void Update()
    {
        scoreText.text = "" + (int)score;
        highScoreText.text = "" + (int)highscore;
        overScoreText.text = "" + (int)score;
      
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt(highscorestr, highscore);
        }

       /* if (promtToContinue)
        {
            if (timeLeftToDie > 0)
            {
          //      slider.value = timeLeftToDie;
                timeLeftToDie -= Time.unscaledDeltaTime;
            }
            else
            {
                promtToContinue = false;
                GameOver();
            }
        }*/
    }

    public void Score()
    {
        score++;
    }

    public void VolOn()
    {
     //   volumeOff.SetActive(true);
     //   volumeOn.SetActive(false);
        AudioListener.volume = 1f;
        PlayerPrefs.SetInt(volumestr, 1);
        Debug.Log("Volume On");
    }

    public void VolOff()
    {
     //   volumeOff.SetActive(false);
     //   volumeOn.SetActive(true);
        AudioListener.volume = 0f;
        PlayerPrefs.SetInt(volumestr, 0);
        Debug.Log("Volume OFF");
    }

    public void PausePannel(int choice)
    {
        if (choice == 0)
        {
            Time.timeScale = 0f;
            //pausePannel.SetActive(true);
        }
        else
        {
            //pausePannel.SetActive(false);
            Time.timeScale = 1;
        }

    }
    public void ShowAdsPannel()
    {
        adsToContinuePannel.SetActive(true);
        timeLeftToDie = timeToDie;
        //slider.maxValue = timeToDie;
        //promtToContinue = true;
        Time.timeScale = 0;
    }
   /* public void ContinueWithCoins()
    {
        if (diamonds >= 10)
        {
            diamonds -= 10;
            PlayerPrefs.SetInt(diamondsstr, diamonds);
            diamondsText.text = diamonds + "";
            Continue2();
        }
        else
        {
            //popUpText.text = "Not Enough Coins";
          //  textPopUp.Show(textPopUp.CloseAfter);
        }
    }*/

    public void Continue2()
    {
        PlayerPrefs.SetInt(scorestr, (int)score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void RestartHome(int choice)
    {
        switch (choice)
        {
            case 1:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.SetInt(scorestr, 0);
                Time.timeScale = 1;
                break;
            case 2:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                Time.timeScale = 1;
                break;
        }
    }
    /* public void DiamondCount(int count)
     {
         diamonds += count;
         PlayerPrefs.SetInt(diamondsstr, diamonds);
         diamondsText.text = "" + diamonds;
     } */

    public void GameOver()
    {
       // PlayerPrefs.SetInt(scorestr, (int)score);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mover>().speed = 0;
        /*GameObject.FindGameObjectWithTag("Background").GetComponent<ScrollingBackground>().speed = 0;*/
        adsToContinuePannel.SetActive(false);
        gameOverPannel.SetActive(true);
        hudCanvas.SetActive(false);
        Handheld.Vibrate();
    }

    //ADs

    public void OnFinishedAds()
    {
       // promtToContinue = false;
        Time.timeScale = 0;
        adsToContinuePannel.SetActive(false);
        gameOverPannel.SetActive(false);
        adsToPlayPannel.SetActive(true);
    }
    public void OnSkippedAds()
    {

        //popUpText.text = "Please Watch the Whole Ad!";
      //  textPopUp.Show(textPopUp.CloseAfter);
    }
    public void OnFailedAds()
    {
       // popUpText.text = "Ads Loading...";
       // textPopUp.Show(textPopUp.CloseAfter);
    }
}
