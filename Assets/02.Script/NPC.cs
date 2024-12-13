using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private GameObject boneFire;

   
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Berry"))
        {
            Debug.Log("���� �� ������");
            MoveOutOfWay();
        } 
        else if (collision.gameObject.CompareTag("branch"))
        {
            Debug.Log("�������� Ȯ��. ��ں� �帲");
            GiveFire();
            Destroy(collision.gameObject);// branch Destroy
        }
    }

    private void MoveOutOfWay()
    {  
        transform.position += new Vector3(2f, 0, 0);
        //NPC behaviour �ٲ��ֱ�
    }

   
    private void GiveFire()
    {
        if (boneFire != null)
        {
           
            Instantiate(boneFire, transform.position + transform.forward * 2f, Quaternion.identity);
        }
        else
        {
            Debug.LogError("can't make bonefire");
        }
    }

}
