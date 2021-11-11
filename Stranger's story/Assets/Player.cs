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
    public int maxOnslaugth = 100;
    private int currentOnslaugth;

    public Health healthBar;
    public Mana manaBar;
    public Onslaugth onslaugthBar;


    private float onslaugthTimer = 0.0f;
    public float onslaugthPeriod = 1f;
    private float hpTimer = 0.0f;
    public float hpPeriod = 2f;
    private float mpTimer = 0.0f;
    public float mpPeriod = 4f;




    /*void Awake()
	{
        healthBar = FindObjectOfType<HealthBar>();

    }*/

    // Start is called before the first frame update
    void Start()
    {
        
        currentHP = maxHP;
        currentMP = maxMP;
        currentOnslaugth = 0;
        healthBar.SetMaxHealth(maxHP);
        manaBar.SetMaxMana(maxMP);
        onslaugthBar.SetMaxOnslaugth(maxOnslaugth);

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
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Debug.Log("Onslaugth was raised :)");
            RageUp(10);
        }
        /*else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Debug.Log("Onslaugth was decreased :(");
            RageDown(5);
        }*/
        onslaugthTimer += Time.deltaTime;
        hpTimer += Time.deltaTime;
        mpTimer += Time.deltaTime;

        if (onslaugthTimer >= onslaugthPeriod)
        {
            onslaugthTimer = 0.0f;
            RageDown(1);   // <============= Prob. parameter
        }
        if (hpTimer >= hpPeriod)
        {
            hpTimer = 0.0f;
            Healing(1);   // <============= Prob. parameter
        }
        if (mpTimer >= mpPeriod)
        {
            mpTimer = 0.0f;
            ManaRecovering(1);   // <============= Prob. parameter
        }
    }

    private int calculatePoints(int current, int max)
	{
        if (current <= 0)
        {
            current = 0;
        }
        else if (current >= max)
        {
            current = max;
        }
        return current;
    }

    void TakeDamage(int damage)
	{

        currentHP = calculatePoints(currentHP-damage, maxHP);
        healthBar.SetHealth(currentHP);

    }

    void CastSpell(int manacost)
	{
        currentMP = calculatePoints(currentMP - manacost, maxMP);
        manaBar.SetMana(currentMP);
    }

    void Healing(int heals)
    {
        currentHP = calculatePoints(currentHP + heals, maxHP);
        healthBar.SetHealth(currentHP);
    }

    void ManaRecovering(int mana)
    {
        currentMP = calculatePoints(currentMP + mana, maxMP);
        manaBar.SetMana(currentMP);
    }

    void RageUp (int onslaugth)
	{
        currentOnslaugth = calculatePoints(currentOnslaugth + onslaugth, maxOnslaugth); 
        onslaugthBar.SetOnslaugth(currentOnslaugth);
    }

    void RageDown(int onslaugth)
    {
        currentOnslaugth = calculatePoints(currentOnslaugth - onslaugth, maxOnslaugth);
        onslaugthBar.SetOnslaugth(currentOnslaugth);

    }
}
