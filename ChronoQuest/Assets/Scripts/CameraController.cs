using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        // Moves the Camera to the Player's POV
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }
}
