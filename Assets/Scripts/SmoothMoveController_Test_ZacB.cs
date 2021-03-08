using UnityEngine.InputSystem;
using UnityEngine.Experimental;
using UnityEngine;

public class SmoothMoveController_Test_ZacB : MonoBehaviour
{
    private Vector2 moveVector;
    private PlayerInput playerInput;
    private Rigidbody droneRB;
    public float droneSpeed;
    public float droneSpin; 
    [SerializeField] private InputActionAsset droneControls; // player control asset 

    public InputActionAsset controls; // Get Input Controls Asset 

    public InputAction moveAction; // input for WASD 
    public InputActionMap gamePlayAction; // input for GamePad  

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        droneRB = GetComponent<Rigidbody>();
        droneSpeed = 15;
        droneSpin = 35; 

        moveAction.performed += OnMoveAction; // subscribe action 
        moveAction.Enable(); // Enable action 

      //  moveAction = new InputAction("Move", binding: "2D Vector");

        var map = new InputActionMap("TestPlayer");
    }

    void MovePlayer()
    {
        Debug.Log("Moving Pllayer"); 
    }

    private void OnEnable()
    {
        moveAction.Enable(); // enable move action 
        gamePlayAction.Enable();
        controls.Enable(); 
    }

    private void OnDisable()
    {
        moveAction.Disable(); // disable move action 
        gamePlayAction.Disable();
        controls.Disable(); 
    }

    private void Update()
    {
        Debug.Log(moveAction.ReadValue<Vector2>()); // Test move action value inbput 
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Vector3 lastPos = new Vector3();
        lastPos.x = inputVector.x;
        lastPos.z = inputVector.y; 

        droneRB.AddForce(lastPos * Time.deltaTime * droneSpeed); // forward motion 

        Vector2 upVector = moveAction.ReadValue<Vector2>(); 
        if(inputVector.y > 0) 
        {
            droneRB.AddForce(inputVector * Time.deltaTime * droneSpeed * 2); // up motion 
        }
        else if (inputVector.y <= 0)
        {
            droneRB.AddForce(inputVector * Time.deltaTime * droneSpeed * 2); // down motion 
        }

        if(inputVector.x > 0) // spin motion right 
        {
            droneRB.AddTorque(inputVector * Time.deltaTime * droneSpin); 
        }
        else if (inputVector.x <= 0) // spin motion left 
        {
            droneRB.AddTorque(inputVector * Time.deltaTime * droneSpin);
        }

        var moveDir = moveAction.ReadValue<Vector2>();
        moveVector += moveDir * droneSpeed * Time.deltaTime; 
    }

    private void OnMoveAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            droneRB.AddForce(Vector3.forward * droneSpeed * Time.deltaTime);
        }
    }

    public void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        moveVector = new Vector3(inputVector.x, 0, inputVector.y); 
    }
}