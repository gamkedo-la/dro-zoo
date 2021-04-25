using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;


public class EnterPowerRoom : MonoBehaviour
{

    [SerializeField]
    private int scenenumber;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            StartCoroutine(LoadPowerRoomScene()); 
            SceneManager.LoadSceneAsync(scenenumber);
            return; 
        }
    }

    private IEnumerator LoadPowerRoomScene()
    {
        yield return new WaitForSeconds(3.0f); 
    }
}
