using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	ScoreController scoreCtrl;

	void Awake () {
		scoreCtrl = GetComponent<ScoreController>();
	}

	void OnScore (int score) {
		scoreCtrl.AddScore(score);
	}
}
