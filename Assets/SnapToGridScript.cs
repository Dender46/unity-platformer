using UnityEngine;

[ExecuteInEditMode]
public class SnapToGridScript : MonoBehaviour {

	public float gridOffset = 0.06f;

	float gridSize;
	Transform tr;

	void Start () {
		gridSize = transform.localScale.x + gridOffset;
	}

	void Update () {
		Vector3 pos = transform.position;	
		Vector3 newPos = new Vector3 ();
		newPos.x = Mathf.Round (pos.x / gridOffset) * gridOffset;
		newPos.y = Mathf.Round (pos.y / gridOffset) * gridOffset;
		transform.position = newPos;
	}
}
