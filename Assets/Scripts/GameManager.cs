using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    private int roadCount = 0;
    public float speed = 5f;
    private int obstacleCount = 3;
    public double roadWidth = 5;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/Road"), new Vector3(0, 0, 0), Quaternion.identity);
        InvokeRepeating("IncreaseSpeed", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnRoad(Vector3 endTriggerLocation)
    {
        roadCount++;

        GameObject road;

        switch (roadCount / 8)
        {
            case 0:
                // this could be a different road whenever we have others
                road = Resources.Load<GameObject>("Prefabs/Road");
                break;
            default:
                road = Resources.Load<GameObject>("Prefabs/Road");
                break;
        }

        Transform startTrigger = road.transform.Find("Cube/StartTrigger");

        // If this transform would be added, StartTrigger would be at 0;0;0
        Vector3 diffStartToRoad = startTrigger.position - road.transform.position;

        Vector3 instantiateLocation = endTriggerLocation - diffStartToRoad;

        var instantiatedObj = Instantiate(road, instantiateLocation, Quaternion.identity);

        Road roadScript = instantiatedObj.GetComponent<Road>();

        roadScript.LoadObstacleParents();

        int[] obstacleMaxCount = roadScript.GetObstacleCount();

        List<Vector2> obstacleIndexes = new List<Vector2>();

        obstacleIndexes = GetObstaclePairs(obstacleMaxCount);

        foreach (Vector2 index in obstacleIndexes)
        {
            roadScript.SpawnObstacle((int)index.x, (int)index.y, "Prefabs/Obstacles/Obstacle1");
        }
    }

    private void IncreaseSpeed()
    {
        speed += 0.1f;
    }

    public List<Vector2> GetObstaclePairs(int[] obstacleIndexes)
    {
        List<Vector2> selectedPairs = new List<Vector2>();

        int[] colCounts = new int[obstacleIndexes[1]]; // Tracks how many indexes have been chosen per row
        int maxRows = obstacleIndexes[0];
        int maxCols = obstacleIndexes[1];

        while (selectedPairs.Count < obstacleCount)
        {
            // Generate random row and column
            int randomRow = Random.Range(0, maxRows - 1);
            int randomCol = Random.Range(0, maxCols - 1);

            Vector2Int newPair = new Vector2Int(randomRow, randomCol);

            // Check if the row has reached its limit or the pair is already selected
            if (colCounts[randomRow] < (maxCols - 1) && !selectedPairs.Contains(newPair))
            {
                //check if the pair is not already selected

                if (selectedPairs.Count > 0)
                {
                    bool isPairAlreadySelected = false;
                    foreach (Vector2 pair in selectedPairs)
                    {
                        if (pair.x == randomRow && pair.y == randomCol)
                        {
                            isPairAlreadySelected = true;
                            break;
                        }
                    }

                    if (!isPairAlreadySelected)
                    {
                        selectedPairs.Add(newPair);
                        colCounts[randomRow]++;
                    }
                }
                else
                {
                    selectedPairs.Add(newPair);
                    colCounts[randomRow]++;
                }
            }
        }

        return selectedPairs;
    }
}
