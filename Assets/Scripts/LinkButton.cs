using UnityEngine;

public class LinkButton : MonoBehaviour {

	public void OpenUrl (string url) {
		if(Application.platform == RuntimePlatform.WebGLPlayer) {
			Application.ExternalEval("window.open(\"" + url + "\",\"_blank\")");
		} else {
			Application.OpenURL(url);
		}
	}
}
