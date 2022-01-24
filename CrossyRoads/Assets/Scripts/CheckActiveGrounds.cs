using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActiveGrounds : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 6)
        {
            for(int i = 1; i < 4; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
