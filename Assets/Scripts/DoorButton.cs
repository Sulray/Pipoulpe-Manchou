using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Sprite open;

    private SpriteRenderer sprite;
    private BoxCollider2D hitbox;

    private void Start()
    {
        sprite = door.GetComponent<SpriteRenderer>();
        hitbox = door.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.gameObject.SetActive(true);
        sprite.sprite = open;
        sprite.color = Color.white;
        hitbox.enabled = true;
    }
}
