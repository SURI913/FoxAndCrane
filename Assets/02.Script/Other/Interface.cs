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

//�� ������ ������Ʈ Ǯ���� �������̽� ����� I~albe