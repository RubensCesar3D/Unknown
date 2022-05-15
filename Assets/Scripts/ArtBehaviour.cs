using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtBehaviour : MonoBehaviour
{
    [SerializeField] Transform floorTransform;
    [SerializeField] Transform backgroundMesh;
    [SerializeField] List<GameObject> cliffslist = new List<GameObject>();
    

    public void MoveArtAssets()
    {

        int i = 1;
        foreach (GameObject cliff in cliffslist)
        {
            i = i * -1;
            cliff.transform.localPosition = new Vector3(((((3 * LevelConfig.equationLenght) - 3) / 2 + 3) * i), -9, 15);
        }

        floorTransform.localScale = new Vector3((3 * LevelConfig.equationLenght) + 5, 10, 5);

        backgroundMesh.localScale = new Vector3((((3 * LevelConfig.equationLenght) + 5) / 10f), 1 * LevelConfig.equationLenght, 1.5f);

    }
}
