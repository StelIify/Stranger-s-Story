using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;
    public int maxMP = 50;
    private int currentMP;

    public Health healthBar;
    public Mana manaBar;

    /*void Awake()
	{
        healthBar = FindObjectOfType<HealthBar>();

    }*/

    // Start is called before the first frame update
    void Start()
    {
        
        currentHP = maxHP;
        currentMP = maxMP;
        healthBar.SetMaxHealth(currentHP);
        manaBar.SetMaxMana(currentMP);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
		{
            Debug.Log("Damage taken :(");
            TakeDamage(20);
		}
        else if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("Hero used spell :D");
            CastSpell(5);

        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Debug.Log("Damage was healed :)");
            Healing(10);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Debug.Log("Manapool was recovered :(");
            ManaRecovering(5);
        }
    }

    void TakeDamage(int damage)
	{
        currentHP -= damage;
        healthBar.SetHealth(currentHP);

    }

    void CastSpell(int manacost)
	{
        currentMP -= manacost;
        manaBar.SetMana(currentMP);
    }

    void Healing(int heals)
    {
        currentHP += heals;
        healthBar.SetHealth(currentHP);
    }

    void ManaRecovering(int mana)
    {
        currentMP += mana;
        manaBar.SetMana(currentMP);
    }
}
