using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shame : MonoBehaviour {

    public void LoadPlz(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
