using System;
using UnityEngine;
using Default;

public class Player : MonoBehaviour
{
    [Header("�̵� �ӵ� ����")]
    public float moveSpeed = 5f; // �̵� �ӵ�
    [Header("���� ���� ����")]
    public float jumpForce = 7f; // ���� ��
    [Header("[�׽�Ʈ��] true: Ⱦ��ũ��, false: ž��")]
    public bool isSideScroll = true;

    protected Rigidbody myRigidBody;
    private bool isGrounded;

    protected virtual void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

        isGrounded = false;

        PlayerData.currentPlayer = GetPlayerType();       
        //���� ������ ��ü�� ��ũ��Ʈ Ȱ��ȭ
    }

    protected virtual void Update()
    {

        //����� ĳ���� ����
        if (Input.GetKeyDown(KeyCode.Z) && isActiveAndEnabled)
        {
            SetPlayerType(PlayerData.currentPlayer == PlayerType.Fox ? PlayerType.Crane : PlayerType.Fox);
            print("���� ������ �� �ִ� ĳ����: " + PlayerData.currentPlayer);
        }

        MoveMent();
        Jump();        
    }

    public void SetPlayerType(PlayerType changeType)
    {
        PlayerData.currentPlayer = changeType;
        print(PlayerData.currentPlayer);
        //�ڽ� ������Ʈ ����
        foreach (Player player in FindObjectsOfType<Player>())
        {         
            player.enabled = (player.GetPlayerType() == changeType);
            Debug.Log($"{player.GetPlayerType()} : {player.GetPlayerType() == changeType}");
        }
    }
    protected virtual PlayerType GetPlayerType()
    {
        return PlayerType.None; //�ڽĿ��� ����
    }

    private void MoveMent()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = isSideScroll ? 0 : Input.GetAxis("Vertical");

        Vector3 movement = isSideScroll
            ? new Vector3(moveX, 0, 0)
            : new Vector3(moveX, 0, moveZ);

        //�̵�ó�� [����] normalized�ʿ����
        myRigidBody.velocity = new Vector3(
            movement.x * moveSpeed,
            myRigidBody.velocity.y,
            movement.z * moveSpeed
        );
        //�̵�ó�� [������] normalized �ʿ�
        //transform.position += movement * moveSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        // ���� ó�� : �����̽���
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            //print("������");
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
            //print( "���� ����");
        }
    }
}
