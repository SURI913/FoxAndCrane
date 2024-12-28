using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBranch : MonoBehaviour, ICraneInteractable
{
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    public void Interaction(CraneInteraction obj)
    {
     
        transform.SetParent(null);
        rigid.isKinematic = false;
    }
}
