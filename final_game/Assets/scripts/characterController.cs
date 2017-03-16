using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
	public AudioClip attackSound;
	public AudioClip jumpSound;
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
				this.GetComponent<AudioSource> ().PlayOneShot (jumpSound);
                rbody.AddForce(transform.up * jump);

                if (rbody.velocity.y > 1.5f)
                {
                    rbody.velocity = new Vector2(1, 1.5f);
                }

                grounded = false;
            }

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
			this.GetComponent<AudioSource> ().PlayOneShot (attackSound);
            Destroy(collision.gameObject);
            if (stunned)
                stunned = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            stunned = true;
        else if (collision.gameObject.tag == "Platform")
            grounded = true;
        else if (rbody.velocity.y == 0)
            grounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            stunned = false;
    }
}
