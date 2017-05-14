using UnityEngine;

public class Paddle : MonoBehaviour {

	public int lifes = 3;
	public bool autopilot = false;
	public AudioClip powerUpSound;

	GameObject ball;
	MouseFollower2D mf;
	AudioSource audioSrc;

	void Awake () {
		ball = GameObject.FindGameObjectWithTag("Ball");
		mf = GetComponent<MouseFollower2D>();
		audioSrc = GetComponent<AudioSource>();
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

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "PowerUp") {
			Debug.Log("[Paddle] PowerUp Catched");
			ApplyPowerUp(other.gameObject);
		}
	}

	void ApplyPowerUp (GameObject powerUp) {
		PowerUp.Type type = powerUp.GetComponent<PowerUp>().type;

		if (type == PowerUp.Type.Enlarge) {
			Vector3 gain = new Vector3(.2f, 0, 0);

			transform.localScale += gain;
			mf.boundaries += (Vector2)gain;
			audioSrc.pitch = Random.Range(.9f, 1.1f);
			audioSrc.PlayOneShot(powerUpSound);
		}

		Destroy(powerUp);
	}
}
