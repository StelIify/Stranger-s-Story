using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuInventory : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadInventoryScene(){
        Debug.Log("loading inventory");
        //transition.SetTrigger("Start");
        //Application.LoadLevelAdditive("InventoryScene");
        //Time.timeScale = 1f;
        StartCoroutine(LoadLevel(1));
        
    }

    IEnumerator LoadLevel(int sceneName){
        transition.SetTrigger("Start");
        Debug.Log("inventory loading...");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(sceneName);
        Debug.Log("inventory loaded");
    }
}
