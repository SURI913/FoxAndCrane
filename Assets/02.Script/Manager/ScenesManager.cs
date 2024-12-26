using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    
    private void Awake()
    {
        //scene �ε��̺�Ʈ ���
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;// scene�ε� �̺�Ʈ ����
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //ȭ�� ��ȯ ������ ���ΰ�ħ
        //�ʿ� �� ���

    }

    public void ChanageScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
