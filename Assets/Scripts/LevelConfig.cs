using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class LevelConfig : MonoBehaviour
{
    [SerializeField] List<string> gameDificultyList = new List<string>();
    [SerializeField] BlocksMathHandler blockMathScript;
    [SerializeField] SlotsMathHandler slotMathScript;

    [SerializeField] ArtBehaviour artBehScript;
    [SerializeField] Camera mainCamera;
    [SerializeField] TextMeshProUGUI selectedDificultyTMP;



    //Things changed by dificulty 
    [SerializeField] public static int equationLenght;
    [SerializeField] public static int maxNumeral;
    [SerializeField] public static bool isMultiplication;
    [SerializeField] public static bool isGenius;
    [SerializeField] List<string> equationSymbolsList = new List<string>();

    public void GameStart()
    {
        equationSymbolsList.Add("+");
        equationSymbolsList.Add("-");
        equationSymbolsList.Add("*");



        if (selectedDificultyTMP.text == gameDificultyList[0])
        {
            EasyDifficulty();
        }
        else if (selectedDificultyTMP.text == gameDificultyList[1])
        {
            MediumDifficulty();
        }
        else if (selectedDificultyTMP.text == gameDificultyList[2])
        {
            HardDifficulty();
        }
        else if (selectedDificultyTMP.text == gameDificultyList[3])
        {
            GeniusDifficulty();
        }
    }

    public void EasyDifficulty()
    {
        mainCamera.orthographicSize = 5.5f;
        print("Easy selected"); // debug
        equationLenght = 5;
        maxNumeral = 10;
        isMultiplication = false;
        isGenius = false;
        //Activate voids
        blockMathScript.ActivateBlocks(equationLenght, maxNumeral, isMultiplication, equationSymbolsList);
        slotMathScript.ActivateSlots(equationLenght, maxNumeral, isMultiplication);
        artBehScript.MoveArtAssets();
    }
    public void MediumDifficulty()
    {
        mainCamera.orthographicSize = 7f;
        print("medium selected"); // debug
        equationLenght = 7;
        maxNumeral = 10;
        isMultiplication = true;
        isGenius = false;
        //Activate voids
        blockMathScript.ActivateBlocks(equationLenght, maxNumeral, isMultiplication, equationSymbolsList);
        slotMathScript.ActivateSlots(equationLenght, maxNumeral, isMultiplication);
        artBehScript.MoveArtAssets();

    }
    public void HardDifficulty()
    {
        mainCamera.orthographicSize = 9;
        print("Hard selected"); // debug
        equationSymbolsList.Add("/");
        equationLenght = 9;
        maxNumeral = 25;
        isMultiplication = true;
        isGenius = false;
        //Activate voids
        blockMathScript.ActivateBlocks(equationLenght, maxNumeral, isMultiplication, equationSymbolsList);
        slotMathScript.ActivateSlots(equationLenght, maxNumeral, isMultiplication);
        artBehScript.MoveArtAssets();
    }
    public void GeniusDifficulty()
    {
        mainCamera.orthographicSize = 9f;
        print("Genius selected"); // debug
        equationSymbolsList.Add("/");
        equationLenght = 9;
        maxNumeral = 50;
        isMultiplication = true;
        isGenius = true;
        //Activate voids
        blockMathScript.ActivateBlocks(equationLenght, maxNumeral, isMultiplication, equationSymbolsList);
        slotMathScript.ActivateSlots(equationLenght, maxNumeral, isMultiplication);
        artBehScript.MoveArtAssets();
    }


}
