using System;
using UnityEngine;
using Default;

public class Player : MonoBehaviour
{
    [Header("이동 속도 조절")]
    public float moveSpeed = 5f; // 이동 속도
    [Header("점프 높이 조절")]
    public float jumpForce = 7f; // 점프 힘
    [Header("[테스트용] true: 횡스크롤, false: 탑뷰")]
    public bool isSideScroll = true;

    protected Rigidbody myRigidBody;
    private bool isGrounded;

    protected virtual void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

        isGrounded = false;

        PlayerData.currentPlayer = GetPlayerType();       
        //먼저 시작할 개체만 스크립트 활성화
    }

    protected virtual void Update()
    {

        //사용자 캐릭터 변경
        if (Input.GetKeyDown(KeyCode.Z) && isActiveAndEnabled)
        {
            SetPlayerType(PlayerData.currentPlayer == PlayerType.Fox ? PlayerType.Crane : PlayerType.Fox);
            print("현재 움직일 수 있는 캐릭터: " + PlayerData.currentPlayer);
        }

        MoveMent();
        Jump();        
    }

    public void SetPlayerType(PlayerType changeType)
    {
        PlayerData.currentPlayer = changeType;
        print(PlayerData.currentPlayer);
        //자식 업데이트 제어
        foreach (Player player in FindObjectsOfType<Player>())
        {         
            player.enabled = (player.GetPlayerType() == changeType);
            Debug.Log($"{player.GetPlayerType()} : {player.GetPlayerType() == changeType}");
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

        Vector3 movement = isSideScroll
            ? new Vector3(moveX, 0, 0)
            : new Vector3(moveX, 0, moveZ);

        //이동처리 [물리] normalized필요없음
        myRigidBody.velocity = new Vector3(
            movement.x * moveSpeed,
            myRigidBody.velocity.y,
            movement.z * moveSpeed
        );
        //이동처리 [포지션] normalized 필요
        //transform.position += movement * moveSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        // 점프 처리 : 스페이스바
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            //print("점프함");
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
            //print( "땅에 닿음");
        }
    }
}
