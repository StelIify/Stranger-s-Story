using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSender : MonoBehaviour
{

    #region Singleton

	public static ItemSender instance;

	void Awake()
	{
		instance = this;
	}

	#endregion

    public delegate void OnChestOpening(Item[] items);
	public OnChestOpening OnChestOpeningCallback;

    public delegate void OnChestClosing();
	public OnChestClosing OnChestClosingCallback;
    
    int countOfItems = 0;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItem(Item item){

    }

    public void AddItems(Item[] items){
        countOfItems = items.Length;
        if (OnChestOpeningCallback != null)
				OnChestOpeningCallback.Invoke(items);
    }

    public void RemoveItems(){
        countOfItems -= 1;

        if(countOfItems <= 0){
            OnChestClosingCallback.Invoke();
        }
    }
    //public void 
}
