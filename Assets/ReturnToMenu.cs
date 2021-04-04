using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{
   public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("Main_Manu", LoadSceneMode.Single); 
    }
}
