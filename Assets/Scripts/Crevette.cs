using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crevette : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] GameObject target1; //1er objet vers lequel se dirige la crevette 
    [SerializeField] GameObject target2; //2e objet vers lequel se dirige la crevette quand elle a atteint la 1�re
    private Vector2 target1Position;
    private Vector2 target2Position;
    private Vector2 targetPos; //cette valeur est amen�e � alterner entre target1 et target2
    private int currentHealth;
    private bool isDead;

    private Vector3 scale;
    private float initXscale;

    void Start()
    {
        target1Position = target1.transform.position;
        target2Position = target2.transform.position;
        targetPos = target1Position;
        speed = 3f;
        currentHealth = 1;

        initXscale = transform.localScale.x;
    }

    void Update()
    {
        scale = transform.localScale;
        if (targetPos.x == transform.position.x && targetPos == target1Position) //quand la crevette atteint la target � gauche elle switch vers la droite
        {
            targetPos = target2Position;
            scale.x = initXscale;
        }
        if (targetPos.x == transform.position.x && targetPos == target2Position) //quand la crevette atteint la target � droite elle switch vers la gauche
        {
            targetPos = target1Position;
            scale.x = -initXscale;
        }
        transform.localScale = scale;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    
    private void Death()
    {
        isDead = true;
        Destroy(this.gameObject);
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
}
    
    
