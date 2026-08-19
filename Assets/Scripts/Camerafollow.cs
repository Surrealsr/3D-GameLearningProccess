using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
