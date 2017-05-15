using UnityEngine;

public class PaddleIA : MonoBehaviour {

  GameObject ball;

	void Awake () {
		ball = GameObject.FindWithTag("Ball");
	}

	void Update () {
    if (Mathf.Abs(ball.GetComponent<Rigidbody2D>().velocity.x) > .5f) {
      transform.position = new Vector2(ball.transform.position.x, transform.position.y);
    } else {
      transform.position = new Vector2(ball.transform.position.x - .9f, transform.position.y);
    }
  }
}
