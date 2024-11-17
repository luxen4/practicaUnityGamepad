using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruyePorTiempo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Entro a autodestruir");
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
