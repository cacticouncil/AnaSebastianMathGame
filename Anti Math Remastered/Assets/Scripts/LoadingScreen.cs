using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScreen : MonoBehaviour {

    public GameObject SceneToLoad;

    AsyncOperation Async;

    private void Start()
    {
        LoadSceneExample();
    }
    public void LoadSceneExample()
    {
        StartCoroutine(LoadingScene());
    }
   
    IEnumerator LoadingScene()
    {
        SceneToLoad.SetActive(true);
        Async = SceneManager.LoadSceneAsync("3d camera behind kid");
        Async.allowSceneActivation = false;

        while (Async.isDone == false)
        {
            if (Async.progress == 0.9f)
            {
                Async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
