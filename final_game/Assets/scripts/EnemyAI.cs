using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private bool landed = false;
    private Vector3 platform;
    private int direction = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            landed = true;
        }

		if (landed == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(3 * direction, 0));
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        platform = collision.transform.position;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
        direction *= -1;
    }
}
