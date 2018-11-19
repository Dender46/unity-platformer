using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 3f;

    public CharacterController2D movement;
    public Transform groundDetection;

    private bool movingRight = true;

	void FixedUpdate () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
            Flip();
	}

    void Flip() {
        if (movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        } else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
}