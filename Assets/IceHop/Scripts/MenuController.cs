using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    [SerializeField]GameObject HudCanvas;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] private Toggle uiVibrationToggle;

    void Start()
    {
        highScoreText.text = ""+PlayerPrefs.GetInt("HighScore", 0);
        Settings.OnVibrationChnaged += OnVibChange;
    }

    void Update()
    {
        if(!EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton(0))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("IceHop");
    }

    private void Awake()
    {
        uiVibrationToggle.isOn = Settings.VibrationEnabled;
        uiVibrationToggle.onValueChanged.AddListener(OnVibrationToggleChange);
    }
    private void OnVibrationToggleChange(bool value)
    {
        Settings.VibrationEnabled = value;
    }


    //Settings
    private void OnVibChange(bool value)
    {
        Debug.Log("VibrationChnaged" + value);
    }
}
