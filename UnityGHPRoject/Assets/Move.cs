using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float movementForce = 10.0f;
    public float jumpForce = 30.0f;

    public float maxMovementVelocity = 5.0f;
    public float maxJumpVelocity = 2.0f;
    private Rigidbody rb = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        // transform.Translate(xTranslate, 0.0f, 0.0f);
        
    }
    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.W))
        {
            dir.x = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir.z = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
        
            dir.z = 1.0f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            dir.y = 1.0f;
        }
        Vector3 jumpDir = gameObject.transform.up * dir.y * jumpForce;
        Vector3 strafe = gameObject.transform.right * dir.z * movementForce;
        Vector3 forceDir = gameObject.transform.forward * dir.x * movementForce;

       
        rb.AddForce((jumpDir + forceDir + strafe) * Time.fixedDeltaTime, ForceMode.Impulse);

        rb.angularVelocity = new Vector3(0.0f,0.0f,0.0f);

        //Mathf.Clamp(rb.velocity.y, maxJumpVelocity);
        //Mathf.Clamp(rb.velocity.x, maxMovementVelocity);
        //Mathf.Clamp(rb.velocity.z, rb.velocity.z, maxMovementVelocity);
    }
}
