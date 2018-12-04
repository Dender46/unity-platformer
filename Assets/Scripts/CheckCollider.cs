using UnityEngine;

public class CheckCollider : MonoBehaviour {

	public float waitTime		= 1f;
	public float minVelocity = 1.5f;
	public float minAngVelocity = 1f;
	public float gridSizeOffest = 0f;

	bool collided = false;
	float gridSizeX;
    float gridSizeY;

    Rigidbody2D	rb;
	Transform	tr;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		tr = GetComponent<Transform> ();

		gridSizeX = tr.localScale.x + gridSizeOffest;
        gridSizeY = tr.localScale.y + gridSizeOffest;
    }

	void FixedUpdate() {
		if (rb.isKinematic)
			return;
        Debug.Log(rb.velocity.magnitude);
		if (collided && rb.velocity.magnitude < minVelocity &&
		    rb.angularVelocity < minAngVelocity) {
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

        if (col.collider.tag == "Enemy") {
            if (!rb.isKinematic && rb.velocity.magnitude > 5)
                Destroy(col.collider);
            else {
                Destroy(this.gameObject);
            }
        }
	}

    void MakeStatic() {
		rb.isKinematic = true;
		rb.velocity = new Vector2 (0f, 0f);
		rb.angularVelocity = 0f;
		rb.rotation = 0f;

		Vector3 pos = tr.position;	
		Vector3 newPos = new Vector3 ();
		newPos.x = Mathf.Round (pos.x / gridSizeX) * gridSizeX;
		newPos.y = Mathf.Round (pos.y / gridSizeY) * gridSizeY;
		tr.position = newPos;
		
		/*GetComponent<BoxCollider2D> ().enabled = false;

        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<PolygonCollider2D>().enabled = true;
        GetComponent<PlatformEffector2D> ().enabled = true;*/
	}
}
