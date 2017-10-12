using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class AnimationsController : MonoBehaviour {


   public BookMark[] Bookmarks;
    public Animator CamAnim;
   RaycastHit hit;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (EventSystem.current.IsPointerOverGameObject())
            return;
       //if (CamAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !CamAnim.IsInTransition(0))
       //    return;
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            
            CamAnim.SetBool("OpenPage", true);
            AnimateTheBook(hit);
        }
    }


    void AnimateTheBook(RaycastHit _hit)
    {
        int ThatOne = -1;
        for (int i = 0; i < Bookmarks.Length; i++)
        {
            if (_hit.collider.gameObject == Bookmarks[i].gameObject)
            {
                ThatOne = i;
                break;
            }
        }
        if(ThatOne >=0 && ThatOne < Bookmarks.Length -1)
            for (int i = ThatOne; i >= 0; i--)
            {
                    Bookmarks[i].TurnPage(true);
            }
        else if(ThatOne == (Bookmarks.Length - 1))
        {
            for (int i = ThatOne; i >= 0; i--)
            {
                Bookmarks[i].TurnPage(false);
            }
            CamAnim.SetBool("OpenPage", false);
        }

    }
}
