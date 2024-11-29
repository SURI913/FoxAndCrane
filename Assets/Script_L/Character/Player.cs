using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("이동 속도 조절")]
    public float moveSpeed = 5f; // 이동 속도
    [Header("점프 높이 조절")]
    public float jumpForce = 7f; // 점프 힘
    [Header("[테스트용] true: 횡스크롤, false: 탑뷰")]
    public bool isSideScroll = true;

    private Rigidbody myRigidBody;
    private bool isGrounded; 

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        isGrounded = false;
    }

    void Update()
    {
        // 입력 받기
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = isSideScroll ? 0 : Input.GetAxis("Vertical");

        MoveMent(moveX, moveZ);
        Jump();
    }

    private void MoveMent(float moveX, float moveZ)
    {
        Vector3 movement = isSideScroll
            ? new Vector3(moveX, 0, 0)
            : new Vector3(moveX, 0, moveZ);

        // 이동 처리
        myRigidBody.velocity =
            new Vector3(movement.x * moveSpeed, myRigidBody.velocity.y, movement.z * moveSpeed);
    }

    private void Jump()
    {
        // 점프 처리 : 스페이스바
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Console.WriteLine("점프함");
        }
    }
    
    private void Turn()
    {
        //캐릭터에 회전이 필요한지 물어봐야함
    }

    void OnCollisionEnter(Collision collision)
    {
        // 바닥에 닿으면 점프 가능
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Console.WriteLine( "땅에 닿음");
        }
    }
}
