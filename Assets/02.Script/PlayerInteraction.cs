using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour //������ ���츦 �����°� ����? ����
{
    
    const float length = 1.5f;
    void Update()
    {
        //����ĳ��Ʈ�� ���� ���̴� ������Ʈ�� ��ȣ�ۿ� 
        Debug.DrawRay(transform.position, transform.forward * length, Color.red);
        if (Input.GetKeyDown(KeyCode.G))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, length))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                {
                    if (interactable != null) //��ȣ�ۿ�
                    {
                        interactable.Interaction(gameObject);
                    }
                }
            }
        }
    }
}
