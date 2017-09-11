using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStuff : MonoBehaviour {

    public GameObject ItemToPopulate;
    public GameObject canvas;
    List<GameObject> Items;

    public int BucketID;

    private void OnEnable()
    {
        GameManager.SetBasket += Populate;
        GameManager.QuestionTime += EndThem;
    }

    private void OnDisable()
    {
        GameManager.SetBasket -= Populate;
        GameManager.QuestionTime -= EndThem;
    }
    private void Start()
    {
        Items = new List<GameObject>();
    }
    public void Populate()
    {
        int amount =0;
        switch (BucketID)
        {
            case 1:
                amount = GameManager.instance.a;
                break;
            case 2:
                amount = GameManager.instance.b;
                break;
        }
        Debug.Log(amount);
        if (Items.Count != 0 )
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Destroy(Items[i]);
            }
            Items.Clear();
        }
        for (int i = 0; i < amount; i++)
        {
            GameObject temp = Instantiate(ItemToPopulate, canvas.transform);
            temp.GetComponent<Rigidbody>().isKinematic = false;
            //temp.transform.SetParent();
            Items.Add(temp);
        }
    }

    void EndThem()
    {
        if (Items.Count != 0)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Destroy(Items[i]);
            }
            Items.Clear();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Populate();
    }
}
