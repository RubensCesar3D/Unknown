using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsMathHandler : MonoBehaviour
{
    //Slots info
    [SerializeField] GameObject slotNumeralPrefab;
    [SerializeField] GameObject slotSymbolPrefab;
    [SerializeField] List<SlotBehaviour> slotList = new List<SlotBehaviour>();

    public void ActivateSlots(int lenght, int maxN, bool isMult)
    {
        //Create slots based on lenght
        for (int integer = 0; integer < lenght; integer++)
        {
            GameObject newSlot = UnityEditor.PrefabUtility.InstantiatePrefab(slotNumeralPrefab.gameObject as GameObject) as GameObject;
            newSlot.transform.parent = gameObject.transform;
            SlotBehaviour slotScript = newSlot.GetComponent<SlotBehaviour>();

            //Name conv
            newSlot.name = newSlot.name + "_0" + integer;
            //Add right Slot number
            slotScript.slotNumber = +integer;
            //Position according to lenght
            newSlot.transform.localPosition = new Vector3(((((3 * lenght) - 3) / 2) * (-1)) + (3 * slotScript.slotNumber), 0, 0);
        }
    }
}
