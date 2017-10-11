using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WheelController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public Image Backgroud;
    public Image JoystickBall;
    public Text t;
    bool AccelerateV;
    bool RevV;
    bool Brake;
    Vector3 currpos;
    float Speed;
    private void Start()
    {
        if (InfoManager.instance != null && InfoManager.instance.Gyroscope)
            this.gameObject.SetActive(false);

        Speed = 0;
        //JoystickBall.rectTransform.anchoredPosition = currpos = Vector3.one;// zero;
        JoystickBall.rectTransform.anchoredPosition =
                         new Vector3(0 * (Backgroud.rectTransform.sizeDelta.x / 3), 1 * (Backgroud.rectTransform.sizeDelta.y / 3));
        currpos = currpos.normalized;
    }

    public virtual void OnPointerDown(PointerEventData _p)
    {
        
        OnDrag(_p);
    }

    public virtual void OnPointerUp(PointerEventData _p)
    {
       // JoystickBall.rectTransform.anchoredPosition = currpos; // = Vector3.one;// zero;
    }
    public virtual void OnDrag(PointerEventData _p)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Backgroud.rectTransform, _p.position, _p.pressEventCamera, out pos))
        {
            pos.x = (pos.x / Backgroud.rectTransform.sizeDelta.x);
            pos.y = (pos.y / Backgroud.rectTransform.sizeDelta.y);

            currpos = new Vector3(pos.x * 2 - 1, 0, pos.y * 2 - 1);
            currpos = currpos.normalized;

            //    currpos.x = Mathf.Clamp(currpos.x, -0.5f, 1);

          currpos.z = Mathf.Clamp(currpos.z, 0f, 1);
            if (currpos.z <= 0)
                return;

            JoystickBall.rectTransform.anchoredPosition =
                 new Vector3(currpos.x * (Backgroud.rectTransform.sizeDelta.x / 3), currpos.z * (Backgroud.rectTransform.sizeDelta.y / 3));
            Debug.Log(currpos.x.ToString() + "***" + currpos.z.ToString());
        }
    }

    public void ResetJoystickPos()
    {
       // JoystickBall.rectTransform.anchoredPosition = currpos = Vector3.one;//zero;
    }

    public void AcceleratePlease()
    {
        AccelerateV = true;
    }
    public void DoNotAccelerate()
    {
        AccelerateV = false;
    }

    public void BrakeReversePlease()
    {
        RevV = true;
    }
    public void DoNotBRakeReverse()
    {
        RevV = false;
    }

    public void BrakePlease()
    {
        Brake = true;
    }
    public void DoNotBRake()
    {
        Brake = false;
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

    public float GetSpeed()
    {
        return Speed;
    }

    private void Update()
    {
        if (AccelerateV)
        {
            if (Speed <= 2)
                Speed += Time.deltaTime;
        }
        else if(!AccelerateV)
        {
            if (Speed >0)
                Speed -= Time.deltaTime/10;
        }
        /*else*/ if (RevV)
        {
            if (Speed >= -2)
                Speed -= Time.deltaTime;
        }
        else if (!RevV)
        {
            if (Speed <= 0)
                Speed += Time.deltaTime/10;
        }
        /*else*/ if (Brake)
        {
            if (Speed > 0)
                Speed -= Time.deltaTime*2;
            else if (Speed <= 0)
                Speed += Time.deltaTime*2;
        }

        t.text = Speed.ToString();
    }
}

