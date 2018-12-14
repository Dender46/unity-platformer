using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ResizeScript : MonoBehaviour {

	public float scaleX;
	public float scaleY;
	public float cubeSize;

	void Update () {
		transform.localScale = new Vector3 ((scaleX + 0.8f) * cubeSize, (scaleY + 0.8f) * cubeSize, 0.0f);
	}
}
