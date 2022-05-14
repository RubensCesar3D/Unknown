//using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathHandler : MonoBehaviour
{

    //Block info
    [SerializeField] GameObject blockPrefab;
    [SerializeField] List<BlockInformation> blocksList = new List<BlockInformation>();

    //Equation Stuff
    [SerializeField] List<string> equationAdditionSym = new List<string>();
    [SerializeField] string equationDivision = "/";
    [SerializeField] string equationConstruction; // Original Equation string 

    //Result Display
    private float equationResult;
    [SerializeField] TextMeshProUGUI resultText;

    //Things changed by dificulty 
    public static int equationLenght;
    public static int maxNumeral;
    public static bool isMultiplication;


    private void Start()
    {
        //Create blocks based on lenght
        for (int integer = 0; integer < equationLenght; integer++)
        {
            GameObject newBlock = UnityEditor.PrefabUtility.InstantiatePrefab(blockPrefab.gameObject as GameObject) as GameObject;
            newBlock.transform.position = new Vector3(transform.position.x + Random.Range(0, 3), -10 + Random.Range(0, 3), 15);
            newBlock.transform.parent = gameObject.transform;
        }

        int i = 0;
        foreach (Transform child in transform)
        {
            //get script from child and enumerate
            BlockInformation childScript = child.gameObject.GetComponent<BlockInformation>();
            i++;

            //add to list
            blocksList.Add(childScript);
            if (i % 2 == 0)
            {
                // even - Symbols
                string assignSymbol = equationAdditionSym[Random.Range(0, equationAdditionSym.Count)];
                equationConstruction = equationConstruction + assignSymbol;
                childScript.AssignValues(0, false, assignSymbol);
                // print("even");

            }
            else
            {
                // odd - Numeral
                string assignNumber = "" + Random.Range(1, maxNumeral + 1);
                equationConstruction = equationConstruction + assignNumber;

                childScript.AssignValues(int.Parse(assignNumber), true, "");
            }
        }
        equationResult = Mathf.RoundToInt(float.Parse(new DataTable().Compute(equationConstruction, null).ToString()));
        resultText.text = "Can you build the bridge resulting in: " + equationResult;
    }
}
