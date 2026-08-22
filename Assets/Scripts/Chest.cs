using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public Transform lidPivot;
    public float openAngle = 240f;
    private bool isOpen = false;
    public float interactRange = 2f;
    
    
    public float InteractRange
    {
        get { return interactRange; }
    }
    
    public void Interact()
    {
        if (isOpen)
        {
            lidPivot.localRotation = Quaternion.Euler(0, 0, 0);
            isOpen = false;
        }
        else
        {
            lidPivot.localRotation = Quaternion.Euler(openAngle, 0, 0);
            isOpen = true;
        }
    }
}