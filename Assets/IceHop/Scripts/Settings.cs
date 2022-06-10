using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class Settings 
{
    public static UnityAction<bool> OnVibrationChnaged;

    public static bool _vibrationEnabled;

    public static bool VibrationEnabled
    {
        get { return _vibrationEnabled; }
        set
        {
            _vibrationEnabled = value;
            PlayerPrefs.SetInt("VibrationEnabled", (value ? 1 : 0));
            FireEvent(OnVibrationChnaged, value);
        }
    }

    private static void FireEvent<T>(UnityAction<T> action, T value)
    {
        if (action != null)
            action.Invoke(value);
    }

    static Settings()
    {
        _vibrationEnabled = (PlayerPrefs.GetInt("VibrationEnabled", 0) == 0 ? false : true);
    }
}
