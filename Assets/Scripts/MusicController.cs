using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : Singleton<MusicController> {

	public AudioClip[] musicClips;

	AudioSource audioSrc;

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	void Start () {
		SceneManager.sceneLoaded += OnSceneLoaded;
		audioSrc = GetComponent<AudioSource>();
		audioSrc.clip = musicClips[SceneManager.GetActiveScene().buildIndex];
		audioSrc.Play();
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		audioSrc.clip = musicClips[scene.buildIndex];
		audioSrc.Play();
	}
}
