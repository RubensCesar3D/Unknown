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
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y-10, transform.position.z);
        }

    }
    


    public void AdjustObjectPosition() {
        print("Susseexo!!!");

       


    }
}
