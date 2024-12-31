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
        //범위안에 들어옴
        if (other.CompareTag("Player"))
        {
            MyUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //범위 안에서 벗어남
        if (other.CompareTag("Player"))
        {
            MyUI.SetActive(false);
        }
    }
}
