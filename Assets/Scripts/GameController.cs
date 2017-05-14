using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController> {

	Paddle paddle;
	Ball ball;

	void Awake () {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public void StartGame () {
		SceneController.LoadNext();
	}

	void CheckLifes () {
		if (paddle.lifes == 0) {
			SceneController.Load("Lose");
		} else {
			ball.Reset();
		}
	}

	void OnBallOut () {
		paddle.lifes--;
		Invoke("CheckLifes", 1.5f);
	}

	void OnBrickDestroyed (int score) {
		ScoreController.instance.Add(score);

		if (Brick.count == 0) {
			Invoke("Win", 1.5f);
		}
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		if (scene.name.Contains("Game")) {
			ScoreController.instance.Init();
			paddle = GameObject.FindGameObjectWithTag("Paddle").GetComponent<Paddle>();
			ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
		} else {
			ScoreController.instance.UpdateUI();
		}
	}

	void Win () {
		SceneController.Load("Win");
	}
}
