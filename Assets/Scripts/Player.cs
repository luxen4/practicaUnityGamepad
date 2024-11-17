using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float velGiro;

    public float minX;
    public float maxX;

    public float minZ;
    public float maxZ;


    public bool parteSuperior;
    public bool parteDerecha;
    public bool parteIzquierda;
    public bool parteInferior;




    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        velGiro = 50f;

        minX = -20.0f;
        maxX = 20.0f;

        minZ = -20.0f;
        maxZ = 20.0f;

        parteSuperior = false;
        parteDerecha = false;
        parteIzquierda = false;
        parteInferior = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Cuando pulse las flechas obedezca hasta un límite
        // Si sale de los límites, no avanza.

        if (Input.GetKey(KeyCode.UpArrow))
        {
            ComprobarAvance();

            ComprobarDelante();

        }



        if (Input.GetKey(KeyCode.DownArrow))
        {

            ComprobarRetroceso();
            ComprobarDelante();

        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotar el objeto alrededor del eje Y
            transform.Rotate(Vector3.down * Time.deltaTime * velGiro);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Rotar el objeto alrededor del eje Y
            transform.Rotate(Vector3.up * Time.deltaTime * velGiro);
        }
    }

    

    // Método que controla el límite del area del juego al avanzar
    void ComprobarAvance() {

        if (transform.position.x >= maxX)
        {
            Debug.Log("Parte Superior");
            parteSuperior = true;
        }
        else
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime);
        }


        if (transform.position.x <= minX)
        {
            Debug.Log("Parte Inferior");
            parteInferior = true;
        }
        else
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime);
        }




        if (transform.position.z >= maxZ)
        {
            Debug.Log("Parte Izquierda");
            parteIzquierda = true;

        }
        else
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime);
        }

        if (transform.position.z <= minZ)
        {
            Debug.Log("Parte Derecha");
            parteDerecha = true;
        }
        else
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime);
        }
    }



    void ComprobarRetroceso()
    {

        if (transform.position.x >= maxX)
        {
            Debug.Log("Parte Superior");
            parteSuperior = true;
        }
        else
        {
            transform.Translate(speed * Vector3.back * Time.deltaTime);

        }
        if (transform.position.x <= minX)
        {
            Debug.Log("Parte Inferior");
            parteInferior = true;
        }
        else
        {
            transform.Translate(speed * Vector3.back * Time.deltaTime);

        }




        if (transform.position.z >= maxZ)
        {
            Debug.Log("Parte Izquierda");
            parteIzquierda = true;

        }
        else
        {
            transform.Translate(speed * Vector3.back * Time.deltaTime);
        }

        if (transform.position.z <= minZ)
        {
            Debug.Log("Parte Derecha");
            parteDerecha = true;
        }
        else
        {
            transform.Translate(speed * Vector3.back * Time.deltaTime);
        }
    }

    void ComprobarDelante() {

        if (parteSuperior == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            transform.position.z);
        }

        if (parteInferior == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            transform.position.z);
        }


        if (parteDerecha == true)
        {
            transform.position = new Vector3(transform.position.x,
            transform.position.y,
            Mathf.Clamp(transform.position.z, minZ, maxZ));
        }

        if (parteIzquierda == true)
        {
            transform.position = new Vector3(transform.position.x,
            transform.position.y,
            Mathf.Clamp(transform.position.z, minZ, maxZ));
        }


        parteSuperior = false;
        parteInferior = false;
        parteDerecha = false;
        parteIzquierda = false;
    }




}


/*
///////////
if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) {
    transform.Rotate(Vector3.up) * rotSpeed * Time.deltaTime;
}

transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
    transform.position.y,
    Mathf.Clamp(transform.position.z, minZ, maxZ));
///////////*/