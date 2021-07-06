using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    //Variables globales

    public Image lifebar;
    public AudioSource johnDeadClip;
    public AudioSource hitSound;
    public float bulletTime = 0.1f;
    public GameObject bulletPrefact;
    public GameObject bulletPrefactL2;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    public float JumpForce;
    public float Speed;
    private float Horizontal;
    private bool Grounded;// estamos en el suelo?
    private float lastShoot;//el tiempo en el que se hizo el ultimo disparo
    public float healthMax = 15;
    public float health = 15;
    public bool ammoSave = false;
    public bool JohnDead=false;
    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); //guardo el Rigidbody del jugador
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(JohnDead){return;}
        if(GM.gameObject.GetComponent<GManager>().titanDead){return;}
        // Movimiento
        //"Horizontal" será 0 si no pulsamos nada, 1 si pulsamos la "a" y -1 si pulsamos la "d"
        Horizontal = Input.GetAxisRaw("Horizontal");// si pulsamos "a" devolverá -1, y si pulsamos "d",1. Para cambiar las teclas ir a project setting/input manager
        if (Horizontal < 0.0f) { transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); }//rotamos el personaje
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);//rotamos al personaje
        }
        Animator.SetBool("running", Horizontal != 0.0f);
        // Detectar Suelo
        //Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red); 
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
            //si el raycast choca con algo un maximo de distancia de 0.1f devolverá true
            Grounded = true;
        }
        else { Grounded = false; }
        // Salto

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.K) && Time.time > lastShoot + bulletTime)
        {
            shoot();
            lastShoot = Time.time;
        }

    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        // cuando pulsamos "a" horizontal valdrá -1 por lo cual el personaje irá a la izquierda, 
        //y si pulsamos "d" horizontal valdrá 1, y el personaje se desplazará a la derecha
        //recordar poner Freeze Positio z para que el personaje no ruede
    }
    private void shoot()
    {

        Vector3 direction;
        if (transform.localScale.x == 1.0f) { direction = Vector2.right; } else { direction = Vector2.left; }//localScale ==1 entonces voy a la derecha, de lo contrario voy a la izquierda
        if (ammoSave)
        {
            GameObject bullet = Instantiate(bulletPrefactL2, transform.position + direction * 0.1f, Quaternion.identity);// instantiate instancia prefacts en alguna parte del mapa, quaternion.identity significa rotacion cero
            bullet.GetComponent<bulletScript>().setDiretion(direction);
            //Debug.Log("Ammo SAVE");
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefact, transform.position + direction * 0.1f, Quaternion.identity);// instantiate instancia prefacts en alguna parte del mapa, quaternion.identity significa rotacion cero
            bullet.GetComponent<bulletScript>().setDiretion(direction);
        }



    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    public void hit()
    {
        if(JohnDead){return;}
        health = health - 1;
        hitSound.Play();
        lifebar.fillAmount = health / healthMax;//va a ser un numero entre 0 y 1 representando el porcentaje del total de vida que nos queda.
        if (health == 0)
        {
            dead();
            //Destroy(gameObject);
        }
    }

    public void dead()
    {
        johnDeadClip.Play();
        Animator.SetBool("dead", true);
        JohnDead = true;
        //Destroy(gameObject);
    }
    public void ammo()
    {
        bulletTime = 0.1f;
        ammoSave = true;

    }
    public void medicalKit()
    {
        health = healthMax;
        lifebar.fillAmount = health / healthMax;
    }

}
