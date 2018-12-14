using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int health;
    public int maxHealth;

    public bool mortal;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Mortal", true);
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
        if (!mortal)
            return;
        health--;
        ChangeMortality();
    }

    public void ChangeMortality()
    {
        mortal = !mortal;
        animator.SetBool("Mortal", mortal);
        if (!mortal)
            Invoke("ChangeMortality", 2);
    }
}
