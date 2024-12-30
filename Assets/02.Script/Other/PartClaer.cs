using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PartClaer : MonoBehaviour
{
    public void OnClearPart()
    {
        this.gameObject.SetActive(false);
    }

    
}
