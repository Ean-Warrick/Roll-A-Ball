using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("MOVE");
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
