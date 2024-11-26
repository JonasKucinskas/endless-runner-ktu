using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private double roadWidth;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        roadWidth = gameManager.roadWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        switch (horizontal)
        {
            case 1:
                if (gameObject.transform.position.x >= (float)(roadWidth / 4))
                {
                    break;
                }

                Vector3 pos = gameObject.transform.position;
                pos.x = pos.x + (float)(roadWidth / 4);
                gameObject.transform.position = pos;
                break;
            case -1:
                if (gameObject.transform.position.x <= -(float)(roadWidth / 4))
                {
                    break;
                }
                Vector3 pos2 = gameObject.transform.position;
                pos2.x = pos2.x - (float)(roadWidth / 4);
                gameObject.transform.position = pos2;
                break;
            default:
                break;
        }
    }
}
