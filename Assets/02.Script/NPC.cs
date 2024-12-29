using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private GameObject boneFire;
    [SerializeField]
    public Transform target;
    public float moveSpeed = 1f; // �̵� �ӵ�
  


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Berry"))
        {
            Debug.Log("���� Ȯ��, �� ������");
            MoveOutOfWay();
        } 


        if(collision.gameObject.CompareTag("branch"))
        {
            Debug.Log("�������� Ȯ��. ��ں� �帲");
            GiveFire();
            Destroy(collision.gameObject);// branch Destroy
        }
    }

    private void MoveOutOfWay()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
        /*
                float targetPositionZ = transform.position.z + 2f;

                // Z�� �������� �ε巴�� �̵�
                float smoothZ = Mathf.Lerp(transform.position.z, targetPositionZ, Time.deltaTime * moveSpeed);

                transform.position = new Vector3(transform.position.x, transform.position.y, smoothZ);
        */
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
