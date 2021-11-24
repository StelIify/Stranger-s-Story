using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadUIList : MonoBehaviour
{
    List<Head> items = Inventory.instance.heads;
    
    public GameObject buttonTemplate;

    // Start is called before the first frame update
    void Start()
    {

        GameObject g;
        foreach(Head i in items){
            //buttonTemplate.
            g = Instantiate(buttonTemplate,transform);
            g.transform.GetChild(0).GetComponent<Image>().sprite = i.icon;
            g.transform.GetChild(1).GetComponent<Text>().text = i.name;
        }

        HeadUIElement[] slots = GetComponentsInChildren<HeadUIElement>();

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
