using UnityEngine;

public class Chest : MonoBehaviour
{
    public Transform lidPivot;
    public float openAngle = 240f;
    private bool isOpen = false;

    public void ToggleChest()
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