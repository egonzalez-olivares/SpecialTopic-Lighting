using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float cameraSpeed;
    public float jumpRate;
    public float maxPitch;
    public float minPitch;
    
    private float yaw = -90.0f;
    private float pitch = 0.0f;
    private Rigidbody rb;

    GameController gameController;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if(!gameController)
        {
            Debug.Log("GameController not found");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * v * moveSpeed * Time.deltaTime;
        Vector3 sidestep = transform.right * h * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement + sidestep);
        
    }

    private void Update()
    {
        yaw += cameraSpeed * Input.GetAxis("Mouse X");
        pitch -= cameraSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Goal":
                Debug.Log("Made it to the Exit Portal!");
                gameController.EndGame("Made it to the Exit Portal!");
                break;
            case "Pit":
                Debug.Log("You fell...");
                gameController.EndGame("You fell...");
                break;
            default:break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("You died");
            gameController.EndGame("You died");
        }
    }
}
