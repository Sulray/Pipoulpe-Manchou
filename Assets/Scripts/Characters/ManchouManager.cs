using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManchouManager : MonoBehaviour
{

    private int currentHealth;
    public int currentAir;
    [SerializeField]private int maxHealth=1;
    [SerializeField] private int maxAir = 10;
    [SerializeField] private ManchouMovement manchouMovement;
    [SerializeField] private GameObject SpawnPoint;
    Transform tf;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentAir = maxAir;
        tf = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAir >= 10)
        {
            StopCoroutine("Breath");
        }
    }

    private IEnumerator Drown()
    {
        while (manchouMovement.getIsInWater())
        {
            currentAir -= 1;
            Debug.Log("drowning" + currentAir);
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator Breath()
    {
        while (!manchouMovement.getIsInWater()&& currentAir <10)
        {
            currentAir += 1;
            Debug.Log("breathing" + currentAir);
            yield return new WaitForSeconds(1f);
        }
    }

    public void Damage(int damage) //(basile) j'ai passé en public, c'est cringe mais il est 4h du mat, faudra voir pour qu'un objet extérieur puisse faire des dégats aux joueurs
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

    //(basile) c'est censé manager la respiration, mais jsp pourquoi il recconait pas quand il rentre dans l'eau, et il refuse d'utiliser
    //onTriggerEnter2D() pour manchouManager, alors que ça marche pour manchouMovement.
    //c'est cringe, on va ptet devoir passer la respiration sur manchouMovement
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter" + collision.gameObject);
        if(collision.gameObject.tag == "Water")
        {
            StopCoroutine("Breath");
            StartCoroutine(Drown());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("exit" + collision.gameObject.tag);
        if (collision.gameObject.tag == "Water")
        {
            StopCoroutine("Drown");
            if (currentAir < 10)
            {
                StartCoroutine(Breath());
            }
        }
    }*/
}
