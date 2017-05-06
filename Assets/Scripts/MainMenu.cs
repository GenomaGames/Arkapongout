using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text versionText;

	void Start () {
		versionText.text = 'v' + Application.version;
	}

	public void StartGame () {
		SceneController.LoadNext();
	}
}
