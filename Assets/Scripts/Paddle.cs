using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autopilot = false;

	GameObject ball;

	void Awake () {
		ball = GameObject.FindGameObjectWithTag("Ball");
	}

	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (autopilot) {
			if (GetComponent<MouseFollower2D>() != null && GetComponent<MouseFollower2D>().enabled) {
				GetComponent<MouseFollower2D>().enabled = false;
			}

			if (Mathf.Abs(ball.GetComponent<Rigidbody2D>().velocity.x) > .5f) {
				transform.position = new Vector2(ball.transform.position.x, transform.position.y);
			} else {
				transform.position = new Vector2(ball.transform.position.x - .9f, transform.position.y);
			}
		} else if (GetComponent<MouseFollower2D>() != null && !GetComponent<MouseFollower2D>().enabled) {
			GetComponent<MouseFollower2D>().enabled = true;
		}
	}
}
