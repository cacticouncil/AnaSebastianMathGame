using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    public LevelSelectionController Levels;
    public GameObject Car;
    public bool Move;
    public bool zoom;
   public float t = 0;
    Vector3 look;
    float FOV;
    float zoomr;
    private void Awake()
    {
        look = Levels.GetLevel((int)InfoManager.instance.ID).transform.position;
        Car.transform.position = look;
        Car.transform.LookAt(look,Vector3.back);
        transform.LookAt(look);
        FOV = Camera.main.fieldOfView;
    }

    public void ZoomPlease(bool _doIZoom)
    {
        zoom = _doIZoom;
    }
    private void LateUpdate()
    {
        if (Move)
        {
            look = Vector3.Lerp(Levels.GivePreviousLevel().transform.position, Levels.CurrentLevel().transform.position, t);
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

        if (zoom)
        {
            Camera.main.fieldOfView = Mathf.Lerp(FOV, 20, zoomr);
            zoomr += Time.deltaTime;
            if (zoomr >= 1)
                zoomr = 1;
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(FOV, 20, zoomr);
            zoomr -= Time.deltaTime;
            if (zoomr <= 0)
                zoomr = 0;
        }

    }
}
