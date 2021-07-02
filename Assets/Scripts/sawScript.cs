using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawScript : MonoBehaviour
{
    public bool tramp = true;
    public GameObject prefactSawt;
    public AudioSource saw;
    private Rigidbody2D rb;
    private Vector2 posInit;
    private void Start()
    {
    posInit=transform.position;

    }
    private void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (tramp)
        {
            //usamos raycast para saber si ha tocado el suelo
            Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);
            if (Physics2D.Raycast(transform.position, Vector2.down, 0.2f))
            {

                transform.position = posInit;
                rb.velocity = new Vector2(0.0f, 0.0f);
                //Debug.Log("Saw toco el suelo");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMove john = collision.GetComponent<playerMove>();

        if (john != null)
        {
            saw.Play();
            john.hit();
            //Destroy(gameObject,0.15f);
        }

    }
}
