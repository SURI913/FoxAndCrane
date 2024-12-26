using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private GameObject boneFire;
    public float moveSpeed = 2f; // �̵� �ӵ�
  


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Berry"))
        {
            Debug.Log("���� �� ������");
            MoveOutOfWay();
        } 


        if(collision.gameObject.CompareTag("branch1"))
        {
            Debug.Log("�������� Ȯ��. ��ں� �帲");
            GiveFire();
           Destroy(collision.gameObject);// branch Destroy
        }
    }

    private void MoveOutOfWay()
    {
        float targetPositionZ = transform.position.z + 2f;

        // Z�� �������� �ε巴�� �̵�
        float smoothZ = Mathf.Lerp(transform.position.z, targetPositionZ, Time.deltaTime * moveSpeed);
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
