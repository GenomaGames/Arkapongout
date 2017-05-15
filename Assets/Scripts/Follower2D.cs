using UnityEngine;

public class Follower2D : MonoBehaviour {

	public enum TargetTypes {Mouse, GameObject, Tag};
	public TargetTypes target = TargetTypes.Mouse;
	public Transform targetTransform;
	public string targetTag;
	public bool followY = true;
	public bool followX = true;
	public bool insideScreen = true;
	public Vector2 offset = Vector2.zero;
	public Vector2 boundaries = Vector2.one;

	Camera cam;

	void Awake () {
		cam = Camera.main;

		if (target == TargetTypes.Tag) {
			GameObject go = GameObject.FindWithTag(targetTag);

			if (go != null) {
				targetTransform = go.transform;
				target = TargetTypes.GameObject;
			} else {
				Debug.LogError("[Follower2D] Tag "+ targetTag + " not found in scene");
			}
		}
	}

	void Update () {
		if (target == TargetTypes.Mouse) {
			FollowMouse();
		} else if (target == TargetTypes.GameObject) {
			FollowGameObject();
		}
	}

	void FollowMouse () {
		Debug.Log("[Follower2D] Following Mouse");
		float posY = transform.position.y;
		float posX = transform.position.x;
		Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

		if (followY) posY = mousePos.y + offset.y;
		if (followX) posX = mousePos.x + offset.x;

		if (insideScreen) {
			Vector3 viewportZero = cam.ViewportToWorldPoint(Vector2.zero);
			Vector3 viewportOne = cam.ViewportToWorldPoint(Vector2.one);

			if (followY) {
				float top = posY + (boundaries.y / 2f);
				float bottom = posY - (boundaries.y / 2f);

				if (viewportZero.y > bottom) {
					posY = viewportZero.y + (boundaries.y / 2f);
				}

				if (viewportOne.y < top) {
					posY = viewportOne.y - (boundaries.y / 2f);
				}

			}

			if (followX) {
				float right = posX + (boundaries.x / 2f);
				float left = posX - (boundaries.x / 2f);

				if (viewportZero.x > left) {
					posX = viewportZero.x + (boundaries.x / 2f);
				}

				if (viewportOne.x < right) {
					posX = viewportOne.x - (boundaries.x / 2f);
				}
			}
		}

		Vector3 newPos = new Vector3(posX, posY, transform.position.z);

		SendMessage("OnMove", newPos, SendMessageOptions.DontRequireReceiver);
	}

	void FollowGameObject () {
		Debug.Log("[Follower2D] Following Game Object: " + targetTransform.gameObject.name);

		Vector3 newPos = transform.position;

		if (followX) newPos.x = targetTransform.position.x;
		if (followY) newPos.y = targetTransform.position.y;

		SendMessage("OnMove", newPos, SendMessageOptions.DontRequireReceiver);
	}

	void OnDrawGizmosSelected () {
		 Gizmos.color = Color.yellow;
		 Gizmos.DrawWireCube(transform.position + (Vector3)offset, boundaries);
	}
}
