using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public Transform cameraTransform;
    public InputActionReference interactAction;
    public float interactDistance = 3f;

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
        if (interactAction.action.WasPressedThisFrame())
        {
            Interact();
        }
    }

    void Interact()
    {
        RaycastHit hit;

        if (Physics.Raycast(cameraTransform.position,cameraTransform.forward,out hit,interactDistance))
        {
            Chest chest = hit.collider.GetComponentInParent<Chest>();

            if (chest != null)
            {
                chest.ToggleChest();
            }
        }
    }
}
