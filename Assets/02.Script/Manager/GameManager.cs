using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Header("GameObject")]
    [SerializeField]
    GameObject optionPanel;

    [Header("Manager")]
    public SoundManager soundManager;
    public ScenesManager scenesManager;
    public static GameManager Instance
    {
        get
        {
            //�ν��Ͻ��� ���°�� �ν��Ͻ� �Ҵ�
            if(!instance)
            {
                instance = FindObjectOfType(typeof(GameManager))as GameManager;
            }
            return instance;
        }
    }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }


    //�߰� ���
    public void GameStart() //���� ����
    {
        scenesManager.ChanageScene("InteractionTest");
    }
    
    public void SoundOption() //�Ҹ� ����
    {
        optionPanel.SetActive(true);
    }

    public void OptionQuit()
    {
        optionPanel.SetActive(false);
    }

    public void GameQuit() //���� ����
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}
