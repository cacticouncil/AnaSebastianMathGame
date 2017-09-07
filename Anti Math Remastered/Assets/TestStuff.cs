using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStuff : MonoBehaviour {

    public GameObject ItemToPopulate;

    List<GameObject> Items;

    private void Start()
    {
        Items = new List<GameObject>();
    }
    public void Populate()
    {
        int amount = (int)Random.Range(1, 10);
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
            GameObject temp = Instantiate(ItemToPopulate);
            Items.Add(temp);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            Populate();
    }
}
