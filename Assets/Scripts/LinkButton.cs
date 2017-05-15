using UnityEngine;

public class LinkButton : MonoBehaviour {

	public void OpenUrl (string url) {
		Application.OpenURL(url);
	}
}
