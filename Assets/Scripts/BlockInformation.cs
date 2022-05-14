using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockInformation : MonoBehaviour
{
    public bool isNumber;
    public int value;
    public string symbol;

    private TextMeshPro displayValue;

    public void AssignValues(int feedValue, bool feedBool, string feedSymbol) {
        isNumber = feedBool;
        if (isNumber)
        {
            value = feedValue;
            //displayValue.text = "" + value;
            print("" + value);
        }
        else {
            symbol = feedSymbol;
            //displayValue.text = "" + symbol;
            print("" + symbol);
        }

    }



}
