using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : ICraneInteractable
{
    [SerializeField] float timer;

    void Update()
    {
        timer += Time.deltaTime;
        
    }
    public void Interaction(CraneInteraction obj)
    {
        //�η�̰� �����Ÿ��� ��� �� ȶ���� ������.
    }
}
