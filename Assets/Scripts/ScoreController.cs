using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public int score = 0;

	// Use this for initialization
	void Start () {
		UpdateUI();
	}

	public void SetScore (int newScore) {
		score = newScore;
		UpdateUI();
	}

	public void AddScore (int pScore) {
		score +=pScore;
		UpdateUI();
	}

	void UpdateUI () {
		scoreText.text = score.ToString();
	}
}
