
using UnityEngine;
using Default;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{
    [Header("이동 속도 조절")]
    public float moveSpeed = 5f; // 이동 속도
    [Header("점프 높이 조절")]
    public float jumpForce = 7f; // 점프 힘
    [Header("[테스트용] true: 횡스크롤, false: 탑뷰")]
    public bool isSideScroll = true;

    protected Rigidbody myRigidBody;
    private bool isGrounded;
    private bool isBorder;
    private bool isReversing;
    private Vector3 movement;
    Animator myAnimator;

    // 이벤트 선언
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
        //먼저 시작할 개체만 스크립트 활성화
    }

    protected virtual void Update()
    {
        if (isReversing)
        {
            myAnimator.SetBool("isWalk", false);
            return; //움직임 제한중
        }

        //사용자 캐릭터 변경
        if (Input.GetKeyDown(KeyCode.Z) && isActiveAndEnabled)
        {
            SetPlayerType(PlayerData.currentPlayer == PlayerType.Fox ? PlayerType.Crane : PlayerType.Fox);
            // 이벤트 호출
            OnSwitchObject?.Invoke();
            print("현재 움직일 수 있는 캐릭터: " + PlayerData.currentPlayer);
            //카메라 전환?
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
        //외부 충돌 회전 제어
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
        //자식 업데이트 제어
        foreach (PlayerMovement player in FindObjectsOfType<PlayerMovement>())
        {         
            player.enabled = (player.GetPlayerType() == changeType);
        }
    }
    protected virtual PlayerType GetPlayerType()
    {
        return PlayerType.None; //자식에서 구현
    }

    private void MoveMent()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = isSideScroll ? 0 : Input.GetAxis("Vertical");

        movement = isSideScroll
            ? new Vector3(moveX, 0, 0)
            : new Vector3(moveZ, 0, -moveX);
 
        movement = movement.normalized;

        //이동처리 [물리] normalized필요없음
        /*myRigidBody.velocity = new Vector3(
            movement.x * moveSpeed,
            myRigidBody.velocity.y,
            movement.z * moveSpeed
        );*/
        //이동처리 [포지션] normalized 필요
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
        // 점프 처리 : 스페이스바
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            myAnimator.SetTrigger("isJump");
            //print("점프함");
        }
    }  
    
    private void Turn()
    {
        transform.LookAt(transform.position + movement); //움직일 방향으로 회전 //안쓰면 주석처리
    }

    void OnCollisionEnter(Collision collision)
    {
        // 바닥에 닿으면 점프 가능
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //print( "땅에 닿음");
        }
        else if (collision.gameObject.CompareTag("Crow"))
        {
            StartCoroutine(ReverseMovement());
        }
        
    }

    public IEnumerator ReverseMovement()
    {

        isReversing = true; // 입력값 제한 시작

        // 후퇴 동작
        float reverseTime = 1f; // 후퇴 지속 시간
        float elapsedTime = 0f;

        while (elapsedTime < reverseTime)
        {
            movement = Vector3.back;
            transform.Translate(movement * moveSpeed * Time.deltaTime);
            //Turn(); //=> 결과값이 rotation y =180이 들어감 이유는?
            //transform.rotation = new Quaternion(0,-90,0,0);
            // => 결과값이 rotation y = -180이 들어감 이유는?
            elapsedTime += Time.deltaTime;
            yield return null; // 한 프레임 대기
        }

        isReversing = false; // 입력값 제한 해제
    }
     
    private void OnSwichMovement()
    {
        ReversingControll(); //카메라 방향에 맞춰서 그런가
        //어느정도 문구가 떠야할 듯 방향키관련해서
        isSideScroll = !isSideScroll;
        Invoke("ReversingControll", 2f);
        
    }
    private void ReversingControll()
    {
        isReversing = !isReversing;
    }
    private void OnEnable()
    {
        Debug.Log("움직임 제어 이벤트 구독 완료");
        // 이벤트 구독
        SwichingCamera.OnSwichMovement += OnSwichMovement;


        if (isSideScroll) OnSwitchSide?.Invoke();
        else OnSwitchBack?.Invoke(); ;
    }

    private void OnDisable()
    {
        Debug.Log("움직임 제어 이벤트 구독 해제");

        // 이벤트 구독 해제
        SwichingCamera.OnSwichMovement -= OnSwichMovement;
    }
}
