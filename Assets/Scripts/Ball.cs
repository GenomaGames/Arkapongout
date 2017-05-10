using UnityEngine;

public class Ball : MonoBehaviour {

	public float initialVelocity = 5;

	Rigidbody2D rb;
	MouseFollower2D mf;
	bool launched = false;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		mf = GetComponent<MouseFollower2D>();
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
	}
}
