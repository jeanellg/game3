using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_2dplatforms : MonoBehaviour {


    public bool hasInput;
    private Vector3 currentTouchPosition;
    public bool draggingItem;
    private Vector2 touchOffset;
    private Vector2 originalPosition;
    private Vector2 limits_x;
    private Vector2 limits_y;
    public bool touching;
    public bool able;
    private float xOff;
    private float yOff;

    // Use this for initialization
    void Start()
    {
        hasInput = false;
        currentTouchPosition = Input.mousePosition;
        draggingItem = false;
        touching = false;
        originalPosition = this.transform.position;
        limits_y = new Vector2(this.transform.position.y - 2, this.transform.position.y + 2);
        limits_x = new Vector2(this.transform.position.x - 2, this.transform.position.x + 2);
        this.GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        able = GetComponentInParent<platforms>().moving;
        currentTouchPosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
            hasInput = true;
        else if (Input.GetMouseButtonUp(0))
        {
            hasInput = false;
            Cursor.visible = true;
        }

        if (hasInput && (!touching) && (able || draggingItem))
        {
            drag_or_pickup(); ;
        }
        else
        {
            if (draggingItem)
            {
                drop_item();
            }
        }
        xOff = Mathf.Abs(transform.position.x - originalPosition.x);
        yOff = Mathf.Abs(transform.position.y - originalPosition.y);
    }

    void drag_or_pickup()
    {
        Vector3 RawinputPoint = Camera.main.ScreenToWorldPoint(currentTouchPosition);
        Vector2 inputPoint = new Vector2(RawinputPoint.x, RawinputPoint.y);
        if (draggingItem)
        {
            Vector2 new_pos = inputPoint + touchOffset;
            this.transform.position = new Vector2(Mathf.Clamp(new_pos.x, limits_x.x, limits_x.y), Mathf.Clamp(new_pos.y, limits_y.x, limits_y.y));
            Cursor.visible = false;
            this.GetComponent<Renderer>().material.color = Color.yellow;

            if (xOff > 2)
            {
                drop_item();
                float xReset = .2f;
                if ((this.transform.position.x - originalPosition.x) > 0)
                    xReset = -.2f;
                this.transform.position = new Vector2(this.transform.position.x + xReset, this.transform.position.y);
            }
            if (yOff > 2)
            {
                drop_item();
                float yReset = .2f;
                if ((this.transform.position.y - originalPosition.y) > 0)
                    yReset = -.2f;
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + yReset);
            }
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2)Camera.main.ScreenToWorldPoint(currentTouchPosition), Vector2.zero);
            if (hit.collider != null && GetComponent<Collider2D>() == hit.collider)
            {
                draggingItem = true;
                GetComponentInParent<platforms>().moving = false;
                touchOffset = (Vector2)transform.position - inputPoint;
            }
        }
    }

    void drop_item()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
        draggingItem = false;
        GetComponentInParent<platforms>().moving = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            touching = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            touching = false;
        }
    }
}
