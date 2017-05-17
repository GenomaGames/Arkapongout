using UnityEngine;

public class InputController : Singleton<InputController> {

	public bool inMenu = true;

  GameObject paddle;

  void Awake () {
    paddle = GameObject.FindWithTag("Paddle");
  }

  void Update () {
    if (!inMenu) {
      Follower2D follower = paddle.GetComponent<Follower2D>();

      if (Input.GetAxis("Horizontal") != 0) {
        if (follower.enabled) {
          follower.enabled = false;
        }

        Debug.Log("[Input] Horizontal");
        Vector3 newPos = paddle.transform.position;
        newPos += new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        paddle.SendMessage("OnMove", newPos, SendMessageOptions.DontRequireReceiver);
      }

      if (Input.GetButtonDown("Fire1")) {
        if (!follower.enabled) {
          follower.enabled = true;
        }
      }

      if (Input.GetButtonDown("Submit")) {
        Ball ball = GameObject.FindWithTag("Ball") ? GameObject.FindWithTag("Ball").GetComponent<Ball>() : null;

        if (ball != null && !ball.launched) {
          ball.Launch();
        }
      }
    }
  }
}
