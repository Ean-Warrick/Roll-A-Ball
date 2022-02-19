using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubController : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float turnSpeed;
    private float speed;
    private bool isGrounded;
    private Rigidbody m_rigidbody;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        this.m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        this.m_rigidbody.AddForce(transform.right * 6f * verticalInput);
        //transform.Translate(transform.forward * .1f * verticalInput);
        transform.Rotate(0, .15f * horizontalInput, 0);
        if (!isGrounded)
        {
            this.m_rigidbody.AddForce(0,-2,0);
        }
        target.transform.position = transform.position;
        target.transform.rotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            Debug.Log("Entered");
            isGrounded = true;
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            Debug.Log("Exited");
            isGrounded = false;
        }
    }
}
