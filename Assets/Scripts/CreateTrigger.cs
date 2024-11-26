using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject GameManager;
    private GameManager gameManagerScript;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        gameManagerScript = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "EndTrigger")
        {
            gameManagerScript.SpawnRoad(other.transform.position);
        }
    }
}
