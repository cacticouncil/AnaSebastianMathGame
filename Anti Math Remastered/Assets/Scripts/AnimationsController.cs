using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class AnimationsController : MonoBehaviour {


   public BookMark[] Bookmarks;
   RaycastHit hit;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
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
        else if(ThatOne == (Bookmarks.Length -1))
            for (int i = ThatOne; i >= 0; i--)
            {
                Bookmarks[i].TurnPage(false);
            }
    }
}
