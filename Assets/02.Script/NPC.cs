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
        if (isMoveout)
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
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -90f, transform.rotation.eulerAngles.z);

        }


        if (collision.gameObject.CompareTag("branch"))
        {
            Debug.Log("나뭇가지 확인. 모닥불 드림");
            GiveFire();
            Destroy(collision.gameObject);// branch Destroy
        }
    }

    private void MoveOutOfWay()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        //도착하면 정지
        if (transform.position.z == target.position.z)
        {
            Debug.Log("목표 위치 도달");
            // rb.velocity = Vector3.zero;
            isMoveout = false;

        }
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
