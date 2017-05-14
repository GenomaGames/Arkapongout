using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : Singleton<ScoreController> {

	public int score = 0;

	Text _scoreText;

	public Text scoreText {
		get {
			if (_scoreText != null) {
				return _scoreText;
			} else {
				GameObject go = GameObject.FindGameObjectWithTag("Score");

				if (go != null) {
					return go.GetComponent<Text>();
				} else {
					return null;
				}
			}
		}
	}

	public void Init () {
		score = 0;
		UpdateUI();
	}

	public void Set (int newScore) {
		score = newScore;
		UpdateUI();
	}

	public void Add (int pScore) {
		score += pScore;
		UpdateUI();
	}

	public void UpdateUI () {
		if (scoreText != null) {
			scoreText.text = score.ToString("D6");
		}
	}
}
