using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour {

	public AudioClip loseSound;

	GameController gameCtrl;

	void Awake () {
		gameCtrl = GameController.instance;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Ball") {
			AudioSource.PlayClipAtPoint(loseSound, Vector2.zero);
			gameCtrl.SendMessage("OnBallOut");
		}
	}
}
