using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBehaviour : MonoBehaviour
{

    
    [SerializeField] bool isMoveable;
    [SerializeField] bool isRotateable;
    public bool isActive;
    [SerializeField] MoveObjectHandler script;
    private void Start()
    {
        this.enabled = false;
    }
    private void Update()
    {
        /*  if (isActive) {
              AdjustObjectPosition();
          } else if (!isActive) {
              this.enabled = false;

          }*/
        if (isMoveable)
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }

    }
    


    public void AdjustObjectPosition() {
        print("Susseexo!!!");

       


    }
}
