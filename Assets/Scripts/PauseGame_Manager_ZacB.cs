using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PauseGame_Manager_ZacB : MonoBehaviour
{
    [SerializeField] public InputAction playerInput;
    public InputActionAsset playerControls;
    public InputActionMap actionMap; 
    public GameObject optionsMenu;
    public bool menuEnabled; 

    private void Awake()
    {
        actionMap.AddBinding("<Keyboard>/PauseGameEscape"); 
    }

    private void Start()
    {
        playerInput.performed += OnPauseGameEscape;
        menuEnabled = false; 
    }

    private void OnEnable()
    {
        actionMap.actionTriggered += OnPauseGameEscape;
        actionMap.FindAction("PauseGameEscape").performed += PauseGame_Manager_performed;
        actionMap.Enable();
    }

    private void OnDisable()
    {
        menuEnabled = false; 
        actionMap.Disable();
    }

    public virtual void OnPauseGameEscape(InputAction.CallbackContext context)
    {
        if(playerInput.id.ToString().Length > 0)
        {
            if (menuEnabled)
            {
                Debug.Log("Pressed Esc");
                Time.timeScale = 0;
                optionsMenu.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1; 
                optionsMenu.gameObject.SetActive(false);
            }
        } 
    }

    private void PauseGame_Manager_performed(InputAction.CallbackContext obj)
    {
        menuEnabled = !menuEnabled; 
        obj.performed.Equals(true); 
    }

    public virtual void OnUnPauseGameEscape(InputAction.CallbackContext context)
    {
        if (playerControls.actionMaps.Count > 0)
        {
            Debug.Log("Pressed Esc Again");
            optionsMenu.gameObject.SetActive(false);
        }
    }

    private void PauseGame_Manager_unperformed(InputAction.CallbackContext obj)
    {
        menuEnabled = false; 
        optionsMenu.gameObject.SetActive(false);
        obj.performed.Equals(false);
    }
}
