using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isArena;
    public float speed = 10.0f;
    public float jumpForce = 20f;
    public float gravityModifier = 2.5f;
    private bool onGround = true;

    private Rigidbody playerBody;
    private CameraController camera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement() {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        

        playerBody.AddForce(horizontalInput * speed * Vector3.right);

        if (isArena) 
        {
            playerBody.AddForce(verticalInput * speed * Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround) {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arena"))
        {

            isArena = true;
            onGround = true;
            playerBody.linearVelocity = Vector3.zero;
            camera.TranslateCamera();
        }
        else if (collision.gameObject.CompareTag("Ground")) {
            onGround = true;
        }
    }
}
