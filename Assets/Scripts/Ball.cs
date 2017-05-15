using UnityEngine;

public class Ball : MonoBehaviour {

	public float initialVelocity = 5;
	public AudioClip genericCollisionSound;
	public AudioClip brickCollisionSound;
	public AudioClip paddleCollisionSound;
	[Range(0f, 40f)]
	public float speed = 10;

	[HideInInspector]
	public bool launched = false;

	Rigidbody2D rb;
	AudioSource audioSrc;
	Follower2D follower;
	GameObject paddle;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		follower = GetComponent<Follower2D>();
		audioSrc = GetComponent<AudioSource>();
		paddle = GameObject.FindWithTag("Paddle");
	}

	void Start () {
		rb.isKinematic = true;
	}

	void OnCollisionEnter2D (Collision2D coll) {
		AudioClip hitSound;

		switch (coll.gameObject.tag) {
			case "Brick":
				hitSound = brickCollisionSound;
				break;
			case "Paddle":
				hitSound = paddleCollisionSound;
				break;
			default:
				hitSound = genericCollisionSound;
				break;
		}

		audioSrc.pitch = Random.Range(.9f, 1.1f);
		audioSrc.PlayOneShot(hitSound);
	}

	void OnMove (Vector3 newPos) {
		if (speed == 0) {
			transform.Translate(newPos);
		} else {
			float distance = Vector3.Distance(transform.position, newPos);
			float step = Time.deltaTime * speed * distance;

			transform.position = Vector3.MoveTowards(transform.position, newPos, step);
		}
	}

	public void Launch () {
		Debug.Log("[Ball] Launch()");

		if (launched) return;

		launched = true;
		follower.enabled = false;
		rb.isKinematic = false;
		rb.velocity += new Vector2(Random.Range(-1f, 1f), 1f) * initialVelocity;

		audioSrc.pitch = Random.Range(.9f, 1.1f);
		audioSrc.PlayOneShot(paddleCollisionSound);
	}

	public void Reset () {
		Debug.Log("[Ball] Reset()");
		rb.velocity = Vector2.zero;
		rb.isKinematic = true;
		launched = false;
		follower.enabled = true;
		transform.position = paddle.transform.position + new Vector3(0, .5f, 0);
	}
}
