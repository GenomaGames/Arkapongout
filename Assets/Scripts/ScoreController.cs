using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : Singleton<ScoreController> {

	public int score = 0;

	Text _scoreText;

	public Text scoreText {
		get {
			if (_scoreText == null) {
				GameObject go = GameObject.FindWithTag("Score");

				if (go != null) {
					_scoreText = go.GetComponent<Text>();
				}
			}

			return _scoreText;
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

	public void Subtract (int pScore) {
		score = score - pScore < 0 ? 0 : score - pScore;
	}

	public void UpdateUI () {
		if (scoreText != null) {
			scoreText.text = score.ToString("D6");
		}
	}
}
