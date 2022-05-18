using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crevette : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] GameObject target1; //1er objet vers lequel se dirige la crevette 
    [SerializeField] GameObject target2; //2e objet vers lequel se dirige la crevette quand elle a atteint la 1ère
    private Vector2 target1Position;
    private Vector2 target2Position;
    private Vector2 targetPos; //cette valeur est amenée à alterner entre target1 et target2
    private Rigidbody2D crevetteRB;
    private PolygonCollider2D crevetteCollider;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        target1Position = target1.transform.position;
        target2Position = target2.transform.position;
        targetPos = target1Position;
        speed = 3f;
        crevetteRB = GetComponent<Rigidbody2D>();
        crevetteCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (targetPos.x == transform.position.x && targetPos == target1Position) //quand la crevette atteint la target à gauche elle switch vers la droite
        {
            targetPos = target2Position;
        }
        if (targetPos.x == transform.position.x && targetPos == target2Position) //quand la crevette atteint la target à droite elle switch vers la gauche
        {
            targetPos = target1Position;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    
    private void dies (Collider2D other)
    {

    }
}
