using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Pour l'instant le système d'enum marche pas vraiment parcqu'il faut attacher le script au canevas dont les boutons sont fils, ce qui veut dire que tous le boutons envoient vers la même scène.
//je (Basile) vais essayer de fix ça

public class UIButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioSource audio;
    public Scenes nextScene; //On peut essayer de sérialiser, le but c'est de choisir vers quelle scène envoie le bouton
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

    public void Pause()
    {
        Time.timeScale = 1f - Time.timeScale;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        audio.volume = 0.16f/audio.volume;
    }
}
