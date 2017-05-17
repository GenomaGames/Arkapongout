using UnityEngine;

public class Paddle : MonoBehaviour {

	public int lifes = 3;
	public AudioClip powerUpSound;
	[Range(0f, 40f)]
	public float speed = 20;
	public float minXpos = -20;
	public float maxXpos = 20;

	AudioSource audioSrc;

	void Awake () {
		audioSrc = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "PowerUp") {
			Debug.Log("[Paddle] PowerUp Catched");
			ApplyPowerUp(other.gameObject);
		}
	}

	void OnMove (Vector3 newPos) {
		newPos = new Vector3(Mathf.Clamp(newPos.x, minXpos, maxXpos), transform.position.y, transform.position.z);

		if (speed == 0) {
			transform.Translate(newPos);
		} else {
			float distance = Vector3.Distance(transform.position, newPos);
			float step = Time.deltaTime * speed * distance;

			transform.position = Vector3.MoveTowards(transform.position, newPos, step);
		}
	}

	void ApplyPowerUp (GameObject powerUp) {
		PowerUp.Type type = powerUp.GetComponent<PowerUp>().type;

		if (type == PowerUp.Type.Enlarge) {
			Vector3 gain = new Vector3(.2f, 0, 0);

			transform.localScale += gain;
			audioSrc.pitch = Random.Range(.9f, 1.1f);
			audioSrc.PlayOneShot(powerUpSound);
		}

		Destroy(powerUp);
	}
}
