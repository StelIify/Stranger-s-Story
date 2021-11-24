using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIList : MonoBehaviour
{
    List<Weapon> items = Inventory.instance.weapons;
    
    public GameObject buttonTemplate;

    
    // Start is called before the first frame update
    void Start()
    {

        GameObject g;
        foreach(Weapon i in items){
            //buttonTemplate.
            g = Instantiate(buttonTemplate,transform);
            g.transform.GetChild(0).GetComponent<Image>().sprite = i.icon;
            g.transform.GetChild(1).GetComponent<Text>().text = i.name;
        }

        WeaponUIElement[] slots = GetComponentsInChildren<WeaponUIElement>();

		for (int i = 0; i < items.Count; i++)
		{
			slots[i].AddItem(items[i]);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
