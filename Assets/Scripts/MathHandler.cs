using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHandler : MonoBehaviour
{
    [SerializeField] List<BlockInformation> slotPositions = new List<BlockInformation>();
    int i;

    private void Awake()
    {
        foreach (BlockInformation child in slotPositions) {
            i++;
            child.AssignValues(5+i,true, "null" );
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
