using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxInteraction : PlayerInteraction
{
    private void Update()
    {
        HitRayCast();
    }
    protected override void HitRayCast()
    {
        //레이캐스트를 쏴서 닿이는 오브젝트와 상호작용 
        //※캐릭터가 flip 하면 레이캐스트 방향 바꿔주기
        Debug.DrawRay(transform.position, transform.forward * length, Color.red);
        if (Input.GetKeyDown(KeyCode.G))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, length))
            {
                IFoxInteractable interactable = hit.collider.GetComponent<IFoxInteractable>();
                {
                    if (interactable != null) //상호작용
                    {
                        interactable.Interaction(this);
                    }
                }
            }
        }
    }
}
