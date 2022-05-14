//using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathHandler : MonoBehaviour
{
    [SerializeField] List<BlockInformation> blocksList = new List<BlockInformation>();
    [SerializeField] List<int> equationNumerals = new List<int>();
    [SerializeField] List<string> equationAdditionSym = new List<string>();
    [SerializeField] string equationDivision;
    [SerializeField] string equationConstruction;
    [SerializeField] TextMeshProUGUI resultText;

    [SerializeField] GameObject blockPrefab;

    public int operandsCap;
    private float equationResult;

    private void Start()
    {

        //equationResult = Random.RandomRange(0, )

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
                string assignNumber = "" + Random.Range(1, operandsCap + 1);
                equationConstruction = equationConstruction + assignNumber;

                childScript.AssignValues(int.Parse(assignNumber), true, "");
            }
        }
        equationResult = Mathf.RoundToInt(float.Parse(new DataTable().Compute(equationConstruction, null).ToString()));
        resultText.text = "Can you build the bridge resulting in: " + equationResult; 
    }
}
