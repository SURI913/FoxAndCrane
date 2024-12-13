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
        //두루미가 사정거리를 벗어날 시 횃불이 꺼진다.
    }
}
