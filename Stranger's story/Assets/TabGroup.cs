using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;


    void Start()
    {

    }

    public void UpdateLayer(){
        ResetTabs();
        for(int i = 0; i<objectsToSwap.Count; i++){
            objectsToSwap[i].SetActive(false);
        }
        for(int i = 0; i<tabButtons.Count; i++){
            tabButtons[i].gameObject.SetActive(true);
        }
        selectedTab = null;
    }

    public void Subscribe(TabButton button){
        if(tabButtons == null){
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button){
        ResetTabs();
        if(selectedTab == null || selectedTab != button){ 
            button.background.sprite = tabHover;
        }
    }

    public void OnTabExit(TabButton button){
        ResetTabs();
    }
    public void OnTabSelected(TabButton button){
        InventoryUIController.instance.addLayer(this.gameObject);
        selectedTab = button;        
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        Debug.Log("selected..." + index);
        for(int i = 0; i<objectsToSwap.Count; i++){
            if (i == index){
                objectsToSwap[i].SetActive(true);
            }
            else{
                objectsToSwap[i].SetActive(false);
            }
        }

        for(int i = 0; i<tabButtons.Count; i++){
            if (tabButtons[i] != button){
                tabButtons[i].gameObject.SetActive(false);
            }
        }

    }

    public void ResetTabs(){
        foreach (TabButton button in tabButtons)
        {
            if(selectedTab!= null && button == selectedTab) { continue; }
            button.background.sprite = tabIdle;
        }
    }
 }
