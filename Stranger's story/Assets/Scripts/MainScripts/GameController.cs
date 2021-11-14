using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController
{

    

    public static List<Item> items;
    public static GameStatus gameStatus;
    
    // Start is called before the first frame update
    

    public static void SaveGameState(){
        items = Inventory.instance.items;
        //gameStatus = GameStatus.instance;
    }

    public static void LoadGameState(){
        //Debug.Log(GameController.items.Count);
        Inventory.instance.items = GameController.items;
        //GameStatus.instance = gameStatus;
    }
}
