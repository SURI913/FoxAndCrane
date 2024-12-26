using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFruit : MonoBehaviour, ICraneInteractable
{
    Rigidbody rigid;



    void Awake()

    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody>();
        }
        

    }
    public void Interaction(CraneInteraction obj)
    {
        if (obj.transform.childCount == 0)
        {
            transform.SetParent(obj.transform);
        }
        else
        {
            transform.SetParent(null);
            rigid.isKinematic = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            rigid.isKinematic = true;
        }
    }
}
