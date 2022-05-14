using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockInformation : MonoBehaviour
{
    public bool isNumber;
    public int value;
    public string symbol;

    [SerializeField] private TextMeshProUGUI displayValueTMP;


    public void AssignValues(int feedValue, bool feedBool, string feedSymbol)
    {
        if (displayValueTMP == null)
        {
            displayValueTMP = GetComponentInChildren<TextMeshProUGUI>();
        }
        symbol = feedSymbol;
        isNumber = feedBool;


        if (isNumber && displayValueTMP != null)
        {
            value = feedValue;
            displayValueTMP.text = "" + value;
        }
        else if (!isNumber && displayValueTMP != null)
        {
            displayValueTMP.text = "" + symbol;
        }
        
    }

}
