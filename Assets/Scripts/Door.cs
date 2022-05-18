using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool pipoulpeOn = false;
    private bool manchouOn = false;
    public Scenes nextScene; //On peut essayer de sérialiser, le but c'est de choisir vers quelle scène envoie la porte

    //lorsqu'un personnage entre en contact avec la porte,on l'indique, si les 2 touchent la porte on passe à la suite!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pipoulpeOn == true && manchouOn == true)
        {
            SceneManager.LoadScene(nextScene.ToString());
            Debug.Log("2");
        }
        else
        {
            if (collision.gameObject.tag == "Manchou")
            {
                manchouOn = true;
            }
            else if (collision.gameObject.tag == "Pipoulpe")
            {
                pipoulpeOn = true;
            }
        }
    }
    //lorsqu'un personnage n'est plus en contact avec la porte, on l'indique
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Manchou")
        {
            manchouOn = false;
        }
        else if (collision.gameObject.tag == "Pipoulpe")
        {
            pipoulpeOn = false;
        }
    }
}
