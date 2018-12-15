using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int health;
    public int maxHealth;

    public bool damaged;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator animator;

    private void Start()
    {
		animator.SetBool("Damaged", false);
    }

    private void Update()
    {
        if (health > maxHealth)
            health = maxHealth;

        for (int i = 0; i < maxHealth; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            if (i < maxHealth)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    public void TakeDamage()
    {
        if (damaged)
            return;
        health--;
        ChangeMortality();
    }

    public void ChangeMortality()
    {
		damaged = !damaged;
		animator.SetBool("Damaged", damaged);
		if (damaged)
            Invoke("ChangeMortality", 2);
    }
}
