using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController> {

	void Awake () {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public void StartGame () {
		SceneController.LoadNext();
	}

	void OnBallOut () {
		SceneController.Load("Lose");
	}

	void OnBrickDestroyed (int score) {
		ScoreController.instance.Add(score);

		if (Brick.count == 0) {
			SceneController.Load("Win");
		}
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		if (scene.name.Contains("Game")) {
			ScoreController.instance.Init();
		}
	}
}
