using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Rigidbody Playerbody;
    public float Playerspeed = 10f;
    public Transform cameratransform;
    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public float jumpForce = 8f;
    public bool isGrounded;
    public LayerMask groundLayer;
    public float groundCheckDistance = 1.1f;
    public bool canMove = true;
    public float gravityMultiplier = 1.5f;

    void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void RotatePlayer()
    {
        Vector3 cameraForward = cameratransform.forward;

        cameraForward.y = 0;

        transform.rotation = Quaternion.LookRotation(cameraForward);
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        RotatePlayer();

        if (jumpAction.action.WasPressedThisFrame() && isGrounded)
        {
            jump();
        }
    }
    void jump()
    {
        Playerbody.linearVelocity = new Vector3(Playerbody.linearVelocity.x, jumpForce, Playerbody.linearVelocity.z);
        isGrounded = false;
    }
    void FixedUpdate()
    {
        
        
        if (!canMove || !isGrounded)
        {
            return;
        }

        Playerbody.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        float x = moveInput.x;
        float z = moveInput.y;
        // Find out what direction the camera is facing either in the z,x and whats to the right of the camera either x,z
        Vector3 cameraForward = cameratransform.forward; 
        Vector3 cameraRight = cameratransform.right;
        // Makes it so camera ignores y axis
        cameraForward.y = 0;
        cameraRight.y = 0;
        // makes it so diagonal movement doesn't increase your speed.
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        //Multiplies input by the vector3 z and x of the camera.
        Vector3 direction =
            (cameraForward * z + cameraRight * x).normalized;
        //this actually makes the player move.
        Playerbody.linearVelocity = new Vector3
        (direction.x * Playerspeed,Playerbody.linearVelocity.y,direction.z * Playerspeed);
        
    }

}
