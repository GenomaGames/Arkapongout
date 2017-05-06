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

	void OnScore (int score) {
		ScoreController.instance.Add(score);
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		if (scene.name.Contains("Game")) {
			ScoreController.instance.Init();
		}
	}
}
