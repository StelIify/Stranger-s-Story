using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Interactable
{

	Animator animator;

	public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChangedCallback;


	
	// Have we already interacted with the object?
	//bool hasInteracted = false;

	bool isOpen;
	
	public Item[] items;

	ItemSender itemSender;

	void Start()
	{
		itemSender = ItemSender.instance;
		//animator = GetComponent<Animator>();
	}

	public override void Interact()
	{
		base.Interact();
		if (!isOpen)
		{
			//animator.SetTrigger("Open");
			StartCoroutine(CollectTreasure());
		}
	}

	IEnumerator CollectTreasure()
	{

		isOpen = true;
		
		yield return new WaitForSeconds(1f);
		Debug.Log("Chest opened");

		itemSender.AddItems(items);
	}
}