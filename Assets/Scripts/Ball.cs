using UnityEngine;

public class Ball : MonoBehaviour {

	public float initialVelocity = 5;
	public AudioClip genericCollisionSound;
	public AudioClip brickCollisionSound;
	public AudioClip paddleCollisionSound;

	bool launched = false;
	Rigidbody2D rb;
	AudioSource audioSrc;
	MouseFollower2D mf;
	GameObject paddle;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		mf = GetComponent<MouseFollower2D>();
		audioSrc = GetComponent<AudioSource>();
		paddle = GameObject.FindGameObjectWithTag("Paddle");
	}

	void Start () {
		rb.isKinematic = true;
	}

	void Update () {
		if (!launched) {
			if (Input.GetMouseButtonDown(0)) {
				Launch();
			}
		}
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

	void Launch () {
		Debug.Log("[Ball] Launch()");
		launched = true;
		mf.enabled = false;
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
		mf.enabled = true;
		transform.position = paddle.transform.position + new Vector3(0, .5f, 0);
	}
}
