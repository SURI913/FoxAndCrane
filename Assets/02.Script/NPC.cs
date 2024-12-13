using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private GameObject boneFire;

   
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Berry"))
        {
            Debug.Log("¿­¸Å ¿Õ ºñÄÑÁÜ");
            MoveOutOfWay();
        } 
        else if (collision.gameObject.CompareTag("branch"))
        {
            Debug.Log("³ª¹µ°¡Áö È®ÀÎ. ¸ð´ÚºÒ µå¸²");
            GiveFire();
            Destroy(collision.gameObject);// branch Destroy
        }
    }

    private void MoveOutOfWay()
    {  
        transform.position += new Vector3(2f, 0, 0);
        //NPC behaviour ¹Ù²ãÁÖ±â
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
