using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    [SerializeField]
    private GameObject road;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CREATED");

        if (road != null)
        {
            Instantiate(road);
        }
        else Debug.LogError("Road not set");
    }
}
