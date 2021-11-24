using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItemsToUI : MonoBehaviour
{
    
    ItemSender itemSender;
    public GameObject buttonTemplate;
    
    //public List<Item> itemList;
    

    // Start is called before the first frame update
    void Start()
    {
        itemSender = ItemSender.instance;
		itemSender.OnChestOpeningCallback += PickUp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(Item[] items){
        
        //GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;
        for(int i= 0; i< items.Length; i++){
            //buttonTemplate.
            g = Instantiate(buttonTemplate,transform);
            g.transform.GetChild(0).GetComponent<Image>().sprite = items[i].icon;
            g.transform.GetChild(1).GetComponent<Text>().text = items[i].name;
        }

        AddItemsToInventory[] slots = GetComponentsInChildren<AddItemsToInventory>();

		for (int i = 0; i < items.Length; i++)
		{
			slots[i].AddItem(items[i]);
		}
        //Destroy(buttonTemplate);
    }

    public void openMenu(){
        
    }

}
