using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrevetteMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] GameObject target1; //1er objet vers lequel se dirige la crevette 
    [SerializeField] GameObject target2; //2e objet vers lequel se dirige la crevette quand elle a atteint 
    private Vector2 target1Position;
    private Vector2 target2Position;
    private Vector2 targetPos;

    void Start()
    {
        target1Position = target1.transform.position;
        target2Position = target2.transform.position;
        targetPos = target1Position;
        speed = 4f;
    }

    void Update()
    {
        if (targetPos.x == transform.position.x && targetPos == target1Position)
        {
            targetPos = target2Position;
        }
        if (targetPos.x == transform.position.x && targetPos == target2Position)
        {
            targetPos = target1Position;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
