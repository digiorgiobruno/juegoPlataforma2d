using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titanScript : MonoBehaviour
{

    public AudioSource hitSound;
    public GameObject John;
    public float scale = 2.346508f;
    public AudioSource titanSound;
    private float lastShoot;
    public float bulletTime;
    public bool pjExplosion = false;
    public bool firstTime = true;
    public GameObject bulletPrefact;
    public AudioSource SoundExplosion;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    public Image lifebar;
    public Canvas titanCanvas;
    public float health = 30;
    public float healthMax = 30;
    public bool titanDead=false;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); //guardo el Rigidbody del jugador
        Animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (John == null) return;
        Vector3 direction = John.transform.position - transform.position;// la resta entre vectores obtiene el vector direccion entre los dos puntos
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(scale, scale, scale);

        }
        else
        {
            transform.localScale = new Vector3(-scale, scale, scale);
        }

        float distance = Mathf.Abs(transform.position.x - John.transform.position.x);
        //Debug.Log("distancia: " + distance + " John :" + John.transform.position.x + "transform titan : " + transform.position.x);

        if (distance < 2)
        {
            titanSound.Play();
            firstTime = false;
        };

        if (distance < 2.0f && Time.time > lastShoot + bulletTime && !pjExplosion)
        {
            //Debug.Log("estas a 2.0F");
            shoot();
            lastShoot = Time.time;
        };

        if (distance < 3.0f)
        {
            //Debug.Log("estas a 2.0F");
            titanCanvas.gameObject.SetActive(true);
        }
        else
        {
            titanCanvas.gameObject.SetActive(false);

        };
    }

    private void shoot()
    {
        Vector3 direction = new Vector3(-1, 0.9f, 0);
        Vector3 v3 = transform.position + direction;
        direction = Vector2.left;//localScale ==1 entonces voy a la derecha, de lo contrario voy a la izquierda
        Debug.Log("vector  Titan " + v3);
        GameObject bullet = Instantiate(bulletPrefact, v3, Quaternion.identity);// instantiate instancia prefacts en alguna parte del mapa, quaternion.identity significa rotacion cero
        bullet.GetComponent<titanBulletScript>().setDiretion(direction);
    }

    public void hit()
    {
        health = health - 1;
        lifebar.fillAmount = health / healthMax;
        hitSound.Play();
        if (health == 0)
        {
            Rigidbody2D.simulated = false;
            pjExplosion = true;
            SoundExplosion.Play();
            Animator.SetBool("explosion", true);
            titanDead=true;
        }
    }

    public void destroyGrunt()
    {
        //se activa cuando con un evento dentro de la animacion
        Destroy(gameObject);
    }
}
