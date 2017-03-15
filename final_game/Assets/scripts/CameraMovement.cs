using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    private float speed = 8;
    private float hbound = 2.6f;
    private float vbound = 3f;
    private float offset = 8f;
    public float xpos;
    public float ypos;
    private GameObject player;
    private Rigidbody2D rbody;
    private Vector3 temp;
    private bool moving;


	// Use this for initialization
	void Start () {
        moving = false;
        player = GameObject.FindGameObjectWithTag("Player");
        rbody = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rbody.velocity.y <= -3f)
            speed = 15;
        else
            speed = 8;


        if(player.transform.position.x > transform.position.x)
            xpos = player.transform.position.x - transform.position.x;
        else
            xpos = transform.position.x - player.transform.position.x;

        if (player.transform.position.y > transform.position.y)
            ypos = player.transform.position.y - transform.position.y;
        else
            ypos = transform.position.y - player.transform.position.y;

        if ((xpos - offset) >= hbound || ypos >= vbound)
        {
            moving = true;
        }


        if (moving)
        {
            temp = player.transform.position;
            temp.z = -10;
            temp.x += offset;

            transform.position = Vector3.MoveTowards(transform.position, temp, speed * Time.deltaTime);
            if(transform.position == temp)
            {
                moving = false;
            }
        } 
    }
}
