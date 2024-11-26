using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    GameObject gameManger;
    GameManager gameManagerScript;

    private GameObject[,] obstacleParents = new GameObject[4, 3];
    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.Find("GameManager");
        gameManagerScript = gameManger.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(0, 0, -gameManagerScript.speed) * Time.deltaTime; 
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    public void LoadObstacleParents()
    {
        GameObject ObstacleParent = gameObject.transform.Find("Cube/Obstacles").gameObject;
        for (int i = 1; i <= 4; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                obstacleParents[i - 1, j - 1] = ObstacleParent.transform.Find("Obstacle" + i + j).gameObject;
            }
        }
    }

    public int[] GetObstacleCount()
    {
        return new int[] { obstacleParents.GetLength(0), obstacleParents.GetLength(1) };
    }

    public void SpawnObstacle(int pos1, int pos2, string obstacleLocation)
    {
        GameObject obstacle = Resources.Load<GameObject>(obstacleLocation);

        var instantiatedObstacle = Instantiate(obstacle, obstacleParents[pos1, pos2].transform.position, Quaternion.identity);

        instantiatedObstacle.transform.parent = obstacleParents[pos1, pos2].transform;
    }
}
