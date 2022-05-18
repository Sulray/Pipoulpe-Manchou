using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManchouHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (collision.TryGetComponent(out Crevette crevetteScript))
            {
                Debug.Log("Hit a Crevette");
                crevetteScript.Damage(1);
            }
        }
    }
}
