using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoxInteraction : PlayerInteraction
{
    [SerializeField]
    Image keyG;
    private void Update()
    {
        HitRayCast();
    }
    protected override void HitRayCast()
    {
        //����ĳ��Ʈ�� ���� ���̴� ������Ʈ�� ��ȣ�ۿ� 
        //��ĳ���Ͱ� flip �ϸ� ����ĳ��Ʈ ���� �ٲ��ֱ�
        Debug.DrawRay(transform.position, transform.forward * length, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, length))
        {
            IFoxInteractable interactable = hit.collider.GetComponent<IFoxInteractable>();
            if (interactable != null)
            {
                keyG.color = Color.white;
                if (Input.GetKeyDown(KeyCode.G)) //��ȣ�ۿ�
                {
                    interactable.Interaction(this);
                    
                }
            }
        }
        else
        {
            keyG.color = Color.gray;
        }
    }
}
