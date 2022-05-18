using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManchouManager : MonoBehaviour
{


    public int currentHealth;
    public int maxHealth=1;

    public GameObject SpawnPoint;

    Transform tf;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        tf = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Damage(int damage) //(basile) j'ai pass� en public, c'est cringe mais il est 4h du mat, faudra voir pour qu'un objet ext�rieur puisse faire des d�gats aux joueurs
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        currentHealth = maxHealth;
        tf.position = SpawnPoint.transform.position;
    }
}
