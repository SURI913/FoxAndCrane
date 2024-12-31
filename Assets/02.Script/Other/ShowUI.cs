using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject MyUI;

    private void Start()
    {
        MyUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�����ȿ� ����
        if (other.CompareTag("Player"))
        {
            MyUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //���� �ȿ��� ���
        if (other.CompareTag("Player"))
        {
            MyUI.SetActive(false);
        }
    }
}
