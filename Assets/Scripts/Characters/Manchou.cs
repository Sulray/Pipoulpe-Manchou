using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manchou : MonoBehaviour
{
    private float speed = 20f;
    public float gravity = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed * gravity);
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) // ajouter changement du raycast (le perso glisse)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed * 1.5f);
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)) // ajouter changement du raycast (le perso glisse)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * 1.5f);
        }
    }
}
