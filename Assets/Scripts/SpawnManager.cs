using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int randomX;
    public int randomZ;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DoSomething", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {


    }


    // Cada 3 segundos aparezca un cubo
    void DoSomething()
    {
        randomX = Random.Range(-20, 21);
        randomZ = Random.Range(-20, 21);

        //Debug.Log("Ejecutando acción cada 3 segundos");
        Instantiate(enemyPrefab, new Vector3(randomX, enemyPrefab.transform.position.y, randomZ), transform.rotation);

    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        CancelInvoke("DoSomething");
    }
}

