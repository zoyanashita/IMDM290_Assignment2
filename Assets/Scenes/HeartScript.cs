using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 100; 
    float time = 0f;
    Vector3[] initPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];

        // making spheres
        for (int i = 0; i < numSphere; i++){
            // circle radius
            // circle radius 
            float r = 10f; 

            // drawing the elements 
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere); 

            // making position of spheres with the radius 
            initPos[i] = new Vector3(r * Mathf.Sin(i * 2 * Mathf.PI / numSphere), r * Mathf.Cos(i * 2 * Mathf.PI / numSphere), 10f);
            spheres[i].transform.position = initPos[i];

            // Get the renderer of the spheres and assign colors.
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            // hsv color space: https://en.wikipedia.org/wiki/HSL_and_HSV
            float hue = (float) i / numSphere; // Hue cycles through 0 to 1
            Color color = Color.HSVToRGB(hue, 1f, 1f); // Full saturation and brightness
            sphereRenderer.material.color = color;
        }   
    }

    // Update is called once per frame
    void Update()
    {
         time += Time.deltaTime;
        // changing color as it moves 
        for (int i =0; i < numSphere; i++){
            // position
            // spheres[i].transform.position = initPos[i] 
            //                                + new Vector3(Mathf.Sin(time) * 5f, Mathf.Cos(time)* 3f, 1f) ;
            // color
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            float hue = (float)i / numSphere; // Hue cycles through 0 to 1
            Color color = Color.HSVToRGB(Mathf.Abs(hue * Mathf.Sin(time)), Mathf.Cos(time), 2f + Mathf.Cos(time)); // Full saturation and brightness
            sphereRenderer.material.color = color;
        }
    }
}
