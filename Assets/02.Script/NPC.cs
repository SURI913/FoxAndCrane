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
        if(isMoveout)
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

        } 


        if(collision.gameObject.CompareTag("branch"))
        {
            Debug.Log("�������� Ȯ��. ��ں� �帲");
            GiveFire();
            Destroy(collision.gameObject);// branch Destroy
        }
    }

    private void MoveOutOfWay()
    {

        //ismoveout ���� �Լ��� ������Ʈ�� �������� ; �׳� ����ģ�� ;
       // target.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // ��ǥ ��ġ���� ������ �̵� (�ӵ� ����)
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ϸ� �̵� ����
        if (transform.position.z == target.position.z)
        {
            Debug.Log("��ǥ ��ġ ����");
           // rb.velocity = Vector3.zero;
            isMoveout = false;

        }

        /*Vector3 currentPosition = transform.position;
        currentPosition.z += 1.0f; // 1.0f��ŭ Z�� �̵�
        transform.position = currentPosition;*/
        // transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
        /*
                float targetPositionZ = transform.position.z + 2f;

                // Z�� �������� �ε巴�� �̵�
                float smoothZ = Mathf.Lerp(transform.position.z, targetPositionZ, Time.deltaTime * moveSpeed);

                transform.position = new Vector3(transform.position.x, transform.position.y, smoothZ);
        */
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
