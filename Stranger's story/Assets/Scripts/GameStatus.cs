using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{

    #region Singleton

	public static GameStatus instance;

	void Awake()
	{
		instance = this;

        DontDestroyOnLoad(this.gameObject);
	}

	#endregion
    
    
    public bool GamePause = false;
    public bool IsInBattle = false;
    public bool IsInInventory = false;
    public bool IsPickup = false;
    
    // For playing animations (GamePause must be false)
    public bool IsAction = false;

   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame(){
        GamePause = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        GamePause = false;
        Time.timeScale = 1f;
    }
}
