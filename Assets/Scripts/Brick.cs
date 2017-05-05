using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int score = 50;

	GameObject gameCtrl;

	void Awake () {
		gameCtrl = GameObject.FindWithTag("GameController");
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Ball") {
			gameCtrl.SendMessage("OnScore", score);
			Destroy(gameObject);
		}
	}
}
