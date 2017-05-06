using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public static int count = 0;

	public int score = 50;

	GameController gameCtrl;

	void Awake () {
		gameCtrl = GameController.instance;

		count++;
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Ball") {
			count--;
			gameCtrl.SendMessage("OnBrickDestroyed", score);
			Destroy(gameObject);
		}
	}
}
