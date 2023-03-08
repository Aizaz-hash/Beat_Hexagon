using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public float spawnRate = 1f;
    public GameObject hexagonPrefab;
    private float nextTimeToSpawn = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {

            //new Hexagone
            var myNewObject = Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            //assing radnom color to hexagon
           // myNewObject.GetComponent<Renderer>().material.color = Color.red;

            //time between previos and new hexagon
            nextTimeToSpawn = Time.time + 3f / spawnRate;
        }


    }

    private Color32 GetRandomColour32()
    {
        //using Color32
        return new Color32( (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255),255);
    }

    
}