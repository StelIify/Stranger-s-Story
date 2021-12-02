using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{    
    GameStatus gameStatus;
    
    public GameObject pauseMenuUI;

    void Start()
	{
		//pauseMenuUI.SetActive(false);
        gameStatus = GameStatus.instance;
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && !gameStatus.IsPickup && !gameStatus.IsInInventory){
            
            if (gameStatus.GamePause){
                //Resume();
            }
            else{
                Pause();
            }
        }
    }


    void Pause(){
        if(!gameStatus.GamePause){
            //set UI active
            //pauseMenuUI.SetActive(true);
            //set statuses
            //gameStatus.PauseGame();
            
            //gameStatus.GamePause = true;
            //gameStatus.IsInBattle = true;
            StartCoroutine(SkipFrame());
        }
        
    }

    void Resume(){
        if(gameStatus.GamePause){
            //set UI active
            //pauseMenuUI.SetActive(false);
            //set statuses
            //gameStatus.ResumeGame();
            gameStatus.GamePause = false;
            gameStatus.IsInBattle = false;
        }
    }

    IEnumerator SkipFrame()
    {
        //returning 0 will make it wait 1 frame
        yield return 0;
        
        gameStatus.GamePause = true;
        gameStatus.IsInBattle = true;
    }
}
