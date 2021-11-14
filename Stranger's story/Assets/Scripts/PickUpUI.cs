using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpUI : MonoBehaviour
{    
    GameStatus gameStatus;
    
    public GameObject pauseMenuUI;

    public Button button;

    ItemSender itemSender;
    void Start()
	{
		pauseMenuUI.SetActive(false);
        gameStatus = GameStatus.instance;
		itemSender = ItemSender.instance;
		itemSender.OnChestOpeningCallback += PickUpPause;
        itemSender.OnChestClosingCallback += Resume;
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Keypad8) && !gameStatus.IsInBattle && !gameStatus.IsInInventory){
            if (gameStatus.GamePause){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void PickUpPause(Item[] items){
        Pause();
        
    }


    void Pause(){
        if(!gameStatus.GamePause){
            //set UI active
            pauseMenuUI.SetActive(true);
            //set statuses
            gameStatus.PauseGame();
            gameStatus.IsPickup = true;
        }
        
    }

    void Resume(){
        if(gameStatus.GamePause){
            //set UI active
            pauseMenuUI.SetActive(false);
            //set statuses
            gameStatus.ResumeGame();
            gameStatus.IsPickup = false;
        }
    }
}
