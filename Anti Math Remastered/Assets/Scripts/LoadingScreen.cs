using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScreen : MonoBehaviour {

    public GameObject SceneToLoad;

    AsyncOperation Async;
    public Transform from;
    public Transform to;
    public Transform toMove;
    private void Start()
    {
        LoadSceneExample();
    }
    public void LoadSceneExample()
    {
        StartCoroutine(LoadingScene());
    }
    float r;
    IEnumerator LoadingScene()
    {
        SceneToLoad.SetActive(true);
        // Async = SceneManager.LoadSceneAsync("3d camera behind kid");
        Async = SceneManager.LoadSceneAsync("Main Game");
        Async.allowSceneActivation = false;

        while (Async.isDone == false)
        {
            toMove.transform.position = Vector3.Lerp(from.position, to.position, Async.progress);
            //float progress = Mathf.Clamp01(ao.progress / 0.9f);
           // Debug.Log("Loading progress: " + (r * 100) + "%");
            if (Async.progress == 0.9f)
            {
                Async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
