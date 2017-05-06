using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int score = 50;

	GameController gameCtrl;

	void Awake () {
		gameCtrl = GameController.instance;
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Ball") {
			gameCtrl.SendMessage("OnScore", score);
			Destroy(gameObject);
		}
	}
}
