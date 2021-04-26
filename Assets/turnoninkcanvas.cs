using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class turnoninkcanvas : MonoBehaviour
{
    
    [SerializeField]
    private Canvas inkcanvas;
    //[SerializeField]
    // private TextAsset inkJSONAsset = null; 
    [SerializeField] private dockcable dockingCable; 

    void OnTriggerEnter(Collider other)
    {
        inkcanvas.enabled = true;
        Debug.Log("inkcanvas should be enabled");
        if(dockingCable.isGrown == true)
        {
            StartCoroutine(TempReturnToMenu()); 
        }
    }

/* void OnTriggerExit(Collider other)
    {
        inkcanvas.enabled = false;
    } */

    IEnumerator TempReturnToMenu()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene("Main_Manu"); 
        yield return null; 
    }
}
