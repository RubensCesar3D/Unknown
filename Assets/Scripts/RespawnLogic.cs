using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bounds")
        {
            transform.localPosition = new Vector3(Random.Range(0, 3), Random.Range(0, 2), 15);
        }
    }
}
