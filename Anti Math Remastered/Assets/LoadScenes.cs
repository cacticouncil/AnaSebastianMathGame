using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScenes : MonoBehaviour {

    public void load(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
