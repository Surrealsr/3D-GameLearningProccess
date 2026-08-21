using UnityEngine;
using UnityEngine.InputSystem;

public class Handholds : MonoBehaviour
{
    public InputActionReference interactAction;

    public float interactDistance = 4f;
    public float detachJumpForce = 5f;
    public bool playerattached = false;
    public Rigidbody playerbody;
    public Transform player;
    public Transform handholdtp;
    public InputActionReference moveAction;
    public Player playerMovement;

    void OnEnable()
    {
        interactAction.action.Enable();
    }


    void OnDisable()
    {
        interactAction.action.Disable();
    }


    void Update()
    {
        float distance = Vector3.Distance(player.position,transform.position);

        if ((distance <= interactDistance || playerattached) && interactAction.action.WasPressedThisFrame())
        {
            attachPlayer();
        }
    }


    


    void attachPlayer()
    {
        if (playerattached)
        {
            // GET OFF HANDHOLD
            
            playerattached = false;

            playerbody.isKinematic = false;
            playerbody.useGravity = true;

            playerMovement.canMove = true;

            playerbody.linearVelocity = new Vector3(playerbody.linearVelocity.x,detachJumpForce,playerbody.linearVelocity.z );
        }
        else
        {
            // GRAB HANDHOLD

            playerbody.linearVelocity = Vector3.zero;playerbody.position = handholdtp.position;
            playerMovement.canMove = false;
            playerbody.useGravity = false;
            playerbody.isKinematic = true;
            playerattached = true;
        }
    }
}
