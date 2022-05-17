using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipoulpe : MonoBehaviour
{
    private float speed = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Q)){
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}
