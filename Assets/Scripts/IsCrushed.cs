using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IsCrushed : MonoBehaviour
{
    public bool isCrush = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("PlayerBullet"))
        {
            isCrush = true;
        }
    }
}
