using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHandler : MonoBehaviour
{
    [SerializeField] List<Transform> slotPositions = new List<Transform>();

    private void Awake()
    {
        foreach (Transform child in transform.GetComponentInChildren<Transform>()) {
            slotPositions.Add(child.transform);
            // print("added" + child);
        }
        if (slotPositions.Count % 2 == 0)
            {
                print("even");// even
            }
            else
            {
                print("odd");// odd
        }
    }   


  
}
