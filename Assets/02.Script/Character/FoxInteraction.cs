using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoxInteraction : PlayerInteraction
{
    
    public Image keyG;
    public float sphereRadius; // ���� ������
    public float rayLength;// ���� ����
    public Color debugColor = Color.red; // Debug ����
    private void Update()
    {
        HitRayCast();
    }
    protected override void HitRayCast()
    {
        // Ray�� ���� ��ġ�� ����
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, rayLength))
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
            keyG.color = new Color(0f, 0f, 0f, 0f); // ��ȣ�ۿ� �Ұ��� �� �� ����
        }
        // Debug �ð�ȭ
        Debug.DrawLine(origin, origin + direction * rayLength, debugColor); // Ray �ð�ȭ
        DrawSphereAtRayEnd(origin + direction * rayLength, sphereRadius); // Ray ���� Sphere �ð�ȭ
    }

    void DrawSphereAtRayEnd(Vector3 position, float radius)
    {
        // Sphere�� ǥ���ϱ� ���� �پ��� ����
        Debug.DrawRay(position, Vector3.up * radius, debugColor);
        Debug.DrawRay(position, Vector3.down * radius, debugColor);
        Debug.DrawRay(position, Vector3.left * radius, debugColor);
        Debug.DrawRay(position, Vector3.right * radius, debugColor);
        Debug.DrawRay(position, Vector3.forward * radius, debugColor);
        Debug.DrawRay(position, Vector3.back * radius, debugColor);
    }

}
