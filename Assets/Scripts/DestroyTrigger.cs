using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
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
        if (other.name == "EndTrigger")
        {
            GameObject mainParent = other.gameObject;

            while (mainParent.transform.parent != null)
            {
                if (mainParent.transform.parent.tag == "Road")
                {
                    Destroy(mainParent.transform.parent.gameObject);
                    break;
                }
                else
                {
                    mainParent = mainParent.transform.parent.gameObject;
                }
            }
        }
    }
}
