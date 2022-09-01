using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    WinCondition WC;
    ProceduralGeneration ProGen;
    VisualizePuzzle VisPuzzle;
    public List<List<int>> piece = new List<List<int>>();

    public static bool isPuzzleVisible = false;
    public void Start()
    {
        ProGen = new ProceduralGeneration();
        VisPuzzle = this.gameObject.GetComponent<VisualizePuzzle>();
        WC = this.gameObject.GetComponent<WinCondition>();
    }

    private void Update()
    {
        if (WinCondition.playerWon) Invoke("ClearPuzzle", 4f);
    }
    public void EasyGame()
    {
        WC.SuccessText.SetActive(false);
        WC.InfoText.SetActive(false);
        piece = ProGen.pGenerate(7, 40);
        VisPuzzle.visulizePiece(piece);
        isPuzzleVisible = true;
        
    }
    public void MediumGame()
    {
        WC.SuccessText.SetActive(false);
        WC.InfoText.SetActive(false);
        piece = ProGen.pGenerate(7, 30);
        VisPuzzle.visulizePiece(piece);
        isPuzzleVisible = true;
        
    }

    public void HardGame()
    {
        WC.SuccessText.SetActive(false);
        WC.InfoText.SetActive(false);
        piece = ProGen.pGenerate(8, 20);
        VisPuzzle.visulizePiece(piece);
        isPuzzleVisible = true;
        
    }

    private void ClearPuzzle()
    {
        WinCondition.playerWon = false;
        ProGen.clearPieces();
        VisPuzzle.cleanVisuals();
        isPuzzleVisible = false;
    }
}
