using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_battle_mode : MonoBehaviour
{
    #region Singleton

	public static QTE_battle_mode instance;

	void Awake()
	{
			instance = this;	

			DontDestroyOnLoad(this.gameObject);
	}

	#endregion

    private int waitPressingButton = -1; // -1 - out of battle, 0 - start battle, 1 - in battle, 2 - out of battle;
    private int ButtonPressed; // 0 - button does not pressed, 1 - pressed in time, 2 - pressed to later;
    private int isWindowOpened = 0; // 0 - before window is opened, 1 - in time, 2 - after;
    private int comboCount = 0;
    private UnitStatus attacker;
    private UnitStatus defender;

    public GameObject comboCounterComponent; // Combo 2(3,4,...)
    public GameObject comboChainComponent; // !!!
    public GameObject comboAlarmComponent; // Too early / In time / Exelent / Too late
    
    public void StartBattle(UnitStatus attacker, UnitStatus defender){
        waitPressingButton = 0;
        this.attacker = attacker;
        this.defender = defender;
        comboCounterComponent.SetActive(true);
        Debug.Log("Battle begin");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitPressingButton == 0){
            
            waitPressingButton = 1;
            comboCount++;
            ButtonPressed = 0;
            StartCoroutine(Cooldown());
            if (comboCount == 1){
                StartCoroutine(Battle());
            }
            else{
                StartCoroutine(Battle());
            }
            
        }
        if (waitPressingButton == 1){
            if (Input.anyKeyDown){
                if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.P)){
                    if (isWindowOpened==1){
                        ButtonPressed = 1;
                        StartCoroutine(VisualComponentUpdate(comboCount, isWindowOpened));

                    } else{
                        ButtonPressed = 2;
                        //вивести на екран невдачу згідно параметру isWindowOpened
                        StartCoroutine(VisualComponentUpdate(0, isWindowOpened));
                    }
                }
            }
        }
        if (waitPressingButton == 2){
            waitPressingButton = -1;
            //attacker = null;
            //defender = null;
            comboCount = 0;
            comboCounterComponent.SetActive(false);

            GameStatus.instance.GamePause = false;
            GameStatus.instance.IsInBattle = false;
            GameStatus.instance.IsAction = false;
            // закінчити бій
            // можна, наприклад, програти анімацію смерті
        }
        
    }

    IEnumerator Battle(){
        float combo_time = 0.5f - comboCount*0.02f; // 0.4f
        if (combo_time < 0.18f){
            combo_time = 0.18f;
        }
        //запустити анімацію удару
        isWindowOpened = 0; // рано

        yield return new WaitForSeconds(2 - combo_time);
        isWindowOpened = 1; // вчасно
        comboAlarmComponent.SetActive(true);
        yield return new WaitForSeconds(combo_time);
        isWindowOpened = 2; // пізно
        comboAlarmComponent.SetActive(false);
        yield return new WaitForSeconds(1);
        if (ButtonPressed == 1){
            waitPressingButton = 0;
        } else if (ButtonPressed == 2){
            waitPressingButton = 2;
        }
        Debug.Log(combo_time);
    }
    
    IEnumerator Cooldown(){
        yield return new WaitForSeconds(3);
        if (ButtonPressed == 0 || ButtonPressed == 2){
            waitPressingButton = 2;
            comboCounterComponent.transform.GetComponent<Text>().text = "";
            comboChainComponent.transform.GetComponent<Text>().text = ""; 
            comboChainComponent.SetActive(false);
        }

    }


    IEnumerator VisualComponentUpdate(int comboCount, int successParam){
        comboChainComponent.SetActive(true);
        if (successParam == 1){
            // можна ще анімації для тексту замутити
            // тригер для цього сіпати тут
            comboCounterComponent.transform.GetComponent<Text>().text = "Combo chain " + (comboCount + 1);
            comboChainComponent.transform.GetComponent<Text>().text = "In time" + (comboCount + 1);
        }
        else if(successParam == 0){
            comboCounterComponent.transform.GetComponent<Text>().text = "";
            comboChainComponent.transform.GetComponent<Text>().text = "Too early";
        }
        else if(successParam == 2){
            comboCounterComponent.transform.GetComponent<Text>().text = "";
            comboChainComponent.transform.GetComponent<Text>().text = "Too late";            
        }
        yield return new WaitForSeconds(2);
        
        comboChainComponent.SetActive(false);
    }
}
