using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;


public class WinCondition : MonoBehaviour
{

    float[] bP = new float[64];
    float[] p = new float[64];

    public static bool playerWon;

    public GameObject SuccessText;
    public GameObject InfoText;
    private void Start()
    {
        SuccessText.SetActive(false);
        InfoText.SetActive(false);
        playerWon = false;
    }
    private void Update()
    {
        if (playerWon) return;
        else if (Generator.isPuzzleVisible) Invoke("SuccessController", 10f);

    }
    public void SuccessController()
    {
        if (playerWon) return;
        else
        { 
        for (int i = 0; i < 64; i++)
        {
            if (!Generator.isPuzzleVisible) return;
            bP[i] = GameObject.Find("boardPiece" + i).transform.position.x;

            p[i] = GameObject.Find("piece" + i).transform.position.x;   

            if (bP.SequenceEqual(p))
            {
                if (!Generator.isPuzzleVisible) return;
                Debug.Log("YOU WIN!!!");
                SuccessText.SetActive(true);
                InfoText.SetActive(true);
                playerWon = true;
                break;
            }
        }
        }
    }
}
