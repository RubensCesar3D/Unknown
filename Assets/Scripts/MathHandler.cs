using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHandler : MonoBehaviour
{
    [SerializeField] int slotNumber;
    [SerializeField] List<Transform> slotPositions = new List<Transform>();

    private void Awake()
    {
        foreach (Transform child in transform.GetComponentInChildren<Transform>()) {
            slotPositions.Add(child.transform);
           // print("added" + child);
        }
    }   


  
}
