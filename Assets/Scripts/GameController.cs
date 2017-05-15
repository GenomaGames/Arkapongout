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
			LoseGame();
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
			Invoke("WinGame", 1.5f);
		}
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		if (scene.name.Contains("Game")) {
			GameSetup();
		} else {
			MenuSetup();
		}
	}

	void GameSetup () {
		InputController.instance.inMenu = false;
		ScoreController.instance.Init();
		paddle = GameObject.FindWithTag("Paddle") ? GameObject.FindWithTag("Paddle").GetComponent<Paddle>() : null;
		ball = GameObject.FindWithTag("Ball") ? GameObject.FindWithTag("Ball").GetComponent<Ball>() : null;
	}

	void MenuSetup () {
		InputController.instance.inMenu = true;
		ScoreController.instance.UpdateUI();
	}

	void WinGame () {
		SceneController.Load("Win");
	}

	void LoseGame () {
		SceneController.Load("Lose");
	}
}
