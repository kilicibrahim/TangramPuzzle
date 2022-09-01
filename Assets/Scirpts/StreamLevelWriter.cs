using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StreamLevelWriter : MonoBehaviour
{
    Generator Gen;
    public List<List<int>> pieceToWrite = new List<List<int>>();
    string[] Result;
    private void Start()
    {
        Gen = this.gameObject.GetComponent<Generator>();
        Directory.CreateDirectory(Application.dataPath + "/Levels/");
    }

    public void WriteToTxt()
    {
        pieceToWrite = Gen.piece;
        string path = Application.dataPath + "/Levels/" + "level" +  ".txt";
        Result = new string[pieceToWrite.Count];
        
        for (int i = 0; i< pieceToWrite.Count; i++)
        {
            var temp = string.Join("; ", pieceToWrite[i]);
            Result[i] = temp;
        }
        File.WriteAllLines(path, Result);
    }
}
