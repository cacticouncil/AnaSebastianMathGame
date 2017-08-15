using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    //List of things to get info from
    public GameObject AnimalManagController;
    public GameObject player;
    List<GameObject> Targets;
    GameObject CurrTarget;
	// Use this for initialization
	void Start () {
        Targets = AnimalManagController.GetComponent<AnimalManagerController>().Animals;
	}
	
	// Update is called once per frame
	void Update () {
        if (AnimalController.AnimalCount <= 0)
            Destroy(gameObject);
        float highest = float.MaxValue;
        for (int i = 0; i <= Targets.Count-1; i++)
        {
            if (Mathf.Abs( Distance(transform,Targets[i].transform)) < highest)
            {
             CurrTarget = Targets[i];
                highest = Mathf.Abs(Distance(transform, Targets[i].transform));
            }
        }

        transform.LookAt(CurrTarget.transform,player.transform.up);
        Debug.Log("targeting animal num. " + CurrTarget.GetComponent<AnimalController>().AnimalID);
	}

    float Distance(Transform _from, Transform _to)
    {
        return (_to.position.x - _from.position.x)*(_to.position.x - _from.position.x)+
            (_to.position.y - _from.position.y) * (_to.position.y - _from.position.y)+
            (_to.position.z - _from.position.z) * (_to.position.z - _from.position.z);
    }
}
