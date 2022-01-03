using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndP : MonoBehaviour
{

    public GameObject endKey;

    public GameObject endPoint;
     void Update()
    {
    
        if (endKey.activeSelf)
        {
            endPoint.SetActive(false);
        }
        if(endKey.activeSelf == false)
        {
            endPoint.SetActive(true);
        }
    }
}
