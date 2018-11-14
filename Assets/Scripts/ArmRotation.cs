using UnityEngine;

public class ArmRotation : MonoBehaviour { 

	Vector3 difference;
	float rotationZ;

	bool facingRight = true;

	// Update is called once per frame
	void Update () {
		difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();

		rotationZ = Mathf.Floor(Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg / 10f) * 10f;
		transform.rotation = Quaternion.Euler (0f, 0f, rotationZ);

		if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x > transform.position.x
			&& facingRight)
			FlipArm ();
		else if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x < transform.position.x
			&& !facingRight)
			FlipArm ();
	}

	void FlipArm() {
		facingRight = !facingRight;
		
		Vector3 scale = transform.localScale;
		scale.y *= -1;
		transform.localScale = scale;
	}
}
