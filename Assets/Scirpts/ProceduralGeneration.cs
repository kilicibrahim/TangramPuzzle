using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ProceduralGeneration
{
    private Dictionary<int, bool> valuesD = new Dictionary<int, bool>();

    private List<List<int>> piecee = new List<List<int>>();

    public List<List<int>> pGenerate(int pieceNumber, int pieceSize)
    {
        
        randomPiece(pieceNumber, pieceSize);

        return piecee;
    }

    private void fillValues()
    {
        if(valuesD ==null) for (int i = 0; i < 64; i++) valuesD.Add(i, true);
        else for (int i = 0; i < 64; i++) valuesD[i] = true;
    }

    public void randomPiece(int pieceNumber, int pieceSize)
    {
        fillValues();
        pieceFiller(pieceNumber, pieceSize);
        pieceFiller(pieceNumber, pieceSize); // calling it twice so that no empty piece occurs

        // to check pieces
        for (int q = 0; q < piecee.Count; q++)
        {
            for (int w = 0; w < piecee[q].Count; w++)
            {
                Debug.Log("piece [" + q + "] " + "[" + piecee[q].Count + "] = " + piecee[q][w]);
            }

        }

    }
    private void pieceFiller(int pieceNumber, int pieceSize)
    {
        for (int i = 0; i < pieceNumber; i++)
        {
            List<int> tempL = pieceDoldur(i, pieceSize);
            if (!(tempL.Count == 0)) piecee.Add(tempL);

        }
    }

    List<int> pieceDoldur(int pieceN, int pieceS)
    {
        List<int> tempList = new List<int>();
        tempList.Clear();
        bool breakingTheAllLoop = false;
        int element = 0;
        int valueOfTri = Random.Range(0, valuesD.Count);
        int breakCounter = 0;
        while (valuesD[valueOfTri] == false) // busy waiting, change it if you got time
        {
            breakCounter++;
            valueOfTri = Random.Range(0, valuesD.Count);
            if (breakCounter == 1000)
            {
                breakingTheAllLoop = true;
                break;
            }
        }
        if (breakingTheAllLoop == true) return tempList;
        tempList.Add(valueOfTri);

        element += 1;

        while (element < pieceS)
        {


            if (valueOfTri % 4 == 0) //lower triangle
            {
                valuesD[valueOfTri] = false;
                int tempValue = valueOfTri;
                valueOfTri = lowerTriValue(valueOfTri);
                int breaker = 0;
                while (valuesD[valueOfTri] == false)
                {
                    valueOfTri = lowerTriValue(tempValue);
                    breaker++;
                    if (breaker >= 4) element++;
                    if (element == pieceS)
                    {
                        breakingTheAllLoop = true;
                        break;
                    }
                }
                if (breakingTheAllLoop == true) break;

                tempList.Add(valueOfTri);
                element++;
                valuesD[valueOfTri] = false;
            }


            else if (valueOfTri % 4 == 1) //right triangle
            {
                valuesD[valueOfTri] = false;
                int tempValue = valueOfTri;
                valueOfTri = rightTriValue(valueOfTri);
                int breaker = 0;
                while (valuesD[valueOfTri] == false)
                {
                    valueOfTri = rightTriValue(tempValue);
                    breaker++;
                    if (breaker >= 4) element++;
                    if (element == pieceS)
                    {
                        breakingTheAllLoop = true;
                        break;
                    }
                }
                if (breakingTheAllLoop == true) break;

                tempList.Add(valueOfTri);
                element++;
                valuesD[valueOfTri] = false;
            }
            else if (valueOfTri % 4 == 2) //upper triangle
            {
                valuesD[valueOfTri] = false;
                int tempValue = valueOfTri;
                valueOfTri = upperTriValue(valueOfTri);
                int breaker = 0;
                while (valuesD[valueOfTri] == false)
                {
                    valueOfTri = upperTriValue(tempValue);
                    breaker++;
                    if (breaker >= 4) element++;
                    if (element == pieceS)
                    {
                        breakingTheAllLoop = true;
                        break;
                    }
                }
                if (breakingTheAllLoop == true) break;

                tempList.Add(valueOfTri);
                element++;
                valuesD[valueOfTri] = false;
            }
            else if (valueOfTri % 4 == 3)//left triangle
            {
                valuesD[valueOfTri] = false;
                int tempValue = valueOfTri;
                valueOfTri = leftTriValue(valueOfTri);
                int breaker = 0;
                while (valuesD[valueOfTri] == false)
                {
                    valueOfTri = leftTriValue(tempValue);
                    breaker++;
                    if (breaker >= 4) element++;
                    if (element == pieceS)
                    {
                        breakingTheAllLoop = true;
                        break;
                    }
                }
                if (breakingTheAllLoop == true) break;

                tempList.Add(valueOfTri);
                element++;
                valuesD[valueOfTri] = false;

            }


        }

        return tempList;
    }

    private int leftTriValue(int valueOfTri)
    {
        if (valueOfTri == 51 || valueOfTri == 35 || valueOfTri == 19 || valueOfTri == 3) // valueOfTri == 11 || valueOfTri == 3 for 2x2 // 51, 35, 19, 3 4x4 ve 6x6 için değiştirilmeli
        {
            if (Random.value < 0.5f) valueOfTri = valueOfTri - 1;
            else valueOfTri = valueOfTri - 3;
        }
        else
        {
            float x = Random.value;
            if (x < 0.33f) valueOfTri = valueOfTri - 6;
            else if (x > 0.34f && x < 0.67f) valueOfTri = valueOfTri - 1;
            else valueOfTri = valueOfTri - 3;

        }
        return valueOfTri;
    }

    private int upperTriValue(int valueOfTri)
    {
        if (valueOfTri / 16 == 0) //valueOfTri / 8 == 0 2x2 square için // 12 == 0 3x3 // 16 == 0 for 4x4 // 6x6 
        {
            float x = Random.value;
            if (x < 0.33f) valueOfTri = valueOfTri + 14; //+6 for 2x2 // +10 for 3x3 // +14 for 4x4
            else if (x > 0.34f && x < 0.67f) valueOfTri = valueOfTri - 1;
            else valueOfTri = valueOfTri + 1;
        }
        else
        {
            if (Random.value < 0.5f) valueOfTri = valueOfTri + 1;
            else valueOfTri = valueOfTri - 1;
        }
        return valueOfTri;
    }

    private int rightTriValue(int valueOfTri)
    {
        if (valueOfTri == 61 || valueOfTri == 45 || valueOfTri == 29 || valueOfTri == 13) // valueOfTri == 9 || valueOfTri == 1 for 2x2 // 13, 29, 45, 61 4x4 // 6x6 
        {
            if (Random.value < 0.5f) valueOfTri = valueOfTri + 1;
            else valueOfTri = valueOfTri - 1;
        }
        else
        {
            float x = Random.value;
            if (x < 0.34f) valueOfTri = valueOfTri + 6;
            else if (x > 0.34f && x < 0.67f) valueOfTri = valueOfTri - 1;
            else valueOfTri = valueOfTri + 1;

        }
        return valueOfTri;
    }

    private int lowerTriValue(int valueOfTri)
    {
        if (valueOfTri / 16 > 0) // valueOfTri / 8 > 0, 2x2 square // 12 > 0  3x3 // 16>0 4x4 için değiştirilmeli
        {
            float x = Random.value;
            if (x < 0.34f) valueOfTri = valueOfTri + 1;
            else if (x > 0.34f && x < 0.67f) valueOfTri = valueOfTri + 3;
            else valueOfTri = valueOfTri - 14; // -6 for 2x2 square // -10 for 3x3 // -14 for 4x4
        }
        else
        {
            if (Random.value < 0.5f) valueOfTri = valueOfTri + 1;
            else valueOfTri = valueOfTri + 3;
        }
        return valueOfTri;
    }

    public void clearPieces()
    {
        piecee.Clear();
        fillValues();
    }
}
