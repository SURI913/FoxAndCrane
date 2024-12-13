using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICraneInteractable
{
    void Interaction(CraneInteraction obj);
}
public interface IFoxInteractable
{
    void Interaction(FoxInteraction obj);
}

//이 밑으로 오브젝트 풀링용 인터페이스 만들것 I~albe