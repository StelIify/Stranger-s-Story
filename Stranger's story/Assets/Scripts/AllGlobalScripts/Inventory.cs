using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

	#region Singleton

	public static Inventory instance;

	void Awake()
	{
			instance = this;	

			DontDestroyOnLoad(this.gameObject);
	}

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 10;  // Amount of item spaces

	// Our current list of items in the inventory
	public List<Item> items = new List<Item>();

	public List<Weapon> weapons = new List<Weapon>();
	public Weapon equipedWeapon;
	public int weaponSpace = 10;
	public List<Shield> shields = new List<Shield>();
	public Shield equipedShield;
	public int shieldSpace = 10;
	public List<Head> heads = new List<Head>();
	public Head equipedHead;
	public int headSpace = 10;
	public List<L_Arm> l_arms = new List<L_Arm>();
	public L_Arm equipedL_Arm;
	public int l_armSpace = 10;
	public List<R_Arm> r_arms = new List<R_Arm>();
	public R_Arm equipedR_Arm;
	public int r_armSpace = 10;
	public List<Chest> chests = new List<Chest>();
	public Chest equipedChest;
	public int chestSpace = 10;
	public List<Legs> legs = new List<Legs>();
	public Legs equipedLegs;
	public int legsSpace = 10;
	public List<Ring> rings = new List<Ring>();
	public Ring equipedRing;
	public int ringSpace = 10;
	public List<Neck> necks = new List<Neck>();
	public Neck equipedNeck;
	public int neckSpace = 10;

	/*
	// Add a new item if enough room
	public void Add(Item item)
	{
		if (item.showInInventory)
		{
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return;
			}
			Debug.Log("Item added");
			item.addToInventory();

			//if (onItemChangedCallback != null)
			//	onItemChangedCallback.Invoke();
		}
	}

	// Remove an item
	public void Remove(Item item)
	{
		item.RemoveFromInventory();

		//if (onItemChangedCallback != null)
		//	onItemChangedCallback.Invoke();
	}
	*/
	
}