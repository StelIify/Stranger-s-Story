using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_ArmUIEquiped : MonoBehaviour
{
    R_Arm item;
    
    // Start is called before the first frame update
    void Start()
    {
        InventoryUIController.instance.OnInventoryChangedCallback += UpdateState;
        UpdateState();
    }

    void UpdateState(){
        item = Inventory.instance.equipedR_Arm;
        Button g = transform.GetComponentInChildren<Button>();
        if(item != null){
            g.gameObject.transform.GetChild(0).GetComponent<Image>().gameObject.SetActive(true);
            g.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;
            g.gameObject.transform.GetChild(1).GetComponent<Text>().text = item.name;
        }
        else{
            g.gameObject.transform.GetChild(0).GetComponent<Image>().gameObject.SetActive(false);
            g.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
            g.gameObject.transform.GetChild(1).GetComponent<Text>().text = "None";
        }
    }
}
