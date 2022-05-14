using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class InteractableBehaviour : MonoBehaviour
{


    [SerializeField] LayerMask ignoreLayers;
    public bool isActive;
    public bool isClicked = false;
    [SerializeField] bool isMoveable;
    

    [SerializeField] MoveObjectHandler script;
    [SerializeField] float objectMoveSpeed;
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Collider colliderBox;
    [SerializeField] public int slotNumber;



    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        colliderBox = gameObject.GetComponent<Collider>();

        if (slotNumber == 0) {
            print(gameObject.name + " does't have a slot number assigned");
        }
        this.enabled = false;
    }

    void Update()
    {
        if (isMoveable && Input.GetMouseButton(0))
        {
            isClicked = true;
            isActive = true;
            colliderBox.isTrigger = false;
            rb.isKinematic = true;
            slotNumber = 0;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            if (Physics.Raycast(ray, out hit, ignoreLayers))
            {
                //Vector3 mousePosition = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), transform.position.z);
                Vector3 mousePosition = new Vector3(hit.point.x, hit.point.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, mousePosition, objectMoveSpeed);
            }
        }
        else if (Input.GetMouseButtonUp(0) && isActive)
        {
            isActive = false;
            script.enabled = true;
            rb.isKinematic = false;
            this.enabled = false;
        }
    }


    public void AdjustObjectPosition() {
        

       


    }
}
