using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interaction(GameObject obj);
}

//이 밑으로 오브젝트 풀링용 인터페이스 만들것 I~albe