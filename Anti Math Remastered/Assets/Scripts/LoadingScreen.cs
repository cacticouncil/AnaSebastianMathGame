using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScreen : MonoBehaviour {

    public GameObject SceneToLoad;
    public GameObject Chiva;
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
    Vector3 Original = new Vector3(0, 0, 90);
    Vector3 Destination = new Vector3(0, 0, -90);
    IEnumerator LoadingScene()
    {
        SceneToLoad.SetActive(true);
        // Async = SceneManager.LoadSceneAsync("3d camera behind kid");
        Async = SceneManager.LoadSceneAsync("Main Game");
        Async.allowSceneActivation = false;

        while (Async.isDone == false)
        {
            // toMove.transform.position = Vector3.Lerp(from.position, to.position, Async.progress);
            transform.LookAt(Chiva.transform);
              
            toMove.transform.eulerAngles = Vector3.Lerp(Original,Destination,Async.progress);
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
