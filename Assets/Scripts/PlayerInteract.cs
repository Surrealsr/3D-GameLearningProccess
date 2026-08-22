using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float maxInteractRange = 10f;
    public InputActionReference interactAction;
    public InputActionReference detachAction;
    private Handholds currentHandhold;


    void OnEnable()
    {
        interactAction.action.Enable();
        detachAction.action.Enable();
    }


    void OnDisable()
    {
        interactAction.action.Disable();
        detachAction.action.Disable();
    }

    void Update()
    {
        if (interactAction.action.WasPressedThisFrame())
        {
            Interact();
        }


        if (currentHandhold != null && currentHandhold.playerattached && detachAction.action.WasPressedThisFrame())
        {
            currentHandhold.DetachPlayer();
            currentHandhold = null;
        }
    }

    void Interact()
    {
        Ray r = new Ray(InteractorSource.position,InteractorSource.forward);

        if (Physics.Raycast(r, out RaycastHit hitInfo, maxInteractRange))
        {
            IInteractable interactObj = hitInfo.collider.GetComponentInParent<IInteractable>();
            
            if (interactObj != null && hitInfo.distance <= interactObj.InteractRange)
            {
                interactObj.Interact();

                Handholds handhold = hitInfo.collider.GetComponentInParent<Handholds>();

                if (handhold != null && handhold.playerattached)
                {
                    currentHandhold = handhold;
                }
            }
        }
    }
}