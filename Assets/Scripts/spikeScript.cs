using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeScript : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cuando entre en contacto con un objeto y tenga el tag John
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("has muerto");
            playerMove john = collision.GetComponent<playerMove>();
            if (john != null)
            {
                john.dead();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
