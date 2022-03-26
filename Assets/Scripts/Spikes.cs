using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) //faut trouver un moyen de récuper le manager indépendament du joueur
    {
        if (collision.gameObject.tag == "Manchou")
        {
            collision.gameObject.GetComponent<ManchouManager>().Damage(1);
        }
        if (collision.gameObject.tag == "Pipoulpe")
        {
            collision.gameObject.GetComponent<PipoulpeManager>().Damage(1);
        }
    }
}
