using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBehaviour : MonoBehaviour
{

    [SerializeField] int slotNumber;
    [SerializeField] bool isCollision =false;
    InteractableBehaviour blockScript;

    private void Update()
    {
        if (blockScript.isActive == true)
        {
            isCollision = false;

        }
        if (isCollision)
        {
            blockScript.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.time * 0.05f);
            blockScript.transform.position = Vector3.Lerp(blockScript.transform.position, transform.position, 0.2f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InteractableBehaviour otherScript) && otherScript.isActive == false)
        {
            blockScript = otherScript;
            if (otherScript.slotNumber == 0)
            {
                otherScript.rb.isKinematic = true;
                isCollision = true;
                otherScript.slotNumber = slotNumber;
            }
        }
      
    }
}
