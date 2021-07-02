using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGruntScript : MonoBehaviour
{
    public AudioClip johnHit;
    public AudioClip grunHit;
    public AudioClip Sound;
    public float speed;
    public Vector2 direction;
    private Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMove john = collision.GetComponent<playerMove>();
        if (john != null)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(johnHit);
            john.hit();
        }
        destroyBullet();
    }
}
