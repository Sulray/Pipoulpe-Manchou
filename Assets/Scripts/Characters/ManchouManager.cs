using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManchouManager : MonoBehaviour
{

    private int currentHealth;
    public float currentAir;//� passer en priv�e
    
    [SerializeField] private int maxHealth=1;
    [SerializeField] private float maxAir = 10f;
    
    [SerializeField] private float waterBreathingVelocity;
    [SerializeField] private float airBreathingVelocity;
    private float breathingVelocity;

    [SerializeField] private AirBar airBar;
    
    [SerializeField] private GameObject SpawnPoint;
    
    Transform tf;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        currentAir = maxAir;
        breathingVelocity = airBreathingVelocity;

        airBar.setMaxAir(maxAir);

        airBar.enabled = false;

        tf = this.GetComponent<Transform>();
        
    }

    // Update is called once per frame

    void Update()
    {
        currentAir = Mathf.Min(maxAir, currentAir + (breathingVelocity*Time.deltaTime));
        airBar.SetAir(currentAir);
        CheckAirBar();
        if (currentAir <= 0)
        {
            Damage(1);
        }
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
        currentHealth = maxHealth;
        tf.position = SpawnPoint.transform.position;
    }

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
    

    private void CheckAirBar()
    {
        if (!airBar.gameObject.activeSelf && currentAir < maxAir)
        {
            Debug.Log(1);
            airBar.gameObject.SetActive(true);
        }

        if (airBar.gameObject.activeSelf && currentAir >= maxAir)
        {
            Debug.Log(2);
            airBar.gameObject.SetActive(false);
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
