using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIElement : MonoBehaviour
{
    Weapon item;  // Current item in the slot

	// Add item to the slot
	public void AddItem(Weapon newItem)
	{
		item = newItem;

	}

	// Clear the slot
	public void ClearSlot()
	{
		item = null;

	}

	// If the remove button is pressed, this function will be called.
	public void RemoveItemFromInventory()
	{
		item.RemoveFromInventory();
	}

	// Use the item
	public void UseItem()
	{
		if (item != null)
		{
			Inventory.instance.equipedWeapon = item;
			InventoryUIController.instance.removeLayer();
			if (InventoryUIController.instance.OnInventoryChangedCallback!=null){
				InventoryUIController.instance.OnInventoryChangedCallback.Invoke();
			}
			else{
				Debug.Log("Not subscribed");
			}
			
		}
	}
}
