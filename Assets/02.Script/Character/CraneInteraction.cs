using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraneInteraction : PlayerInteraction
{
    public float sphereRadius; // 구의 반지름
    public float rayLength; // 레이 길이
    public Color debugColor = Color.red; // Debug 색상

    public Animator myAnimator;

    private void Update()
    {
        HitRayCast();
    }

    protected override void HitRayCast()
    {
        // Ray의 시작 위치와 방향
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hit;

        // SphereCast 실행
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, rayLength))
        {
            // Interactable 검사
            ICraneInteractable interactable = hit.collider.GetComponent<ICraneInteractable>();
            if (interactable != null)
            {

                if (Input.GetKeyDown(KeyCode.G))
                {
                    interactable.Interaction(this);
                    myAnimator.SetTrigger("Pick");
                }
            }
        }
        // Debug 시각화
        Debug.DrawLine(origin, origin + direction * rayLength, debugColor); // Ray 시각화
        DrawSphereAtRayEnd(origin + direction * rayLength, sphereRadius); // Ray 끝에 Sphere 시각화
    }
    // Sphere를 그리는 Debug 메서드
    void DrawSphereAtRayEnd(Vector3 position, float radius)
    {
        // Sphere를 표현하기 위한 다양한 방향
        Debug.DrawRay(position, Vector3.up * radius, debugColor);
        Debug.DrawRay(position, Vector3.down * radius, debugColor);
        Debug.DrawRay(position, Vector3.left * radius, debugColor);
        Debug.DrawRay(position, Vector3.right * radius, debugColor);
        Debug.DrawRay(position, Vector3.forward * radius, debugColor);
        Debug.DrawRay(position, Vector3.back * radius, debugColor);
    }
}
