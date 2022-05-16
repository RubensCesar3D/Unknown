//using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class BlocksMathHandler : MonoBehaviour
{

    //Block info
    [SerializeField] GameObject blockNumPrefab;
    [SerializeField] List<BlockInformation> blocksList = new List<BlockInformation>();

    //Equation Stuff
    
    [SerializeField] string equationConstruction; // Original Equation string 

    //Result Display
    public static float equationResult;
    [SerializeField] TextMeshProUGUI resultText;

    public void ActivateBlocks(int lenght, int maxN, bool isMult, List<string> equationSymbolsList)
    {
        //Create blocks based on lenght
        for (int integer = 0; integer < lenght; integer++)
        {
            GameObject newBlock = Instantiate(blockNumPrefab.gameObject as GameObject) as GameObject;
            newBlock.name = newBlock.name + "_0" + integer; 
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
                string assignSymbol = equationSymbolsList[Random.Range(0, equationSymbolsList.Count)];
                equationConstruction = equationConstruction + assignSymbol;
                childScript.AssignValues(0, false, assignSymbol);
                // print("even");

            }
            else
            {
                // odd - Numeral
                string assignNumber = "" + Random.Range(1, maxN + 1);
                equationConstruction = equationConstruction + assignNumber;

                childScript.AssignValues(int.Parse(assignNumber), true, "");
            }
        }
        equationResult = Mathf.RoundToInt(float.Parse(new DataTable().Compute(equationConstruction, null).ToString()));
        resultText.text = "Can you build the bridge resulting in: " + equationResult;
    }
}
