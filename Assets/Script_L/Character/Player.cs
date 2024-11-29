using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("�̵� �ӵ� ����")]
    public float moveSpeed = 5f; // �̵� �ӵ�
    [Header("���� ���� ����")]
    public float jumpForce = 7f; // ���� ��
    [Header("[�׽�Ʈ��] true: Ⱦ��ũ��, false: ž��")]
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
        // �Է� �ޱ�
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

        // �̵� ó��
        myRigidBody.velocity =
            new Vector3(movement.x * moveSpeed, myRigidBody.velocity.y, movement.z * moveSpeed);
    }

    private void Jump()
    {
        // ���� ó�� : �����̽���
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Console.WriteLine("������");
        }
    }
    
    private void Turn()
    {
        //ĳ���Ϳ� ȸ���� �ʿ����� ���������
    }

    void OnCollisionEnter(Collision collision)
    {
        // �ٴڿ� ������ ���� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Console.WriteLine( "���� ����");
        }
    }
}
