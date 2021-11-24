using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    public Image background;

    public void OnPointerClick()
    {
        Debug.Log("Click...");
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter...");
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit...");
        tabGroup.OnTabExit(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        tabGroup = this.transform.GetComponentInParent<TabGroup>();
        Debug.Log("Initialized...");
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
