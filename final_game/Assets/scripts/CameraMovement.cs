using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    private float speed = 5;
    private float hbound = 3;
    private float vbound = 2.5f;
    private float offset = 7.5f;
    public float xpos;
    public float ypos;
    private GameObject player;
    private Vector3 temp;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(player.transform.position.x > transform.position.x)
            xpos = player.transform.position.x - transform.position.x;
        else
            xpos = transform.position.x - player.transform.position.x;

        if (player.transform.position.y > transform.position.y)
            ypos = player.transform.position.y - transform.position.y;
        else
            ypos = transform.position.y - player.transform.position.y;

        if (xpos >= hbound || ypos >= vbound)
        {
            temp = player.transform.position;
            temp.z = -10;
            temp.x += offset;

            transform.position = Vector3.MoveTowards(transform.position, temp, speed * Time.deltaTime);
        }
    }
}
