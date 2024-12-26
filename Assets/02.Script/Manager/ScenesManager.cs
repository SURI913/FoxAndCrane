using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    
    private void Awake()
    {
        //scene 로드이벤트 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;// scene로드 이벤트 해제
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //화면 전환 데이터 새로고침
        //필요 시 사용

    }

    public void ChanageScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
