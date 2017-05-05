using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public int score = 0;

	void Start () {
		if (GameObject.FindWithTag("Score") != null) {
			scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
		}

		UpdateUI();
	}

	public void Init () {
		if (GameObject.FindWithTag("Score") != null) {
			scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
		}

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

	void UpdateUI () {
		if (scoreText != null) {
			scoreText.text = score.ToString("D6");
		}
	}
}
