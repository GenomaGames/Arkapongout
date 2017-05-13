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

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		mf = GetComponent<MouseFollower2D>();
		audioSrc = GetComponent<AudioSource>();
	}

	void Start () {
		rb.isKinematic = true;
	}

	void Update () {
		if (!launched) {
			if (Input.GetMouseButtonDown(0)) {
				Launch();
				Debug.Log(Random.Range(-1f, 1f));
			}
		}
	}

	void Launch () {
		launched = true;
		mf.enabled = false;
		rb.isKinematic = false;
		rb.velocity += new Vector2(Random.Range(-1f, 1f), 1f) * initialVelocity;

		audioSrc.pitch = Random.Range(.9f, 1.1f);
		audioSrc.PlayOneShot(paddleCollisionSound);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		AudioClip hitSound;

		Debug.Log(coll.gameObject.tag);

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
}
