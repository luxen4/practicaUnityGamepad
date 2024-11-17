using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choque : MonoBehaviour
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
        Debug.Log("Player contra " + other.tag);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("El jugador ha entrado en la zona Enemy.");
        }
    }
}
