using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class GManager : MonoBehaviour
{
    public AudioSource startSound, quitSound, gameOverSound;
    public AudioSource youWinSound;
    public Renderer background;
    public GameObject John;
    public GameObject titan;
    public Canvas youWin;
    public Canvas GameOver;
    private bool JohnDead;
    public bool titanDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (JohnDead)
        {

            GameOver.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Return))
            {
                botonStart();
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                botonScape();
            }
        }
        else
        {
            JohnDead = John.gameObject.GetComponent<playerMove>().JohnDead;
            if (JohnDead)
            {
                Camera.main.GetComponent<AudioSource>().Stop();
                gameOverSound.Play();
            }
        }


        if (titanDead)
        {

            youWin.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Return))
            {
                botonStart();
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                botonScape();
            }
        }
        else
        {
            titanDead = titan.gameObject.GetComponent<titanScript>().titanDead;
            if (titanDead)
            {
                Camera.main.GetComponent<AudioSource>().Stop();
                youWinSound.Play();

            }
        }


    }
    public void botonStart()
    {
        startSound.Play();
        SceneManager.LoadScene("Main");
    }
    public void botonScape()
    {
        quitSound.Play();
        Debug.Log("Hemos salido del juego");
        SceneManager.LoadScene("MainMenu");
    }
}
