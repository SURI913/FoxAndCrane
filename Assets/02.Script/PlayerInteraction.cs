using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour //거위와 여우를 나누는게 좋나? 생각
{
    
    const float length = 1.5f;
    void Update()
    {
        //레이캐스트를 쏴서 닿이는 오브젝트와 상호작용 
        Debug.DrawRay(transform.position, transform.forward * length, Color.red);
        if (Input.GetKeyDown(KeyCode.G))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, length))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                {
                    if (interactable != null) //상호작용
                    {
                        interactable.Interaction(gameObject);
                    }
                }
            }
        }
    }
}
