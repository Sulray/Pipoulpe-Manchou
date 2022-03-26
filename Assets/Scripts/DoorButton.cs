using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        door.gameObject.SetActive(true);
    }
}
