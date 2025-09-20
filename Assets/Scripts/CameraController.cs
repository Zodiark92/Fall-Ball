using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 3.79f, -3.82f);
    public Vector3 arenaOffset = new Vector3(0f, 12.66f, -15.41f);
    private Vector3 rotation = new Vector3(26f, 0, 0);

    private Transform playerPos;
    private Transform bossPos;
    private PlayerController playerController;

    private float rotationSpeed = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        bossPos = GameObject.FindWithTag("Boss").transform;

    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();

    }

    public void TranslateCamera() {

        Vector3.Lerp(offset, arenaOffset, 0.5f);
        offset = arenaOffset;
    }

    private void CameraMovement() {
        transform.position = playerPos.position + offset;

        float mouseInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * mouseInput, Space.World);

    }
}
