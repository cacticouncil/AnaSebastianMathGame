using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewArrowController : MonoBehaviour {

    [SerializeField]
    Transform player;
    int maxChildren;
    int countNull;
    Transform CurrTarget;
    float ClosestToMe = 99999;
    private void Start()
    {
        maxChildren = NewGameManager.instance.childrenAmount;
        StartCoroutine(CheckForTarget());
    }

     
    IEnumerator CheckForTarget()
    {
        while (true)
        {
            float highest = float.MaxValue;
            countNull = 0;
            for (int i = 0; i < maxChildren; i++)
            {
                if(NewGameManager.instance.GetChild(i) != null)
                {
                    if (Mathf.Abs(Vector3.Distance(transform.position, NewGameManager.instance.GetChild(i).transform.position)) < highest)
                    {
                        CurrTarget = NewGameManager.instance.GetChild(i).transform;
                        highest = Mathf.Abs(Mathf.Abs(Vector3.Distance(transform.position, NewGameManager.instance.GetChild(i).transform.position)));
                    }
                }
                else
                {
                    countNull++;
                }

                if (countNull == maxChildren)
                {
                    gameObject.SetActive(false);
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void FixedUpdate()
    {
        transform.LookAt(CurrTarget, player.up);
        Vector3 left = Vector3.Cross(transform.forward, player.up);
        Vector3 forward = Vector3.Cross(left, player.up);
        transform.up = player.up;
        transform.right = left;
        transform.forward = -forward;
    }
}
