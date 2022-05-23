using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManchouManager : MonoBehaviour
{

    private int currentHealth;
    public float currentAir;//à passer en privée
    [SerializeField] private int maxHealth=1;
    [SerializeField] private float maxAir = 10f;
    [SerializeField] private float waterBreathingVelocity;
    [SerializeField] private float airBreathingVelocity;
    private float breathingVelocity;
    [SerializeField] private GameObject SpawnPoint;
    Transform tf;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentAir = maxAir;
        breathingVelocity = airBreathingVelocity;
        tf = this.GetComponent<Transform>();
    }

    // Update is called once per frame

    void Update()
    {
        currentAir = Mathf.Min(maxAir, currentAir + (breathingVelocity*Time.deltaTime));
        if (currentAir <= 0)
        {
            //Damage(1);
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            breathingVelocity = waterBreathingVelocity;
        }
        else if (other.gameObject.tag == "AirBubble")
        {
            currentAir += 3f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            breathingVelocity = airBreathingVelocity;
        }
    }
}
