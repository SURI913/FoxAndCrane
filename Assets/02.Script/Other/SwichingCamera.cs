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
        
        //�÷��̾� ĳ���� ���� �� ȭ�� ��ȯ�ϴ� �� ĳ���Ͱ� �ΰ��ϱ� �� �� �����ؾ��� �ǵ��� �ؾ��ϳ�?
        if (collision.CompareTag("Player"))
        {
            OnBackView(); //backview��
            shadowObject.SetActive(true);
            OnSwichMovement?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //�÷��̾� ĳ���� ���� �� ȭ�� ��ȯ
        if (collision.CompareTag("Player"))
        {
            OnSideView();
            shadowObject.SetActive(false);
            OnSwichMovement?.Invoke();
        }
    }

    private void OnEnable()
    {
        Debug.Log("ī�޶� �� ���� ���� �Ϸ�");
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
