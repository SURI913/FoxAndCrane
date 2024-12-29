
using UnityEngine;
using Default;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{
    [Header("�̵� �ӵ� ����")]
    public float moveSpeed = 5f; // �̵� �ӵ�
    [Header("���� ���� ����")]
    public float jumpForce = 7f; // ���� ��
    [Header("[�׽�Ʈ��] true: Ⱦ��ũ��, false: ž��")]
    public bool isSideScroll = true;

    protected Rigidbody myRigidBody;
    private bool isGrounded;
    private bool isBorder;
    private bool isReversing;
    private Vector3 movement;
    Animator myAnimator;

    // �̺�Ʈ ����
    public static event Action OnSwitchObject;
    public static event Action OnSwitchSide;
    public static event Action OnSwitchBack;

    protected virtual void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;

        isGrounded = false;

        PlayerData.currentPlayer = GetPlayerType();       
        //���� ������ ��ü�� ��ũ��Ʈ Ȱ��ȭ
    }

    protected virtual void Update()
    {
        if (isReversing)
        {
            myAnimator.SetBool("isWalk", false);
            return; //������ ������
        }

        //����� ĳ���� ����
        if (Input.GetKeyDown(KeyCode.Z) && isActiveAndEnabled)
        {
            SetPlayerType(PlayerData.currentPlayer == PlayerType.Fox ? PlayerType.Crane : PlayerType.Fox);
            // �̺�Ʈ ȣ��
            OnSwitchObject?.Invoke();
            print("���� ������ �� �ִ� ĳ����: " + PlayerData.currentPlayer);
            //ī�޶� ��ȯ?
            myAnimator.SetBool("isWalk", false);
            
        }

        MoveMent();
        Jump();        
    }

    protected void FixedUpdate()
    {
        FreezeRotation();
        IsCollideWall();
    }

    private void FreezeRotation()
    {
        //�ܺ� �浹 ȸ�� ����
        myRigidBody.angularVelocity = Vector3.zero;
    }
    private void IsCollideWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 0.8f, Color.green);
        isBorder = Physics.Raycast(transform.position, transform.forward, 0.8f, LayerMask.GetMask("Wall"));
    }

    public void SetPlayerType(PlayerType changeType)
    {
        PlayerData.currentPlayer = changeType;
        //�ڽ� ������Ʈ ����
        foreach (PlayerMovement player in FindObjectsOfType<PlayerMovement>())
        {         
            player.enabled = (player.GetPlayerType() == changeType);
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

        movement = isSideScroll
            ? new Vector3(moveX, 0, 0)
            : new Vector3(moveZ, 0, -moveX);
 
        movement = movement.normalized;

        //�̵�ó�� [����] normalized�ʿ����
        /*myRigidBody.velocity = new Vector3(
            movement.x * moveSpeed,
            myRigidBody.velocity.y,
            movement.z * moveSpeed
        );*/
        //�̵�ó�� [������] normalized �ʿ�
        if (!isBorder)
        {
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
        myAnimator.SetBool("isWalk", movement != Vector3.zero);

        if (isSideScroll)
        {
            Turn();
        }
    }

    private void Jump()
    {
        // ���� ó�� : �����̽���
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            myAnimator.SetTrigger("isJump");
            //print("������");
        }
    }  
    
    private void Turn()
    {
        transform.LookAt(transform.position + movement); //������ �������� ȸ�� //�Ⱦ��� �ּ�ó��
    }

    void OnCollisionEnter(Collision collision)
    {
        // �ٴڿ� ������ ���� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //print( "���� ����");
        }
        else if (collision.gameObject.CompareTag("Crow"))
        {
            StartCoroutine(ReverseMovement());
        }
        
    }

    public IEnumerator ReverseMovement()
    {

        isReversing = true; // �Է°� ���� ����

        // ���� ����
        float reverseTime = 1f; // ���� ���� �ð�
        float elapsedTime = 0f;

        while (elapsedTime < reverseTime)
        {
            movement = Vector3.back;
            transform.Translate(movement * moveSpeed * Time.deltaTime);
            //Turn(); //=> ������� rotation y =180�� �� ������?
            //transform.rotation = new Quaternion(0,-90,0,0);
            // => ������� rotation y = -180�� �� ������?
            elapsedTime += Time.deltaTime;
            yield return null; // �� ������ ���
        }

        isReversing = false; // �Է°� ���� ����
    }
     
    private void OnSwichMovement()
    {
        ReversingControll(); //ī�޶� ���⿡ ���缭 �׷���
        //������� ������ ������ �� ����Ű�����ؼ�
        isSideScroll = !isSideScroll;
        Invoke("ReversingControll", 2f);
        
    }
    private void ReversingControll()
    {
        isReversing = !isReversing;
    }
    private void OnEnable()
    {
        Debug.Log("������ ���� �̺�Ʈ ���� �Ϸ�");
        // �̺�Ʈ ����
        SwichingCamera.OnSwichMovement += OnSwichMovement;


        if (isSideScroll) OnSwitchSide?.Invoke();
        else OnSwitchBack?.Invoke(); ;
    }

    private void OnDisable()
    {
        Debug.Log("������ ���� �̺�Ʈ ���� ����");

        // �̺�Ʈ ���� ����
        SwichingCamera.OnSwichMovement -= OnSwichMovement;
    }
}
