using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoScript : MonoBehaviour
{
    public AudioSource ammo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMove john = collision.GetComponent<playerMove>();
    
        if (john != null)
        {
            ammo.Play();
            john.ammo();
            Destroy(gameObject,0.15f);
        }
     
    }
}
