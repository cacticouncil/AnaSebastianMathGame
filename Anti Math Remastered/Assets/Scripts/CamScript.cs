using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    public LevelSelectionController Levels;
    public GameObject Car;
    public bool Move;
    public bool zoom;
    public bool Right;
   public float t = 0;
    Vector3 look;
    Vector3 OffsetR;
    Vector3 OffsetL;
    float FOV;
    float zoomr;
    private void Awake()
    {
        look = Levels.GetLevel((int)InfoManager.instance.ID).transform.position;
        OffsetR = new Vector3(look.x + 4, look.y, look.z);
        OffsetL = new Vector3(look.x - 4, look.y, look.z);
        Car.transform.position = look;
        Car.transform.LookAt(look,Vector3.back);
       // transform.LookAt(look,Vector3.up);
        transform.position = new Vector3(look.x, look.y, transform.position.z);
        FOV = Camera.main.fieldOfView;
    }

    public void ZoomPlease(bool _doIZoom)
    {
        zoom = _doIZoom;
    }
    private void FixedUpdate()
    {
        if (!InfoManager.instance.Sound)
            GetComponent<AudioSource>().Stop();
        else if(!GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play();
        if (Move)
        {
            look = Vector3.Lerp(Levels.GivePreviousLevel().transform.position, Levels.CurrentLevel().transform.position, t);
            OffsetR = new Vector3(look.x + 4, look.y, look.z);
            OffsetL = new Vector3(look.x - 4, look.y, look.z);
            transform.position = new Vector3(look.x, look.y, transform.position.z);
            Car.transform.position = look;
            t += Time.deltaTime;
            if (t > 1)
                Move = false;
            Car.transform.LookAt(Levels.CurrentLevel().transform.position, Vector3.back);
            transform.LookAt(look);

            //Car.transform.eulerAngles = new Vector3(Car.transform.localEulerAngles.x, Car.transform.localEulerAngles.y, 90);
        }
        else
        {
            t = 0;
        }

        if (zoom && !Move)
        {
            Camera.main.fieldOfView = Mathf.Lerp(FOV, 20, zoomr);
            if (look.x >= 0)
            {
                Right = true;
            transform.LookAt(Vector3.Lerp(Levels.CurrentLevel().transform.position,OffsetR, zoomr),Vector3.up);
            }
            else
            {
                Right = false;
                transform.LookAt(Vector3.Lerp(Levels.CurrentLevel().transform.position, OffsetL, zoomr), Vector3.up);
            }
            zoomr += Time.deltaTime;
            if (zoomr >= 1)
                zoomr = 1;
        }
        else if (!zoom && !Move)
        {
            Camera.main.fieldOfView = Mathf.Lerp(FOV, 20, zoomr);
            if (look.x >= 0)
            {
                transform.LookAt(Vector3.Lerp(Levels.CurrentLevel().transform.position, OffsetR, zoomr), Vector3.up);
            }
            else
            {
                transform.LookAt(Vector3.Lerp(Levels.CurrentLevel().transform.position, OffsetL, zoomr), Vector3.up);
            }
            zoomr -= Time.deltaTime;
            if (zoomr <= 0)
                zoomr = 0;
        }

    }
}
