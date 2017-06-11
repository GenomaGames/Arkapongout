using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWall : MonoBehaviour {

	public int activeSeconds;

	Animator anim;
	BoxCollider2D bc2d;
	bool active = false;

	void Start () {
		anim = GetComponent<Animator>();
		bc2d = GetComponent<BoxCollider2D>();
		bc2d.enabled = false;
	}

	void OnCollisionExit2D (Collision2D coll) {
		if (coll.gameObject.tag == "Ball") {
			StopCoroutine("ActiveTimeout");
			Deactivate();
		}
	}

	public void Activate () {
		if (!active) {
			active = true;
			anim.SetBool("Active", active);
		} else {
			StopCoroutine("ActiveTimeout");
		}

		StartCoroutine("ActiveTimeout");
	}

	public void Deactivate () {
		active = false;
		anim.SetBool("Active", active);
	}

	IEnumerator ActiveTimeout () {
		yield return new WaitForSeconds(activeSeconds);
		Deactivate();
	}
}
