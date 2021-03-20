using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro; 
using UnityEngine;

public class Settings_MenuManager_ZacB : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown textureDropdown;
    public TMP_Dropdown aADropdown; 

    Resolution[] resolutions;

    private void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResIndex = 0; 

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option); 
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i; 
            }
        }
    }

    public void SetFullScreen(bool isfullScreen)
    {
        Screen.fullScreen = isfullScreen;
    }

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen); 
    }

    public void SetTexture(int texIndex)
    {
        QualitySettings.masterTextureLimit = texIndex;
        qualityDropdown.value = 6; 
    }

    public void SetAA(int aAIndex)
    {
        QualitySettings.antiAliasing = aAIndex;
        qualityDropdown.value = 6; 
    }

    public void SetQualitySettings(int qIndex)
    {
        if(qIndex != 6)
        {
            QualitySettings.SetQualityLevel(qIndex); 
            switch(qIndex)
            {
                case 0: // very low quality 
                    textureDropdown.value = 3; 
                    aADropdown.value = 0;
                    break;
                case 1: // low quality 
                    textureDropdown.value = 2;
                    aADropdown.value = 0;
                    break;
                case 2: // medium quality 
                    textureDropdown.value = 1;
                    aADropdown.value = 0;
                    break;
                case 3: // high quality 
                    textureDropdown.value = 0;
                    aADropdown.value = 0;
                    break;
                case 4: // very high quality 
                    textureDropdown.value = 0;
                    aADropdown.value = 1;
                    break;
                case 5: // ultra quality 
                    textureDropdown.value = 0;
                    aADropdown.value = 2;
                    break;
            }

            qualityDropdown.value = qIndex; 
        }
    }
}
