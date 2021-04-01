using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class LoadMenus_Manager_ZacB : MonoBehaviour
{
    public bool isPressedStartGame;
    [SerializeField] public MainMenu_InteractiveControls_ZacB mM; 

    public void OnClickStartGame()
    {
        isPressedStartGame = true; 
        if(isPressedStartGame == true && mM.startGame == true || isPressedStartGame == true)
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
            return; 
        }
    }
}
