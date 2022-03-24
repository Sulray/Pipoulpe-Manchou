using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 8f;
    [SerializeField] GameObject plouf;
    private Vector2 targetPosition;
    
    void Start()
    {
        targetPosition = plouf.transform.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
