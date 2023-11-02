using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Renderer originalRenderer;

   void Start()
{
    meshFilter = GetComponent<MeshFilter>();
    originalRenderer = GetComponent<Renderer>();

    if (meshFilter != null)
    {
        if (meshFilter.sharedMesh != null)
        {
            CreateObjects(200, "Asteroid");
        }
        else
        {
            Debug.LogError("sharedMesh is null on the MeshFilter.");
        }
    }
    else
    {
        Debug.LogError("MeshFilter not found on the GameObject.");
    }
}


    void CreateObjects(int numberOfObjectsToCreate, string objectName)
    {
        for (int i = 0; i < numberOfObjectsToCreate; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            // Assign the sharedMesh from the original object's MeshFilter to the new object's MeshFilter.
            MeshFilter newMeshFilter = go.GetComponent<MeshFilter>();
            if (newMeshFilter != null)
            {
                newMeshFilter.sharedMesh = meshFilter.sharedMesh;
            }

            Renderer newRenderer = go.GetComponent<Renderer>();
            if (newRenderer != null && originalRenderer != null)
            {
                newRenderer.material = originalRenderer.material;
            }

            // add rigidbody

            Rigidbody rb = go.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.angularDrag = 0.05f;
            rb.mass = 50;
            rb.AddForce(new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), Random.Range(-30, 30)), ForceMode.Impulse);

            // Add random scales 
            float scale = Random.Range(0.1f, 3f);
            go.transform.localScale = new Vector3(scale, scale, scale);


            go.transform.position = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(50, 150));
            go.transform.rotation = Random.rotation;
            go.name = objectName + i;

            
        }
    }
}
