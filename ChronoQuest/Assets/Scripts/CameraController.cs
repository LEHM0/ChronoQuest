using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Camera Controller script provided by ChatGPT

    public GameObject player;
    public float sensitivity = 150f;
    public float minSensitivity = 10f;
    public float maxSensitivity = 500f;
    public float sensitivityStep = 10f;

    public float pitch = 0f;
    public float yaw = 0f;
    public float minPitch = -89f;
    public float maxPitch = 89f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Initialize from current rotation so camera doesn't jump on start
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void Update()
    {
        // Adjust sensitivity at runtime:
        // - Mouse wheel (small changes)
        // - Plus/Minus keys (bigger steps)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > Mathf.Epsilon)
        {
            sensitivity += scroll * sensitivityStep * 5f;
        }

        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            sensitivity += sensitivityStep;
        }
        else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            sensitivity -= sensitivityStep;
        }

        sensitivity = Mathf.Clamp(sensitivity, minSensitivity, maxSensitivity);

        // Move camera to player's POV
        transform.position = player.transform.position;

        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // Invert Y so moving the mouse up looks up
        pitch -= mouseY;
        yaw += mouseX;

        // Prevent flipping over
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
