using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject cubePrefab;
    GameObject[] cubes;
    Vector3[] positions;
    Quaternion[] rotations;
    Vector3[] scales;

    void Start()
    {
        cubes = new GameObject[10];

        for (int i = 0; i < 10; i++)
        {
            GameObject cube = Instantiate(cubePrefab, new Vector3(0, 3f, 0), Quaternion.identity);
            cube.name = "Cube-" + i;
            cubes[i] = cube;
        }
    }

    void Update()
    {
        positions = new Vector3[10];
        rotations = new Quaternion[10];
        scales = new Vector3[10];

        for (int i = 0; i < 10; i++)
        {
            GameObject cube = cubes[i];
            positions[i] = cube.transform.position;
            rotations[i] = cube.transform.rotation;
            scales[i] = cube.transform.localScale;
        }

        TransformJSON transformJSON = new TransformJSON();
        transformJSON.positions = positions;
        transformJSON.rotations = rotations;
        transformJSON.scales = scales;
        string jsonString = JsonUtility.ToJson(transformJSON, true);
        Debug.Log(jsonString);


        TransformJSON transformsData = JsonUtility.FromJson<TransformJSON>(jsonString);
        Vector3[] positionsData = transformsData.positions;
        Quaternion[] rotationsData = transformsData.rotations;
        Vector3[] scalesData = transformsData.scales;

        for (int i = 0; i < 10; i++)
        {
            GameObject newCube = new GameObject();
            newCube.transform.position = positionsData[i];
            newCube.transform.rotation = rotationsData[i];
            newCube.transform.localScale = scalesData[i];
            Debug.Log(newCube.transform.position);
        }

    }
}

public class TransformJSON
{
    public Vector3[] positions;
    public Quaternion[] rotations;
    public Vector3[] scales;
} 

