using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //1st person playercontrller using new input system
    [Header("Actions")]
    [SerializeField] InputActionReference moveAction;
    [SerializeField] InputActionReference lookAction;
    [SerializeField] InputActionReference jumpAction;

    [Header("Config")]
    [SerializeField] GameObject camHolder;
    [SerializeField] float speed;
    [SerializeField] float sensitivity;
    [SerializeField] float maxForce;
    [SerializeField] float jumpForce;

    Rigidbody rb;
    Vector2 move, look;
    float lookRotation;
    bool grounded;

    private void Awake()
    {
        moveAction.action.performed += OnMove;
        moveAction.action.canceled += OnMove;

        lookAction.action.performed += OnLook;
        lookAction.action.canceled += OnLook;

        jumpAction.action.performed += OnJump;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;   //Hides the cursor, if stuck in play mode press ESC to exit
        Cursor.visible = false;
    }

    private void FixedUpdate()          //using fixed instead of regular update cause we are using rigidbody -> fixed better for physics
    {
        MovePlayer();
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MovePlayer()
    {
        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);
        targetVelocity *= speed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = targetVelocity - currentVelocity;
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        velocityChange = Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void MoveCamera()
    {
        transform.Rotate(Vector3.up * look.x * sensitivity);      //X-Axis of mouse times sens and upwards to rotate on y axis

        lookRotation += -look.y * sensitivity;
        lookRotation = Mathf.Clamp(lookRotation, -70, 90);

        camHolder.transform.localRotation = Quaternion.Euler(lookRotation, 0, 0);
    }

    void JumpPlayer()
    {
        Vector3 jumpVector = Vector3.zero;

        if (grounded)
        {
            jumpVector = Vector3.up * jumpForce;
        }

        rb.AddForce(jumpVector, ForceMode.VelocityChange);
    }

    public void SetGrounded(bool state)
    {
        grounded = state;
    }

    public void OnMove(InputAction.CallbackContext context)     //This is the setup for events using inputactions, basically this gets called each time inputs change
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)     //This is the setup for events using inputactions, basically this gets called each time inputs change
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)     //This is the setup for events using inputactions, basically this gets called each time inputs change
    {
        JumpPlayer();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        lookAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        lookAction.action.Disable();
        jumpAction.action.Disable();
    }

    private void OnDestroy()
    {
        moveAction.action.performed -= OnMove;
        lookAction.action.performed -= OnLook;
        moveAction.action.canceled -= OnMove;
        lookAction.action.canceled -= OnLook;

        jumpAction.action.performed -= OnJump;
    }
}
