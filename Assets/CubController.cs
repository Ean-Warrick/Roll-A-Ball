using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CubController : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float turnSpeed;
    private bool isGrounded;
    private int count;
    public TextMeshProUGUI countText;
    private Rigidbody m_rigidbody;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        this.m_rigidbody = GetComponent<Rigidbody>();
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded || !isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            this.m_rigidbody.AddForce(transform.right * acceleration * verticalInput);
            //transform.Translate(transform.forward * .1f * verticalInput);
            transform.Rotate(0, turnSpeed * horizontalInput, 0);
        }
        
       // if (!isGrounded)
        //{
           // var velocityy = this.m_rigidbody.velocity.y;
           // if (velocityy > -3f)
           // {
               // velocityy = -3f;
           // }
           // this.m_rigidbody.velocity = new Vector3(this.m_rigidbody.velocity.x, velocityy, this.m_rigidbody.velocity.z);
       // }
        target.transform.position = transform.position;
        target.transform.rotation = transform.rotation;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            InfoHandler.nextLevel();
        }

        var xzVelo = new Vector2(this.m_rigidbody.velocity.x, this.m_rigidbody.velocity.z);
        var magnitude = xzVelo.magnitude;
        var unit = xzVelo.normalized;
        if (magnitude > maxSpeed)
        {
            this.m_rigidbody.velocity = new Vector3(unit.x * maxSpeed, this.m_rigidbody.velocity.y, unit.y * maxSpeed);
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

    void SetCountText()
    {
        countText.text = $"Pins: {count}";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            count += 1;
            SetCountText();
        }
    }
}
