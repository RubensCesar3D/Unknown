using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBehaviour : MonoBehaviour
{

    [SerializeField] int slotNumber;
    [SerializeField] bool isCollision =false;
    private bool isFilled;
    InteractableBehaviour blockScript;

    private void Update()
    {
        if (blockScript != null && blockScript.isActive == true)
        {
            isCollision = false;
            isFilled = false;
        }
        if (isCollision)
        {
            blockScript.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.time * 0.05f);
            blockScript.transform.position = Vector3.Lerp(blockScript.transform.position, transform.position, 0.2f);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InteractableBehaviour otherScript) && otherScript.isActive == false && otherScript.isClicked && !isFilled)
        {
            isFilled =true;
            blockScript = otherScript;
            if (otherScript.slotNumber == 0)
            {
                other.isTrigger = true;
                otherScript.rb.isKinematic = true;
                isCollision = true;
                otherScript.slotNumber = slotNumber;
            }
        }
      
    }
}
