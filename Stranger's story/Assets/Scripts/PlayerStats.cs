using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public PlayerStatus playerStatus;

    public Health healthBar;
    public Mana manaBar;
    public Onslaugth onslaugthBar;

    public Inventory inventory;
    public QTE_battle_mode QTE_battle;

    private float onslaugthTimer = 0.0f;
    public float onslaugthPeriod = 1f;
    private float hpTimer = 0.0f;
    public float hpPeriod = 2f;
    private float mpTimer = 0.0f;
    public float mpPeriod = 4f;
    
    void Awake()
	{
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = new PlayerStatus(100, 100, 20, 10, 10, new List<Skill>());
        healthBar.SetMaxHealth(playerStatus.maxHP);
        manaBar.SetMaxMana(playerStatus.maxMP);
        onslaugthBar.SetMaxOnslaugth(playerStatus.maxOnslaugth);
        inventory = Inventory.instance;
        QTE_battle = QTE_battle_mode.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameStatus.instance.GamePause){
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Debug.Log("Damage taken :(");
                playerStatus.TakeDamage(20);
                healthBar.SetHealth(playerStatus.getCurrentHP());
            }
            else if(Input.GetKeyDown(KeyCode.Keypad2))
            {
                Debug.Log("Hero used spell :D");
                playerStatus.CastSpell(5);
                manaBar.SetMana(playerStatus.getCurrentMP());

            }
            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                Debug.Log("Damage was healed :)");
                playerStatus.Healing(10);
                healthBar.SetHealth(playerStatus.getCurrentHP());
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                Debug.Log("Manapool was recovered :(");
                playerStatus.ManaRecovering(5);
                manaBar.SetMana(playerStatus.getCurrentMP());
            }
            else if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                Debug.Log("Onslaugth was raised :)");
                playerStatus.RageUp(10);
                onslaugthBar.SetOnslaugth(playerStatus.getCurrentOnslaugth());
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
                playerStatus.RageDown(1);   // <============= Prob. parameter
            }
            if (hpTimer >= hpPeriod)
            {
                hpTimer = 0.0f;
                playerStatus.Healing(1);   // <============= Prob. parameter
            }
            if (mpTimer >= mpPeriod)
            {
                mpTimer = 0.0f;
                playerStatus.ManaRecovering(1);   // <============= Prob. parameter
            }
        }
        else{
            onslaugthTimer = 0;
            hpTimer = 0;
            mpTimer = 0;
        }

        if (GameStatus.instance.IsInBattle){
            if (Input.GetKeyDown(KeyCode.P) && !GameStatus.instance.IsAction)
            {
                StartCoroutine(SkipFrame());
                QTE_battle.StartBattle(playerStatus,playerStatus);
            }
        }       
        
    }

    IEnumerator SkipFrame()
    {
        //returning 0 will make it wait 1 frame
        yield return 0;
        
        GameStatus.instance.IsAction = true;
    }
    
}