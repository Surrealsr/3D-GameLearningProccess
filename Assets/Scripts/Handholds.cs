using UnityEngine;

public class Handholds : MonoBehaviour, IInteractable
{
    public float detachJumpForce = 5f;
    public bool playerattached = false;
    public Rigidbody playerbody;
    public Transform handholdtp;
    public Player playerMovement;
    public float interactRange = 5f;

    public float InteractRange
    {
        get { return interactRange; }
    }

    public void Interact()
    {
        if (!playerattached)
        {
            AttachPlayer();
        }
    }


    void AttachPlayer()
    {
        playerbody.linearVelocity = Vector3.zero;
        playerbody.position = handholdtp.position;
        playerbody.useGravity = false;
        playerMovement.canMove = false;
        playerattached = true;
    }


    public void DetachPlayer()
    {
        if (!playerattached)
        {
            return;
        }

        playerattached = false;
        playerbody.useGravity = true;
        playerMovement.canMove = true;
        playerbody.linearVelocity = new Vector3(playerbody.linearVelocity.x,detachJumpForce,playerbody.linearVelocity.z);
    }
}
