using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour {

    public GameObject ElementContained;
    List<GameObject> ContainedElements;

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
        ContainedElements = new List<GameObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            FillThemUp();
    }
    void FillThemUp()
    {
        if (ContainedElements.Count != 0)
        {
            for (int i = 0; i < ContainedElements.Count; i++)
            {
                Destroy(ContainedElements[i]);
            }
            ContainedElements.Clear();
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(ElementContained, GetComponentInParent<Transform>());
            temp.GetComponent<Rigidbody>().isKinematic = false;
            ContainedElements.Add(temp);
        }

    }

    public void Populate()
    {
        int amount = 0;
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
        if (ContainedElements.Count != 0)
        {
            for (int i = 0; i < ContainedElements.Count; i++)
            {
                Destroy(ContainedElements[i]);
            }
            ContainedElements.Clear();
        }
        for (int i = 0; i < amount; i++)
        {
            GameObject temp = Instantiate(ElementContained, GetComponentInParent<Transform>());
            temp.GetComponent<Rigidbody>().isKinematic = false;
            ContainedElements.Add(temp);
        }
    }

    void EndThem()
    {
        if (ContainedElements.Count != 0)
        {
            for (int i = 0; i < ContainedElements.Count; i++)
            {
                Destroy(ContainedElements[i]);
            }
            ContainedElements.Clear();
        }
    }

}
