using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Pour l'instant le système d'enum marche pas vraiment parcqu'il faut attacher le script au canevas dont les boutons sont fils, ce qui veut dire que tous le boutons envoient vers la même scène.
//je (Basile) vais essayer de fix ça

public class UIButtonManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioSource audio;

    [SerializeField] private Sprite mute;
    [SerializeField] private Sprite unmute;

    [SerializeField] private GameObject muteButton;

    private Image muteImage;

    private float maxVolume = 0.8f;
    private float previousVolume;
    
    public Scenes nextScene; //On peut essayer de sérialiser, le but c'est de choisir vers quelle scène envoie le bouton
    /*public void Next(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }*/

    private void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        this.GetComponent<Canvas>().sortingOrder = 0;

        previousVolume = maxVolume / 2;
        audio.volume = maxVolume;
        muteImage = muteButton.GetComponent<Image>();
        slider.value = 1;
    }

    private void Update()
    {
        audio.volume = slider.normalizedValue * maxVolume;
        if (audio.volume <= 0)
        {

            muteImage.sprite = mute;
        }
        else
        {
            muteImage.sprite = unmute;
        }
    }

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
        this.GetComponent<Canvas>().sortingOrder = 4 - this.GetComponent<Canvas>().sortingOrder; //quickfix
        
    }

    public void Mute()
    {
        if (audio.volume <= 0)
        {

            slider.value = previousVolume/maxVolume;
            
        }
        else
        {
            previousVolume = maxVolume*slider.value;
            slider.value = 0f;
        }
        
    }
}
