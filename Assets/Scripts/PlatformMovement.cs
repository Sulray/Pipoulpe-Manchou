using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] GameObject plouf; //objet vers lequel la plateforme se dirigera à drag and drop dans l'inspector
    private Vector2 targetPosition;
    
    void Start()
    {
        targetPosition = plouf.transform.position;
        speed = 0f;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        print(speed);
    }

    public void launchPlatform()
    {
        speed = 4f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Pipoulpe")|| (collision.gameObject.tag == "Manchou"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Pipoulpe") || (collision.gameObject.tag == "Manchou"))
        {
            collision.transform.SetParent(null);
        }
    }
}
