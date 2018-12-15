using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ResizeScript : MonoBehaviour {

	public float scaleX;
	public float scaleY;
	public float factorX;
	public float factorY;

	public float cubeSize;

	void Update () {
		transform.localScale = new Vector3 ((scaleX + factorX) * cubeSize, (scaleY + factorY) * cubeSize, 0.0f);
	}
}
