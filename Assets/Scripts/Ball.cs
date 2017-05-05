using UnityEngine;

public class Ball : MonoBehaviour {

	public float initialVelocity = 5;

	Rigidbody2D rb;
	bool launched = false;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Start () {
		rb.isKinematic = true;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) && !launched) {
			Launch();
		}
	}

	void Launch () {
		launched = true;
		rb.isKinematic = false;
		rb.velocity += Vector2.one * initialVelocity;
	}
}
