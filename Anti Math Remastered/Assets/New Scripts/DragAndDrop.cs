using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler {

    public static GameObject ItemTodrag;
    Vector3 OrginalPos;
    bool ImTouching = false;

   public void OnBeginDrag(PointerEventData eventData)
    {
        ItemTodrag = gameObject;
        OrginalPos = transform.position;
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ItemTodrag = null;
        transform.position = OrginalPos;

        if (ImTouching)
        {
            gameObject.GetComponent<AnswerButton>().CheckForAnswer();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DragTarget")
        {
        ImTouching = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DragTarget")
        {
            ImTouching = false;
        }
    }
}
