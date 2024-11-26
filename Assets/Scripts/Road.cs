using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(0, 0, -speed) * Time.deltaTime; 
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
