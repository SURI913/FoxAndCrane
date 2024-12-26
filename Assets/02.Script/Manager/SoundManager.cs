using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource bgm_Player;
    AudioSource sfx_Player;

    public Slider bgm_Slider;
    public Slider sfx_Slider;

    [SerializeField]
    AudioClip[] audioClips;

    private void Awake()
    {
        bgm_Player = GameObject.Find("BGM").GetComponent<AudioSource>();
        sfx_Player = GameObject.Find("SFX").GetComponent<AudioSource>();

        bgm_Slider = bgm_Slider.GetComponent<Slider>();
        sfx_Slider = sfx_Slider.GetComponent<Slider>();

        bgm_Slider.onValueChanged.AddListener(BGMSound); //�����̴� �� ���� �̺�Ʈ ����
        sfx_Slider.onValueChanged.AddListener(SFXSound);

    }

    void BGMSound(float value)//�Ҹ�����
    {
        bgm_Player.volume = value;
    }
    void SFXSound(float value)//�Ҹ�����
    {
        sfx_Player.volume = value;
    }
    public void SFXPlay(int n)//ȿ���� ����
    {
        sfx_Player.clip = audioClips[n];

        sfx_Player.Play();
    }
}
