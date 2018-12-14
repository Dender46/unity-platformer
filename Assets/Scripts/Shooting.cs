using UnityEngine;
using System;

public class Shooting : MonoBehaviour {

    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character

	public float fireRate = 1;
	public float projectileSpeed = 22;

    public Transform firePoint;
	public Rigidbody2D projectile;

	bool allowFire = true;

    void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            projectileSpeed = 22;
            InvokeRepeating("Shoot", .001f, fireRate);
        }
		if (Input.GetButtonUp ("Fire1"))
			CancelInvoke ("Shoot");

        if (Input.GetButtonDown("Fire2"))
        {
            projectileSpeed = 12;
            InvokeRepeating("Shoot", .001f, fireRate);
        }
        if (Input.GetButtonUp("Fire2"))
            CancelInvoke("Shoot");
    }

    private void FixedUpdate() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(firePoint.position, 0.2f, m_WhatIsGround);
        if (colliders.Length > 0)
            allowFire = false;
        else
            allowFire = true;
    }

    public void Shoot() {
        if (!allowFire)
			return;
		Rigidbody2D proj = (Rigidbody2D) Instantiate (projectile, firePoint.position, firePoint.rotation);
		proj.velocity = firePoint.TransformDirection(Vector3.right * projectileSpeed);
	}
}
