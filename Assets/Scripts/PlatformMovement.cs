using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] GameObject target1; //1er objet vers lequel se dirige la plateforme 
    [SerializeField] GameObject target2; //2e objet vers lequel se dirige la plateforme quand elle a atteint la 1ère
    [SerializeField] bool isHorizontal; //détermine si le mouvement sera selon x ou selon y
    private Vector2 target1Position;
    private Vector2 target2Position;
    private Vector2 targetPos; //cette valeur est amenée à alterner entre target1 et target2

    void Start()
    {
        target1Position = target1.transform.position;
        target2Position = target2.transform.position;
        targetPos = target1Position;
        speed = 0f;
    }

    void Update()
    {
        if (isHorizontal) //si true alors le mouvement est selon x
        {
            if (targetPos.x == transform.position.x && targetPos == target1Position) //quand la plateforme atteint la target à gauche elle switch vers la droite
            {
                targetPos = target2Position;
            }
            if (targetPos.x == transform.position.x && targetPos == target2Position) //quand la plateforme atteint la target à droite elle switch vers la gauche
            {
                targetPos = target1Position;
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        if (!isHorizontal) //si false le mouvement est selon y
        {
            if (targetPos.y == transform.position.y && targetPos == target1Position) //quand la plateforme atteint la target à gauche elle switch vers la droite
            {
                targetPos = target2Position;
            }
            if (targetPos.y == transform.position.y && targetPos == target2Position) //quand la plateforme atteint la target à droite elle switch vers la gauche
            {
                targetPos = target1Position;
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
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
