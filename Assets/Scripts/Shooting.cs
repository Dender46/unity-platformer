using UnityEngine;

public class Shooting : MonoBehaviour {

	public float fireRate = 1;
	public float projectileSpeed = 10;

	public Transform firePoint;
	public Rigidbody2D projectile;

	bool allowFire = true;

	void Update () {
		if (Input.GetButtonDown("Fire1"))
			InvokeRepeating("Shoot", .001f, fireRate);
		if (Input.GetButtonUp ("Fire1"))
			CancelInvoke ("Shoot");
	}

	void OnTriggerStay2D(Collider2D col) {
		allowFire = false;
		Debug.Log (allowFire);
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.tag != "PlayerProjectile")
			allowFire = true;
		Debug.Log (allowFire);
	}

	public void Shoot() {
		if (!allowFire)
			return;
		Rigidbody2D proj = (Rigidbody2D) Instantiate (projectile, firePoint.position, firePoint.rotation);
		proj.velocity = firePoint.TransformDirection(Vector3.right * projectileSpeed);
	}
}
