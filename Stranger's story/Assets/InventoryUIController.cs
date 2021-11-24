using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    #region Singleton

	public static InventoryUIController instance;

	void Awake()
	{
			instance = this;	

			//DontDestroyOnLoad(this.gameObject);
	}

	#endregion


    public delegate void OnInventoryChanged();
    public OnInventoryChanged OnInventoryChangedCallback;

    List<GameObject> layersList = new List<GameObject>();
    GameObject currentObject;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad7)){
            
            removeLayer();
        } 
    }

    public void addLayer(GameObject layer){
        layersList.Add(layer);
        currentObject = layer;
    }

    public void removeLayer(){
        if(layersList.Count>0){
            currentObject = layersList[layersList.Count -1];
            layersList.Remove(currentObject);
            currentObject.GetComponent<TabGroup>().UpdateLayer();
        }else{
            leaveInventoryUI();
        }
    }

    public void removeAllLayers(){
        layersList.Clear();
        leaveInventoryUI();
    }

    private void leaveInventoryUI(){
        SceneChanger.instance.UnloadScene("InventoryScene");
    }
}
