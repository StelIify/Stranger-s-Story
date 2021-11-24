using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    #region Singleton

	public static SceneChanger instance;

	void Awake()
	{
			instance = this;	
			DontDestroyOnLoad(this.gameObject);
	}

	#endregion
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneNameToLoad){
        StartCoroutine(LoadLevel(sceneNameToLoad));
    }

    IEnumerator LoadLevel(string sceneNameToLoad){
        transition.SetTrigger("Start");
        //transition.
        //Debug.Log("inventory loading...");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(sceneNameToLoad, LoadSceneMode.Additive);
        //Debug.Log("inventory loaded");
    }
    public void UnloadScene(string sceneName){
        StartCoroutine(UnloadLevel(sceneName));
    }

    IEnumerator UnloadLevel(string sceneName){
        
        SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        transition.SetTrigger("End");
        yield return new WaitForSecondsRealtime(transitionTime);
        //Debug.Log("inventory loaded");
        
    }

    public void LoadAdditiveScene(string sceneNameToLoad, string sceneNameToUnload){
        StartCoroutine(LoadAdditiveLevel(sceneNameToLoad, sceneNameToUnload));
    }

    IEnumerator LoadAdditiveLevel(string sceneNameToLoad, string sceneNameToUnload){
        transition.SetTrigger("Start");
        //transition.
        //Debug.Log("inventory loading...");
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneNameToLoad, LoadSceneMode.Additive);
        yield return load;
        SceneManager.UnloadSceneAsync(sceneNameToUnload, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        //Debug.Log("inventory loaded");
    }
}
