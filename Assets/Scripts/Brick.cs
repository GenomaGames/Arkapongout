using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public static int count = 0;

	public bool inmortal = false;
	public int score = 50;
	[Range(0f, 1f)]
	public float powerUpChance = 0f;
	public GameObject[] powerUps;

	static GameObject powerUpContainer;

	GameController gameCtrl;

	void Awake () {
		gameCtrl = GameController.instance;

		if (powerUpContainer == null) {
			powerUpContainer = new GameObject("PowerUpsContainer");
		}

		if (!inmortal) {
			count++;
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (!inmortal && coll.gameObject.tag == "Ball") {
			count--;
			gameCtrl.SendMessage("OnBrickDestroyed", score);

			if (powerUpChance > 0 && powerUpChance >= Random.Range(0f, 1f)) {
				DropPowerUp();
			}

			Destroy(gameObject);
		}
	}

	void DropPowerUp () {
		if (powerUps.Length == 0) return;

		GameObject powerUp = powerUps[Random.Range(0, powerUps.Length - 1)];
		GameObject newPowerUp = Instantiate(powerUp, transform.position, Quaternion.identity);

		if (powerUpContainer != null) {
			newPowerUp.transform.parent = powerUpContainer.transform;
		}
	}
}
