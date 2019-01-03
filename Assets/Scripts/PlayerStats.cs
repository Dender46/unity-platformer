using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int health;
    public int maxHealth;

    public bool damaged;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public SpriteRenderer texture;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    void Start()
    {
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
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
        StartCoroutine(FlashCharacter());
    }

    IEnumerator FlashCharacter()
    {
		damaged = true;
        for (int i = 0; i < 12; i++)
        {
            texture.material.shader = shaderGUItext;
            texture.color = Color.white;
            yield return new WaitForSeconds(.05f);
            texture.material.shader = shaderSpritesDefault;
            texture.color = Color.white;
            yield return new WaitForSeconds(.05f);
        }
        damaged = false;
    }
}
