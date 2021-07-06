using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class GameManager : MonoBehaviour
{
    public AudioSource startSound, quitSound;

    //public bool init = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Return))
        {
            startSound.Play();
            SceneManager.LoadScene("Main");
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            quitSound.Play();
            Debug.Log("Hemos salido del juego");
            Application.Quit();
        }
    }
    public void botonStart()
    {
        SceneManager.LoadScene("Main");
    }
    public void botonScape()
    {
        Debug.Log("Hemos salido del juego");
        Application.Quit();
    }
}
