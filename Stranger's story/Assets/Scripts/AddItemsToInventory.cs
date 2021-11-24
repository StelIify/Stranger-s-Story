using UnityEngine;
using UnityEngine.UI;
public class AddItemsToInventory : MonoBehaviour
{
    Inventory inventory;
    ItemSender itemSender;
    Item item;


    // Start is called before the first frame update
    void Start()
    {
        itemSender = ItemSender.instance;
        inventory = Inventory.instance;
		//inventory.onItemChangedCallback += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item addedItem){
        item = addedItem;
    }

    public void SaveItemToInventory(){
        Debug.Log("Try to add item to inventory");
        item.addToInventory();
        itemSender.RemoveItems();
        Destroy(transform.gameObject);
    }
}
