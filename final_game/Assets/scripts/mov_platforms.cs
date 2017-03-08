using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_platforms : MonoBehaviour {

	public bool hasInput;
	private Vector3 currentTouchPosition;
	public bool draggingItem;
	private Vector3 touchOffset;
	private Vector3 originalPosition;
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
		Vector3 inputPoint = new Vector3(RawinputPoint.x, RawinputPoint.y, RawinputPoint.z);
		if (draggingItem)
		{
			this.transform.position = inputPoint + touchOffset;
	//		Cursor.visible = false;

			if (xOff > 2) {
				drop_item ();
				float xReset = .2f;
				if ((this.transform.position.x - originalPosition.x) > 0)
					xReset = -.2f;
				this.transform.position = new Vector3(this.transform.position.x + xReset, this.transform.position.y, this.transform.position.z);
			}
			if (yOff > 2) {
				drop_item ();
				float yReset = .2f;
				if ((this.transform.position.y - originalPosition.y) > 0)
					yReset = -.2f;
				this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + yReset, this.transform.position.z);
			}
		}
		else
		{
			Ray ray = Camera.main.ScreenPointToRay (currentTouchPosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				if (hit.collider != null && GetComponent<Collider> () == hit.collider) {
					draggingItem = true;
					touchOffset = (Vector3)transform.position - inputPoint;
				}
			}
		}
	}

	void drop_item ()
	{
		draggingItem = false;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			touching = true;
		}

	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			touching = false;
		}
	}
}
