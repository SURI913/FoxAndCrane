using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private GameObject boneFire;
    [SerializeField]
    public Transform target;
    public float moveSpeed = 5f; // �̵� �ӵ�
                                 // public Vector3 targetPosition;
    private bool isMoveout = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if (isMoveout)
        {
            MoveOutOfWay();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Berry"))
        {
            Debug.Log("���� Ȯ��, �� ������");
            // MoveOutOfWay();
            isMoveout = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -90f, transform.rotation.eulerAngles.z);

        }


        if (collision.gameObject.CompareTag("branch"))
        {
            Debug.Log("�������� Ȯ��. ��ں� �帲");
            GiveFire();
            Destroy(collision.gameObject);// branch Destroy
        }
    }

    private void MoveOutOfWay()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        //�����ϸ� ����
        if (transform.position.z == target.position.z)
        {
            Debug.Log("��ǥ ��ġ ����");
            // rb.velocity = Vector3.zero;
            isMoveout = false;

        }
    }


    private void GiveFire()
    {
        if (boneFire != null)
        {

            Instantiate(boneFire, transform.position + transform.forward * 2f, Quaternion.identity);
        }
        else
        {
            Debug.LogError("can't make bonefire");
        }
    }

}
