using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ButtonSound : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public AudioClip buttonDown;
	public AudioClip buttonUp;

	AudioSource audioSrc;

	void Awake () {
		audioSrc = GetComponent<AudioSource>();
		audioSrc.loop = false;
		audioSrc.playOnAwake = false;
	}

	public void OnPointerDown (PointerEventData eventData) {
		audioSrc.PlayOneShot(buttonDown);
	}

	public void OnPointerUp (PointerEventData eventData) {
		audioSrc.PlayOneShot(buttonUp);
	}
}
