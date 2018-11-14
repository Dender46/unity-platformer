using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D movement;
	public float speed = 130f;

	float horizontalMove;
	bool jump	= false;
	bool crouch	= false;

	void Update() {
		horizontalMove = Input.GetAxisRaw ("Horizontal");

		if (Input.GetButtonDown ("Jump"))
			jump = true;
		
		if (Input.GetButtonDown ("Crouch"))
			crouch = true;
		else if (Input.GetButtonUp ("Crouch"))
			crouch = false;
	}

	void FixedUpdate() {
		movement.Move (horizontalMove * speed * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
