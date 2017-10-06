using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    public Image Backgroud;
    public Image JoystickBall;

    Vector3 currpos;

    private void Start()
    {
        if (InfoManager.instance.Gyroscope)
            this.gameObject.SetActive(false);

        JoystickBall.rectTransform.anchoredPosition = currpos = Vector3.zero;
    }

    public virtual void OnPointerDown(PointerEventData _p)
    {
        OnDrag(_p);
    }

    public virtual void OnPointerUp(PointerEventData _p)
    {
        JoystickBall.rectTransform.anchoredPosition = currpos= Vector3.zero;
    }
    public virtual void OnDrag(PointerEventData _p)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Backgroud.rectTransform,_p.position,_p.pressEventCamera,out pos))
        {
            pos.x =  (pos.x / Backgroud.rectTransform.sizeDelta.x);
            pos.y = (pos.y / Backgroud.rectTransform.sizeDelta.y);

            currpos = new Vector3(pos.x * 2 -1, 0, pos.y * 2-1);
            if (currpos.magnitude >= 1)
                currpos = currpos.normalized;

            JoystickBall.rectTransform.anchoredPosition =
                 new Vector3(currpos.x * (Backgroud.rectTransform.sizeDelta.x / 3), currpos.z * (Backgroud.rectTransform.sizeDelta.y / 3));
        }
    }

    public void ResetJoystickPos()
    {
        JoystickBall.rectTransform.anchoredPosition = currpos = Vector3.zero;
    }
    public float getX()
    {
       // if (currpos.x != 0)
        return currpos.x;
       
    }

    public float GetY()
    {
        return currpos.z;
    }
}
