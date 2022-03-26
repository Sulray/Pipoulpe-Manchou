using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Pour l'instant le syst�me d'enum marche pas vraiment parcqu'il faut attacher le script au canevas dont les boutons sont fils, ce qui veut dire que tous le boutons envoient vers la m�me sc�ne.
//je (Basile) vais essayer de fix �a

public class UIButtonManager : MonoBehaviour
{
    public Scenes nextScene; //On peut essayer de s�rialiser, le but c'est de choisir vers quelle sc�ne envoie le bouton
    /*public void Next(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }*/
    public void Next(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
