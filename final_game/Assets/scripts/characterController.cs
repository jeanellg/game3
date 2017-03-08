using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

    public float speed = 8.0f;
    public float jump = 300f;
    private bool grounded;
    public Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(grounded == false && rbody.velocity.y == 0f)
            grounded = true;

            float horizontal = Input.GetAxis("Horizontal") * speed;
            horizontal *= Time.deltaTime;

            transform.Translate(horizontal, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rbody.AddForce(transform.up * jump);
            grounded = false;
        }
    }
}
