using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/* This object manages the inventory UI. */

public class InventoryUI : MonoBehaviour
{

	public GameObject inventoryUI;  // The entire UI
	public Transform itemsParent;   // The parent object of all the items

	Inventory inventory;    // Our current inventory
	GameStatus gameStatus;

	void Start()
	{
		inventoryUI.SetActive(false);
		gameStatus = GameStatus.instance;
	}

	// Check to see if we should open/close the inventory
	void Update()
	{
		
		if (Input.GetButtonDown("Inventory") && !gameStatus.IsInBattle && !gameStatus.IsPickup)
		{
			if(!gameStatus.GamePause){
				//set statuses
				gameStatus.IsInInventory = true;
				gameStatus.PauseGame();
				//set UI active
				inventoryUI.SetActive(true);
				//UpdateUI();
			}
			else if(gameStatus.GamePause && inventoryUI.activeSelf){
				//set statuses
				gameStatus.IsInInventory = false;
				gameStatus.ResumeGame();
				//set UI active
				inventoryUI.SetActive(false);
				//UpdateUI();
			}
		}
	}

	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.

	/*public void UpdateUI()
	{
		InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}*/

}