using UnityEngine;
using System.Collections.Generic;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public float planeSize = 10f;
    public float minDistance = 1.0f;
    private List<Vector3> generatedPositions = new List<Vector3>();

    void Start()
    {
        GenerateCubes();
    }

    void GenerateCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = GenerateUniqueRandomPosition();
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GenerateUniqueRandomPosition()
    {
        Vector3 randomPosition;
        do
        {
            randomPosition = GenerateRandomPosition();
        } while (IsPositionGenerated(randomPosition));

        generatedPositions.Add(randomPosition);
        return randomPosition;
    }

    Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(-planeSize / 2f, planeSize / 2f);
        float z = Random.Range(-planeSize / 2f, planeSize / 2f);
        return new Vector3(x, 0.5f, z);
    }

    bool IsPositionGenerated(Vector3 position)
    {
        foreach (Vector3 existingPosition in generatedPositions)
        {
            if (Vector3.Distance(position, existingPosition) < minDistance)
            {
                return true;
            }
        }
        return false;
    }
}