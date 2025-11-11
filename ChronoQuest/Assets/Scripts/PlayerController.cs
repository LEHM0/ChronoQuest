using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 1f;
    public float jump = 1f;
    public bool isOnGround = true;

    private Rigidbody playerRb;
    //private bool isOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput); //+ Vector3.forward * verticalInput);
        transform.Translate(Vector3.forward * verticalInput);
        //Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;
        //player.transform.position = movement * moveSpeed * Time.deltaTime;

        // Jump Physics
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ensures the Player can only jump again after touching the Ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
