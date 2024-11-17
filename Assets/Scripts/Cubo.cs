using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Cubo : MonoBehaviour
{
    

    ControlesMando controles;

    private bool rotandoIzquierda = false;
    private bool rotandoDerecha = false;

    private bool irAdelante = false;
    private bool irAtras = false;

    public float speed;


    Vector2 rotacion;


    private void Awake()
    {
        controles = new ControlesMando();

        // Asignación de las acciones de aumento y disminución
        controles.Juego.Aumentar.performed += ctx => Aumentar();
        controles.Juego.Disminuir.performed += ctx => Disminuir();


        // Asignación de las acciones de rotación
        controles.Juego.RotarIzquierda.performed += ctx => ComenzarRotacionIzquierda();
        controles.Juego.RotarDerecha.performed += ctx => ComenzarRotacionDerecha();

        // Detener la rotación cuando el botón se suelta
        controles.Juego.RotarIzquierda.canceled += ctx => DetenerRotacionIzquierda();
        controles.Juego.RotarDerecha.canceled += ctx => DetenerRotacionDerecha();


        controles.Juego.Adelante.performed += ctx => ComenzarAdelante();
        controles.Juego.Atras.performed += ctx => ComenzarAtras();


        controles.Juego.Adelante.canceled += ctx => DetenerAdelante();
        controles.Juego.Atras.canceled += ctx => DetenerAtras();






    }
    
    private void Aumentar()
    {
        transform.localScale += Vector3.one / 10;
    }


    private void Disminuir() {
        transform.localScale -= Vector3.one / 10;
    }





    private void ComenzarAdelante() {
        //transform.Translate(speed * Vector3.forward * Time.deltaTime);
        irAdelante = true; 
        irAtras = false;
    }

    private void ComenzarAtras()
    {
        //transform.Translate(speed * Vector3.back * Time.deltaTime);
        irAdelante = false;
        irAtras = true;
    }




    private void Adelante()
    {
        transform.Translate(speed * Vector3.forward * Time.deltaTime);
    }

    private void Atras()
    {
        transform.Translate(speed * Vector3.back * Time.deltaTime);
    }


    private void DetenerAdelante()
    {
        irAdelante = false;  // Detiene la 
    }

    private void DetenerAtras()
    {
        irAtras = false;  // 
    }




    private void RotarIzquierda()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * 50);
    }

    private void RotarDerecha() {
        transform.Rotate(Vector3.up * Time.deltaTime * 50);
        
    }


    private void ComenzarRotacionIzquierda()
    {
        rotandoIzquierda = true;  // Activa la rotación hacia la izquierda
        rotandoDerecha = false;   // Desactiva la rotación hacia la derecha
    }

    private void ComenzarRotacionDerecha()
    {
        rotandoDerecha = true;  
        rotandoIzquierda = false;  
    }


// Detiene la rotación hacia la izquierda
    private void DetenerRotacionIzquierda()
    {
        rotandoIzquierda = false;  
    }

// Detiene la rotación hacia la derecha
    private void DetenerRotacionDerecha()
    {
        rotandoDerecha = false;  
    }







    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
       float h = Input.GetAxisRaw("Horizontal");
       float v = Input.GetAxisRaw("Vertical");

       transform.Translate(h * Time.deltaTime, v * Time.deltaTime, 0);



        // Si estamos rotando, realizamos la rotación.
        if (rotandoDerecha)
        {
            RotarDerecha();
        }

        if (rotandoIzquierda)
        {
            RotarIzquierda();
        }

        if (irAdelante)
        {
            Adelante();
        }

        if (irAtras) { 
            Atras();
        }

    }


    private void OnEnable()
    {
        controles.Juego.Enable();
    }

    private void OnDisable()
    {
        controles.Juego.Disable();
    }

}


/* Mirar este video de cómo se hace https://www.youtube.com/watch?v=DTsReLkht3Q 
 
De Package Manager -> Instalar Input System
Se conecta el joyStick y lo pilla la consola
Window -> Análisis -> Input Debuger. Sale nuestro Game-Pad
Create -> Input Actions. Picamos y aparece la interfaz para agregar acciones para los botones del mando.
Seleccionar el check de Generate el C# Class y apply. Se genera el .cs para programar los botones.
Se abre el .cs y ya a programar movimientos.
El script (.cs) se cuelga del objeto.

 */