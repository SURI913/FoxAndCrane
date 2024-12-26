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
            //인스턴스가 없는경우 인스턴스 할당
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


    //추가 기능
    public void GameStart() //게임 시작
    {
        scenesManager.ChanageScene("InteractionTest");
    }
    
    public void SoundOption() //소리 설정
    {
        optionPanel.SetActive(true);
    }

    public void OptionQuit()
    {
        optionPanel.SetActive(false);
    }

    public void GameQuit() //게임 종료
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}
