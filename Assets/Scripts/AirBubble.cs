using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBubble : MonoBehaviour
{
    private SpriteRenderer sprite;
    private CircleCollider2D hitbox;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        hitbox = this.gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void wait (float time)
    {
        timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
        }
    }
    IEnumerator Respawn()
    {
        sprite.enabled = false;
        hitbox.enabled = false;
        yield return new WaitForSeconds(3f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.5f);
        hitbox.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Manchou")
        StartCoroutine("Respawn");
    }

}
