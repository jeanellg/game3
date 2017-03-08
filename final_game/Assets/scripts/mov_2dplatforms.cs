using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_2dplatforms : MonoBehaviour {

	public bool hasInput;
	private Vector3 currentTouchPosition;
	public bool draggingItem;
	private Vector2 touchOffset;
	private Vector2 originalPosition;
	public bool touching;
	private float xOff;
	private float yOff;

	// Use this for initialization
	void Start () {
		hasInput = false;
		currentTouchPosition = Input.mousePosition;
		draggingItem = false;
		touching = false;
		originalPosition = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		currentTouchPosition = Input.mousePosition;
		if (Input.GetMouseButtonDown (0))
			hasInput = true;
		else if (Input.GetMouseButtonUp (0)) {
			hasInput = false;
			Cursor.visible = true;
		}

		if (hasInput && !touching)
			drag_or_pickup();
		else
		{
			if (draggingItem)
				drop_item();
		}
		xOff = Mathf.Abs (transform.position.x - originalPosition.x);
		yOff = Mathf.Abs (transform.position.y - originalPosition.y);
	}

	void drag_or_pickup()
	{
		Vector3 RawinputPoint = Camera.main.ScreenToWorldPoint(currentTouchPosition);
		Vector2 inputPoint = new Vector2(RawinputPoint.x, RawinputPoint.y);
		if (draggingItem)
		{
			this.transform.position = inputPoint + touchOffset;
	//		Cursor.visible = false;

			if (xOff > 2) {
				drop_item ();
				float xReset = .2f;
				if ((this.transform.position.x - originalPosition.x) > 0)
					xReset = -.2f;
				this.transform.position = new Vector2(this.transform.position.x + xReset, this.transform.position.y);
			}
			if (yOff > 2) {
				drop_item ();
				float yReset = .2f;
				if ((this.transform.position.y - originalPosition.y) > 0)
					yReset = -.2f;
				this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + yReset);
			}
		}
		else
		{
			RaycastHit2D hit = Physics2D.Raycast((Vector2)Camera.main.ScreenToWorldPoint(currentTouchPosition),Vector2.zero);
			if (hit.collider != null && GetComponent<Collider2D> () == hit.collider) {
				draggingItem = true;
				touchOffset = (Vector2)transform.position - inputPoint;
			}
		}
	}

	void drop_item ()
	{
		draggingItem = false;
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
