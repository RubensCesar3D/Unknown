using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    [SerializeField] List<string> gameDificultyList = new List<string>();
    [SerializeField] string selectedDificulty;
    [SerializeField] BlocksMathHandler blockMathScript;
    [SerializeField] SlotsMathHandler  slotMathScript;

    //Things changed by dificulty 
    [SerializeField] public static int equationLenght;
    [SerializeField] public static int maxNumeral;
    [SerializeField] public static bool isMultiplication;
    [SerializeField] public static bool isGenius;
  
    private void Start()
    {
        if (selectedDificulty == gameDificultyList[0])
        {
            EasyDifficulty();
        }
        else if (selectedDificulty == gameDificultyList[1])
        {
            MediumDifficulty();
        }
        else if (selectedDificulty == gameDificultyList[2])
        {
            HardDifficulty();
        }
        else if (selectedDificulty == gameDificultyList[3])
        {
            GeniusDifficulty();
        }
    }

    public void EasyDifficulty() {
        equationLenght = 5;
        maxNumeral = 10;
        isMultiplication = false;
        isGenius = false;
        blockMathScript.ActivateBlocks(equationLenght, maxNumeral, isMultiplication);
        slotMathScript.ActivateSlots(equationLenght, maxNumeral, isMultiplication);
    }
    public void MediumDifficulty()
    {
        print("medium selected"); // debug
        equationLenght = 7;
        maxNumeral = 10;
        isMultiplication = true;
        blockMathScript.ActivateBlocks(equationLenght, maxNumeral, isMultiplication);
        slotMathScript.ActivateSlots(equationLenght, maxNumeral, isMultiplication);
    }
    public void HardDifficulty()
    {
        equationLenght = 7;
        maxNumeral = 25;
        isMultiplication = true;
        isGenius = false;
        blockMathScript.ActivateBlocks(equationLenght, maxNumeral, isMultiplication);
        slotMathScript.ActivateSlots(equationLenght, maxNumeral, isMultiplication);
    }
    public void GeniusDifficulty()
    {
        equationLenght = 7;
        maxNumeral = 50;
        isMultiplication = true;
        isGenius = true;
        blockMathScript.ActivateBlocks(equationLenght, maxNumeral, isMultiplication);
        slotMathScript.ActivateSlots(equationLenght, maxNumeral, isMultiplication);
    }


}
