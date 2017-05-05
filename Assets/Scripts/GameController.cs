using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance = null;

	ScoreController scoreCtrl;
	SceneController sceneCtrl;

	void Awake () {
		Init();

		scoreCtrl = GetComponent<ScoreController>();
		sceneCtrl = GetComponent<SceneController>();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public void StartGame () {
		sceneCtrl.LoadNext();
	}

	void Init () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	void OnScore (int score) {
		scoreCtrl.Add(score);
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		if (scene.name.Contains("Game")) {
			scoreCtrl.Init();
		}
	}
}
