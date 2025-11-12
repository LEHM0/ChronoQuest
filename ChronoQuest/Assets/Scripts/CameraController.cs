using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float sensitivity = 15f;
    public float yRot = 1f;
    public float xRot = 1f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Moves the Camera to the Player's POV
        transform.position = player.transform.position;

        yRot = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xRot = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.eulerAngles += new Vector3(yRot, xRot);
    }
}
