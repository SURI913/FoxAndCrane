using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private GameObject boneFire;
    public float moveSpeed = 2f; // 이동 속도
  


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Berry"))
        {
            Debug.Log("열매 왕 비켜줌");
            MoveOutOfWay();
        } 


        if(collision.gameObject.CompareTag("branch1"))
        {
            Debug.Log("나뭇가지 확인. 모닥불 드림");
            GiveFire();
           Destroy(collision.gameObject);// branch Destroy
        }
    }

    private void MoveOutOfWay()
    {
        float targetPositionZ = transform.position.z + 2f;

        // Z축 방향으로 부드럽게 이동
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
