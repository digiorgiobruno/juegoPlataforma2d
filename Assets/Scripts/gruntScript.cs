using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gruntScript : MonoBehaviour
{
    public GameObject bulletPrefact;
    private float lastShoot;
    public float bulletTime;
    private Rigidbody2D Rigidbody2D;
    public GameObject John;
    private int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); //guardo el Rigidbody del jugador
    }

    // Update is called once per frame
    private void Update()
    {   if(John==null)return;
        Vector3 direction = John.transform.position - transform.position;// la resta entre vectores obtiene el vector direccion entre los dos puntos
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else { transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); }
        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);
        if (distance < 1.0f && Time.time > lastShoot + bulletTime)
        {
            shoot();
            lastShoot = Time.time;
        };
    }
    private void shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) { direction = Vector2.right; } else { direction = Vector2.left; }//localScale ==1 entonces voy a la derecha, de lo contrario voy a la izquierda
        GameObject bullet = Instantiate(bulletPrefact, transform.position + direction * 0.1f, Quaternion.identity);// instantiate instancia prefacts en alguna parte del mapa, quaternion.identity significa rotacion cero
        bullet.GetComponent<bulletScript>().setDiretion(direction);

    }

    public void hit()
    {
        health = health - 1;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
