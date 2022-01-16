using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndP : MonoBehaviour
{
    public GameObject endPoint;
    public GameObject keyAcquiredUI;
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);

            endPoint.SetActive(true);
            keyAcquiredUI.SetActive(true);
        }
    }
}
