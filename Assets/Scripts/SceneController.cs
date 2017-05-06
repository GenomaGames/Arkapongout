using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public static void Load (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public static void LoadNext () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
