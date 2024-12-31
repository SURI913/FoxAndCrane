using System.Collections;
using UnityEngine;
using System;
using Default;
using Unity.VisualScripting;

public class SwichingCamera : MonoBehaviour
{
    public GameObject[] cameraGroup = new GameObject[2];
    public GameObject shadowObject;

    public static event Action OnSwichMovement;

    private bool isChange;

    public bool isClear { get; set; }

    private void Start()
    {
        shadowObject.SetActive(false);
        isChange = false;
        isClear = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        //플레이어 캐릭터 입장 시 백뷰 화면 전환
        if (collision.CompareTag("Player") && !isClear && PlayerData.currentCamType != Default.CameraType.Back)
        {
            OnBackView(); //backview로
            shadowObject.SetActive(true);
            OnSwichMovement?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player") && PlayerData.currentCamType != Default.CameraType.Side)
        {
            //해당 캐릭터가 백 뷰인가 체크하고 변환해도 좋지 않을까
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
        PlayerData.currentCamType = Default.CameraType.Side;
        cameraGroup[0].SetActive(true);
        cameraGroup[1].SetActive(false);
    }

    public void OnBackView()
    {
        PlayerData.currentCamType = Default.CameraType.Back;
        cameraGroup[0].SetActive(false);
        cameraGroup[1].SetActive(true);
    }
}
