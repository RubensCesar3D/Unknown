using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBehaviour : MonoBehaviour
{
    //Slot Info
    [SerializeField] int slotNumber;
    [SerializeField] bool isCollision =false;
    private bool isNumeralSlot;


    //Attatching Block info
    private bool isFilled;
    InteractableBehaviour blockScript;
    BlockInformation blockInfo;



    private void Start()
    {
    }
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
            isFilled =true; //prevents other blocks from attatching
            //get Scripts
            blockScript = otherScript;
            blockInfo = otherScript.gameObject.GetComponent<BlockInformation>();

            if (otherScript.slotNumber == 0 && isNumeralSlot == blockInfo.isNumber)
            {
                other.isTrigger = true;
                otherScript.rb.isKinematic = true;
                isCollision = true;
                otherScript.slotNumber = slotNumber;
            }
        }
      
    }
}
