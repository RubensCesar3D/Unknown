using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectHandler : MonoBehaviour
{
    


    void FixedUpdate()
    {
        
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);
            


            if (hit.collider.gameObject.tag == "Interactable")
            {
                InteractableBehaviour scriptIB = hit.collider.gameObject.GetComponent<InteractableBehaviour>();
                ActivateInteraction(scriptIB);
            }
            else {
                return;
            }
            
        }
    }
    void ActivateInteraction(InteractableBehaviour scriptIB) {
        scriptIB.enabled = true;
        scriptIB.isActive = true;
        this.enabled = false;
    }
}
