using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 130f;

    public CharacterController2D movement;
    public Transform groundDetection;

    private float direction = 1f;

	void FixedUpdate () {
		movement.Move (direction * speed * Time.deltaTime, false, false);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
		Debug.Log (groundInfo.collider);
		if (!groundInfo.collider)
			FlipDirection ();
	}

	void FlipDirection() {
		Debug.Log (direction);
		if (direction == 1f) {
			transform.eulerAngles = new Vector3 (0, -180, 0);
			direction = -1f;
		} else {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			direction = 1f;
		}
	}
}