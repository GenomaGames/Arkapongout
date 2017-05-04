using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower2D : MonoBehaviour {

	public bool followY = true;
	public bool followX = true;
	public bool insideScreen = true;
	public Vector2 offset = Vector2.zero;
	public Vector2 boundaries = Vector2.one;
	public float speed = 0;

	Camera cam;

	void Start () {
		cam = Camera.main;
	}

	void Update () {
		float posY = transform.position.y;
		float posX = transform.position.x;
		Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

		if (followY) posY = mousePos.y + offset.y;
		if (followX) posX = mousePos.x + offset.x;

		if (insideScreen) {
			Vector3 viewportZero = cam.ViewportToWorldPoint(Vector2.zero);
			Vector3 viewportOne = cam.ViewportToWorldPoint(Vector2.one);

			if (followY) {
				float top = posY + (boundaries.y / 2);
				float bottom = posY - (boundaries.y / 2);

				if (viewportZero.y > bottom) {
					posY = viewportZero.y + (boundaries.y / 2);
				}

				if (viewportOne.y < top) {
					posY = viewportOne.y - (boundaries.y / 2);
				}

			}

			if (followX) {
				float right = posX + (boundaries.x / 2);
				float left = posX - (boundaries.x / 2);

				if (viewportZero.x > left) {
					posX = viewportZero.x + (boundaries.x / 2);
				}

				if (viewportOne.x < right) {
					posX = viewportOne.x - (boundaries.x / 2);
				}
			}
		}

		Vector3 newPos = new Vector3(posX, posY, transform.position.z);

		if (speed == 0) {
			transform.position = newPos;
		} else {
			float distance = Vector3.Distance(transform.position, newPos);
			float step = Time.deltaTime * speed * distance;

			transform.position = Vector3.MoveTowards(transform.position, newPos, step);
		}
	}

	void OnDrawGizmosSelected () {
		 Gizmos.color = Color.yellow;
		 Gizmos.DrawWireCube(transform.position + (Vector3)offset, boundaries);
	}
}
