using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            this.m_rigidbody.AddForce(transform.right * 6f * verticalInput);
            //transform.Translate(transform.forward * .1f * verticalInput);
            transform.Rotate(0, .15f * horizontalInput, 0);
        }
        
        if (!isGrounded)
        {
            var velocityy = this.m_rigidbody.velocity.y;
            if (velocityy > -3f)
            {
                velocityy = -3f;
            }
            this.m_rigidbody.velocity = new Vector3(this.m_rigidbody.velocity.x, velocityy, this.m_rigidbody.velocity.z);
        }
        target.transform.position = transform.position;
        target.transform.rotation = transform.rotation;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            InfoHandler.nextLevel();
        }

        var speed = 20;
        var xzVelo = new Vector2(this.m_rigidbody.velocity.x, this.m_rigidbody.velocity.z);
        var magnitude = xzVelo.magnitude;
        var unit = xzVelo.normalized;
        if (magnitude > speed)
        {
            this.m_rigidbody.velocity = new Vector3(unit.x* speed, this.m_rigidbody.velocity.y, unit.y * speed);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            Debug.Log("Entered");
            isGrounded = true;
        } else if (other.gameObject.CompareTag("Void"))
        {
            Debug.Log("Void");
            SceneManager.LoadScene(0);
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
