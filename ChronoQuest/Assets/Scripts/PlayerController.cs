using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jump = 5f;

    private Rigidbody rb;
    private bool isOnGround;

    void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.position = new Vector3(horizontalInput, 0 , verticalInput) * moveSpeed * Time.deltaTime;
    }
}
