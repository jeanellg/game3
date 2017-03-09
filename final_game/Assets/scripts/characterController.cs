using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

    public float speed = 8.0f;
    public float jump = 300f;
    private bool grounded;
    private bool stunned;
    public Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        stunned = false;
    }

    void Update()
    {
        if (stunned == false)
        {
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            if (stunned)
                stunned = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            stunned = true;
        else
            grounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            stunned = false;
    }
}
