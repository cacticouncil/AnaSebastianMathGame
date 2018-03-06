using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour {

    [SerializeField]
    GameObject VictoryScreen;
    [SerializeField]
    bool tutorial = false;
    private void OnEnable()
    {
        NewGameManager.EndGame += TriggerEnd;
    }

    private void OnDisable()
    {
        NewGameManager.EndGame -= TriggerEnd;
    }

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void TriggerEnd()
    {
        anim.SetTrigger("Done");
    }

    IEnumerator Grow(GameObject ToGrow)
    {
        float ratio = 0;

        while (ratio <= 1)
        {
            ToGrow.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, ratio);
            ratio += Time.deltaTime;
            yield return null;
        }
        //ToGrow.SetActive(false);
    }

    public void GrowDis()
    {
        if (!tutorial)
            return;
        StartCoroutine(Grow(VictoryScreen));
    }
}
