using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float turnSpeed;
    private float speed;
    private bool isGrounded;
    private Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        this.m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            //float horizontalInput = Input.GetAxis("Horizontal");
            //float verticalInput = Input.GetAxis("Vertical");
            //this.m_rigidbody.AddForce(transform.forward.x * 15 * verticalInput, 0, transform.forward.z * 15 * verticalInput);
            //transform.Translate(transform.up * verticalInput * .1f);
            //transform.Rotate(.1f * horizontalInput, 0, 0);

        }

        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q!!!");
        }
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Track")) {
            Debug.Log("Entered");
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Track")) {
            Debug.Log("Exited");
            isGrounded = false;
        }
    }
}
