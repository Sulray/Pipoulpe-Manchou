using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Sprite open;
    private SpriteRenderer sprite;
    private BoxCollider2D hitbox;

    private void Start()
    {
        sprite = door.gameObject.GetComponent<SpriteRenderer>();
        hitbox = door.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.gameObject.SetActive(true);
        sprite.sprite = open;
        sprite.color = Color.white;
        hitbox.enabled = true;
    }
}
