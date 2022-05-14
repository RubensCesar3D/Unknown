using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectHandler : MonoBehaviour
{
    public static MoveObjectHandler handlerScript;
    [SerializeField] LayerMask selectLayer;
    [SerializeField] bool isEditMode;

    private void Awake()
    {
        handlerScript = gameObject.GetComponent<MoveObjectHandler>();
    }
    void FixedUpdate()
    {

        if (Input.GetMouseButton(0) && isEditMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            if (Physics.Raycast(ray, out hit, 100f, selectLayer)) {
                InteractableBehaviour scriptIB = hit.collider.gameObject.GetComponent<InteractableBehaviour>();
                ActivateInteraction(scriptIB);
                print("activate");
            }
        }
    }
    void ActivateInteraction(InteractableBehaviour scriptIB) {
        scriptIB.enabled = true;
        scriptIB.isActive = true;
        this.enabled = false;
    }
}
