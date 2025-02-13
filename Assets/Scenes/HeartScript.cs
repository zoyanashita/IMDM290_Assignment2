using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System;

public class NewMonoBehaviourScript : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 500; 
    float time = 0f;
    Vector3[] initPos;
    private Vector3[] startPos;    
    private Vector3[] heartPos;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];
        startPos = new Vector3[numSphere];
        heartPos = new Vector3[numSphere];

        // making spheres
        for (int i = 0; i < numSphere; i++){

            // random start positions 
            float randRange = 15f;
            startPos[i] = new Vector3(
                Random.Range(-randRange, randRange),
                Random.Range(-randRange, randRange),
                Random.Range(-randRange, randRange)
            );

            // heart equation
            float t = i * 6f * Mathf.PI / numSphere; 
            float x = Mathf.Sin(t); 
            float y = Mathf.Cos(t);
            heartPos[i] = new Vector3(
                5f * (float)(Mathf.Sqrt(2f) * Mathf.Pow(x, 3)),
                5f * (float)((2f * y) - Mathf.Pow(y, 2) - Mathf.Pow(y, 3)),
                20f
            );

            // making spheres
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            spheres[i].transform.position = startPos[i];

            // assigning color
            Renderer r = spheres[i].GetComponent<Renderer>();
            float hue = (float)i / numSphere;
            Color color = Color.HSVToRGB(hue, 1f, 1f);
            r.material.color = color;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
       
        // NOTE : goes from 0 -> 1 -> 0 -> 1 continuously, multiplying 2f to go faster
        float lerpFraction = 0.5f * (1 + Mathf.Sin(time * 2f));

        // lerp from startPos to heartPos
        for (int i = 0; i < numSphere; i++)
        {
            spheres[i].transform.position 
                = Vector3.Lerp(startPos[i], heartPos[i], lerpFraction);

            // FUN COLORS !!
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            float hue = (float)i / numSphere; // Hue cycles through 0 to 1
            Color color = Color.HSVToRGB(Mathf.Abs(hue * Mathf.Sin(time)), Mathf.Cos(time), 2f + Mathf.Cos(time)); // Full saturation and brightness
            sphereRenderer.material.color = color;
        }
    }
}
