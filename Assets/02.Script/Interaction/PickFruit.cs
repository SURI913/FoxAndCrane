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
        GameObject fruit = null;
        if (obj.transform.childCount == 0)
        {
            Debug.Log("���� ��ȣ�ۿ�");
            fruit = this.gameObject;
            fruit.transform.SetParent(obj.transform);
            //�ڽ� ��ġ ����
            fruit.transform.localPosition = new Vector3(0, -0.05f, 0.4f);
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
            transform.SetParent(collision.transform);
        }
    }
}
