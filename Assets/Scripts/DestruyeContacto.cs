using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruyeContacto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Coche contra " + other.tag);

        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador choca.");
            Destroy(gameObject);
        }
    }
}
