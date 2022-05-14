using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    [SerializeField] List<string> gameDificultyList = new List<string>();
    [SerializeField] string selectedDificulty;
    [SerializeField] MathHandler mathScript;
    //[SerializeField] 

    private void Awake()
    {
        if (selectedDificulty == gameDificultyList[0]) {
            EasyDifficulty();
        }
        else if (selectedDificulty == gameDificultyList[0])
        {
            MediumDifficulty();
        }
        else if (selectedDificulty == gameDificultyList[0])
        {
            HardDifficulty();
        }
        else if (selectedDificulty == gameDificultyList[0])
        {
            GeniusDifficulty();
        }
    }

    public void EasyDifficulty() {
        

    }
    public void MediumDifficulty()
    {


    }
    public void HardDifficulty()
    {


    }
    public void GeniusDifficulty()
    {


    }


}
