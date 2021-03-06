using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class SlotsMathHandler : MonoBehaviour
{
    //Slots info
    [SerializeField] GameObject slotNumeralPrefab;
    [SerializeField] GameObject slotSymbolPrefab;
    [SerializeField] List<SlotBehaviour> slotList = new List<SlotBehaviour>();

    //Submit Result
    private string finalAnswer;
    private float playerEquationResult;
    private int slotsFilledCount =0;

    //Add to EndScreen
    [SerializeField] List<TextMeshProUGUI> displayYourEquation = new List<TextMeshProUGUI>();
    [SerializeField] List<TextMeshProUGUI> displayYourResult = new List<TextMeshProUGUI>();
    [SerializeField] List<TextMeshProUGUI> displayExpectedResult = new List<TextMeshProUGUI>();
    [SerializeField] List<GameObject> endScreen = new List<GameObject>();
    [SerializeField] GameObject playScene;

    [SerializeField] Button buildBridgeBTN;

    public void ActivateSlots(int lenght, int maxN, bool isMult)
    {
        //Create slots based on lenght
        for (int integer = 0; integer < lenght; integer++)
        {
            if ((integer + 1) % 2 == 0)
            {
                // even - Spwan Symbols Slot
                GameObject newSlot = Instantiate(slotSymbolPrefab.gameObject as GameObject) as GameObject;

                //Make instance a child, get script and add to list
                newSlot.transform.parent = gameObject.transform;
                SlotBehaviour slotScript = newSlot.GetComponent<SlotBehaviour>();
                slotList.Add(slotScript);

                //Set it as Symbol
                slotScript.isNumeralSlot = false;

                //Name conv
                newSlot.name = newSlot.name + "_0" + integer;
                //Add right Slot number
                slotScript.slotNumber = +integer;
                //Position according to equation lenght
                newSlot.transform.localPosition = new Vector3(((((3 * lenght) - 3) / 2) * (-1)) + (3 * slotScript.slotNumber), 0, 0);
            }
            else
            {
                // Odd - Spwan Numeral Slot
                GameObject newSlot = Instantiate(slotNumeralPrefab.gameObject as GameObject) as GameObject;

                //Make instance a child, get script and add to list
                newSlot.transform.parent = gameObject.transform;
                SlotBehaviour slotScript = newSlot.GetComponent<SlotBehaviour>();
                slotList.Add(slotScript);

                //Set it as Number
                slotScript.isNumeralSlot = true;

                //Name conv
                newSlot.name = newSlot.name + "_0" + integer;
                //Add right Slot number
                slotScript.slotNumber = +integer;
                //Position according to lenght
                newSlot.transform.localPosition = new Vector3(((((3 * lenght) - 3) / 2) * (-1)) + (3 * slotScript.slotNumber), 0, 0);
            }
        }
    }
    private void Update()
    {
        foreach (SlotBehaviour slot in slotList)
        {
            if (slot.isCollision)
            {
                slotsFilledCount++;
            }
            else {
                slotsFilledCount = 0;

            }
        }
        if (slotsFilledCount > +LevelConfig.equationLenght)
        {
            buildBridgeBTN.interactable = true;
        }
        else {
            buildBridgeBTN.interactable = false ;
        }
    }



    public void SubmitEquation()
    {
        //Add equation to String
        foreach (SlotBehaviour slot in slotList)
        {
            if (slot.isNumeralSlot)
            {
                finalAnswer = finalAnswer + slot.blockInfo.value + " ";
            }
            else
            {
                finalAnswer = finalAnswer + slot.blockInfo.symbol + " ";
            }
        }


        playerEquationResult = Mathf.RoundToInt(float.Parse(new DataTable().Compute(finalAnswer, null).ToString()));
       
        //old
        //resultTMP.text = "Your bridge result is: " + playerEquationResult;
        //resultScreen.SetActive(true);
        //Destroy(this);

        if (playerEquationResult == BlocksMathHandler.equationResult)
        {
            SendToWinScene();
        }
        else {
            SendToLoserScene();
        }
        
    }
    void SendToWinScene()
    {
        playScene.SetActive(false);
        endScreen[0].SetActive(true);
        endScreen[1].SetActive(true);
        displayYourEquation[0].text = finalAnswer;
        displayYourResult[0].text = "" + playerEquationResult;
        displayExpectedResult[0].text = "" + BlocksMathHandler.equationResult;




    }
    void SendToLoserScene()
    {
        playScene.SetActive(false);
        endScreen[0].SetActive(true);
        endScreen[2].SetActive(true);
        displayYourEquation[1].text = finalAnswer;
        displayYourResult[1].text = "" + playerEquationResult;
        displayExpectedResult[1].text = ""+BlocksMathHandler.equationResult;



    }

}
