using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering; 
using TMPro; 
using UnityEngine;

public class Settings_MenuManager_ZacB : MonoBehaviour
{
    #region Resolution Settings
    public void SetFullScreen(bool isfullScreen)
    {
        Screen.fullScreen = isfullScreen;
    }

    public void SetWindowedScreen(bool isWindowed)
    {
        isWindowed = !isWindowed; 
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    public void SetResolutionFull()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }

    #endregion End Resolution Settings 

    #region Quality Settings 

    private void Start()
    {
        GetQualSettings(5); 
        Debug.Log("Default Quality Setting"); 
    }

    public void GetQualSettings(int value)
    {
        value = QualitySettings.GetQualityLevel();
    }

    public void SetVeryLowQual()
    {
        QualitySettings.SetQualityLevel(0);
        Debug.Log("Very Low Quality Selected"); 
    }

    public void SetLowQual()
    {
        QualitySettings.SetQualityLevel(1);
        Debug.Log("Low Quality Selected");
    }

    public void SetMediumQual()
    {
        QualitySettings.SetQualityLevel(2);
        Debug.Log("Medium Quality Selected");
    }

    public void SetHighQual()
    {
        QualitySettings.SetQualityLevel(3);
        Debug.Log("High Quality Selected");
    }

    public void SetVeryHighQual()
    {
        QualitySettings.SetQualityLevel(4);
        Debug.Log("Very High Quality Selected");
    }

    public void SetUltraQual()
    {
        QualitySettings.SetQualityLevel(5);
        Debug.Log("Ultra Quality Selected");
    }

    #endregion End Quality Settings 
}