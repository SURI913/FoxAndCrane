using System.Collections;
using UnityEngine;
using System;
using Default;

public class SwichingCamera : MonoBehaviour
{
    public GameObject[] cameraGroup = new GameObject[2];
    public GameObject shadowObject;

    public static event Action OnSwichMovement;

    private void Start()
    {
        shadowObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        //플레이어 캐릭터 입장 시 화면 전환하는 걸 캐릭터가 두개니까 둘 다 도착해야지 되도록 해야하나?
        if (collision.CompareTag("Player"))
        {
            OnBackView(); //backview로
            shadowObject.SetActive(true);
            OnSwichMovement?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //플레이어 캐릭터 입장 시 화면 전환
        if (collision.CompareTag("Player"))
        {
            OnSideView();
            shadowObject.SetActive(false);
            OnSwichMovement?.Invoke();
        }
    }

    private void OnEnable()
    {
        Debug.Log("카메라 뷰 변경 구독 완료");
        PlayerMovement.OnSwitchSide += OnSideView;
        PlayerMovement.OnSwitchBack += OnBackView;
    }

    private void OnDisable()
    {
        PlayerMovement.OnSwitchSide -= OnSideView;
        PlayerMovement.OnSwitchBack -= OnBackView;
    }

    public void OnSideView()
    {
        cameraGroup[0].SetActive(true);
        cameraGroup[1].SetActive(false);
    }

    public void OnBackView()
    {
        cameraGroup[0].SetActive(false);
        cameraGroup[1].SetActive(true);
    }
}
