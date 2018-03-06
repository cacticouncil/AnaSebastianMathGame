using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    Vector2 originalSize;
    private void OnEnable()
    {
        NewGameManager.Paused += CannotUse;
        NewGameManager.UnPaused += CanUse;
        NewGameManager.EndGame += CannotUse;
    }

    private void Start()
    {
        originalSize = transform.localScale;
    }
    private void OnDisable()
    {
        NewGameManager.Paused -= CannotUse;
        NewGameManager.UnPaused -= CanUse;
        NewGameManager.EndGame -= CannotUse;
    }

    void CanUse()
    {
        transform.localScale = originalSize;
    }

    void CannotUse()
    {
        transform.localScale = Vector3.zero;
    }
}
