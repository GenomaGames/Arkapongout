using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour {

	GameController gameCtrl;

	void Awake () {
		gameCtrl = GameController.instance;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Ball") {
			gameCtrl.SendMessage("OnBallOut");
		}
	}
}
