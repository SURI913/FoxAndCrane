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
    public float moveSpeed = 5f; // 이동 속도
   // public Vector3 targetPosition;
    private bool isMoveout = false;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        if(isMoveout)
        {
            MoveOutOfWay();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Berry"))
        {
            Debug.Log("열매 확인, 왕 비켜줌");
           // MoveOutOfWay();
            isMoveout = true;

        } 


        if(collision.gameObject.CompareTag("branch"))
        {
            Debug.Log("나뭇가지 확인. 모닥불 드림");
            GiveFire();
            Destroy(collision.gameObject);// branch Destroy
        }
    }

    private void MoveOutOfWay()
    {

        //ismoveout 으로 함수를 업데이트에 돌려보자 ; 그냥 개빡친다 ;
       // target.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // 목표 위치까지 서서히 이동 (속도 증가)
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // 목표 위치에 도달하면 이동 종료
        if (transform.position.z == target.position.z)
        {
            Debug.Log("목표 위치 도달");
           // rb.velocity = Vector3.zero;
            isMoveout = false;

        }

        /*Vector3 currentPosition = transform.position;
        currentPosition.z += 1.0f; // 1.0f만큼 Z축 이동
        transform.position = currentPosition;*/
        // transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
        /*
                float targetPositionZ = transform.position.z + 2f;

                // Z축 방향으로 부드럽게 이동
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
