using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //Variables globales
    public float bulletTime = 0.1f;
    public GameObject bulletPrefact;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    public float JumpForce;
    public float Speed;
    private float Horizontal;
    private bool Grounded;// estamos en el suelo?
    private float lastShoot;//el tiempo en el que se hizo el ultimo disparo
    private int health=5;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); //guardo el Rigidbody del jugador
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal");// si pulsamos a devolverá -1, y si pulsamos d,1 
        if (Horizontal < 0.0f) { transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        Animator.SetBool("running", Horizontal != 0.0f);
        // Detectar Suelo
        //Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red); 
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
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
    }
    private void shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) { direction = Vector2.right; } else { direction = Vector2.left; }//localScale ==1 entonces voy a la derecha, de lo contrario voy a la izquierda
        GameObject bullet = Instantiate(bulletPrefact, transform.position+ direction* 0.1f, Quaternion.identity);// instantiate instancia prefacts en alguna parte del mapa, quaternion.identity significa rotacion cero
        bullet.GetComponent<bulletScript>().setDiretion(direction);
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    public void hit(){
        health=health-1;
        if(health==0){
            Destroy(gameObject);
        }
    }
}
