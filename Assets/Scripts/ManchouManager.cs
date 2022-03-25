using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManchouManager : MonoBehaviour
{


    public int currentHealth;
    public int maxHealth;

    public GameObject SpawnPoint;

    Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        tf = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void Damage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        currentHealth = maxHealth;
        tf.position = SpawnPoint.transform.position;
    }
}
