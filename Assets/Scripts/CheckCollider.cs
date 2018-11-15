using UnityEngine;

public class CheckCollider : MonoBehaviour {

	public float waitTime		= 1f;
	public float maxVelocity	= 1.5f;
	public float maxAngVelocity	= 1f;
	public float gridSizeOffest = 0f;

	bool collided = false;
	float gridSize;

	Rigidbody2D	rb;
	Transform	tr;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		tr = GetComponent<Transform> ();

		gridSize = tr.localScale.x + gridSizeOffest;
	}

	void FixedUpdate() {
		if (rb.isKinematic)
			return;

		if (collided && rb.velocity.magnitude < maxVelocity &&
		    rb.angularVelocity < maxAngVelocity) {
			Invoke ("MakeStatic", waitTime);
		} else {
			CancelInvoke ("MakeStatic");
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == 10 ||
		    col.gameObject.layer == 9) {
			collided = true;
		}
	}

	void MakeStatic() {
		rb.isKinematic = true;
		rb.velocity = new Vector2 (0f, 0f);
		rb.angularVelocity = 0f;
		rb.rotation = 0f;

		Vector3 pos = tr.position;	
		Vector3 newPos = new Vector3 ();
		newPos.x = Mathf.Round (pos.x / gridSize) * gridSize;
		newPos.y = Mathf.Round (pos.y / gridSize) * gridSize;
		tr.position = newPos;
		
		GetComponent<BoxCollider2D> ().enabled = false;

		GetComponent<PlatformEffector2D> ().enabled = true;
		GetComponent<CapsuleCollider2D> ().enabled = true;
		GetComponent<PolygonCollider2D> ().enabled = true;
	}
}
