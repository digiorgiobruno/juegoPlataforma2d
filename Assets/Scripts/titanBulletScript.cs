using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titanBulletScript : MonoBehaviour
{

    //public Sprite BulletLvl2;
    public AudioClip Sound;
    public float speed;
    public Vector2 direction;
    public AudioSource hitSound;
    private Rigidbody2D Rigidbody2D;
    
   
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        //GetComponent<SpriteRenderer>().sprite= BulletLvl2;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = direction * speed;
    }
    public void setDiretion(Vector2 d)
    {
        direction = d;
    }
    public void destroyBullet()
    {
        Destroy(gameObject);
    }
    public void changeSprite()
    {
        //GetComponent<SpriteRenderer>().sprite= BulletLvl2;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMove john = collision.GetComponent<playerMove>();
        gruntScript grunt = collision.GetComponent<gruntScript>();
        if (john != null)
        {
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(johnHit);
            john.hit();
        }
        /*if (grunt != null)
        {
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(grunHit);
            grunt.hit();
        }*/
        //destroyBullet();
    }


}
