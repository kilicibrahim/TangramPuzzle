using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizePuzzle : MonoBehaviour
{
    public List<List<GameObject>> PieceVisual = new List<List<GameObject>>();
    public List<Transform> Parents = new List<Transform>();
    public GameObject pieceVisual;
    public GameObject boardVisual;

    int pieceCount;

    new Renderer renderer;
    public void visulizePiece(List<List<int>> piece)
    {
        pieceCount = piece.Count;
        for (int q = 0; q <pieceCount; q++)
        {
            Parents.Add(transform);
            List<GameObject> temp = new List<GameObject>();
            for (int w = 0; w < piece[q].Count; w++)
            {
                var holder = piece[q][w];
                temp.Add(pieceVisual);
            }
            PieceVisual.Add(temp);

            GameObject boardPieceParent = new GameObject("BoardPiece" + q);
            GameObject pieceParent = new GameObject("Piece" + q);

            for (int w = 0; w < piece[q].Count; w++)
            {

                var holder = piece[q][w];
                visulizerBoard(holder, boardPieceParent);
                visualizer(holder, q, w, pieceParent);

            }
        }
        CleanBoard();

        int pieceSize = piece.Count;
        ShufflePieces(pieceSize);

    }

    private void ShufflePieces(int pS)
    {
        for (int j = 0; j < pS; j++)
        {
            float x = Random.Range(0, 3);
            float y = Random.Range(-2, 2);
            GameObject.Find("Piece" + j).transform.position += new Vector3(x, y, 0); 

        }
    }

    private void CleanBoard()
    {
        for (int i = 0; i < 64; i++) Destroy(GameObject.Find("" + i));
    }

    public void visulizerBoard(int holder, GameObject boardPieceParent)
    {
        GameObject tempObject = new GameObject("" + holder);
        float x = (holder / 4) % 4 + 0.5f - 6;
        float y = (holder / 16) + 0.5f;
        if (holder % 4 == 0)
        {
            tempObject = Instantiate(boardVisual, transform.position + new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));

        }
        else if (holder % 4 == 1)
        {
            tempObject = Instantiate(boardVisual, transform.position + new Vector3(x, y, 0), Quaternion.Euler(0, 0, 90));
        }
        else if (holder % 4 == 2)
        {
            tempObject = Instantiate(boardVisual, transform.position + new Vector3(x, y, 0), Quaternion.Euler(0, 0, 180));
        }
        else if (holder % 4 == 3)
        {
            tempObject = Instantiate(boardVisual, transform.position + new Vector3(x, y, 0), Quaternion.Euler(0, 0, 270));
        }
        tempObject.transform.SetParent(boardPieceParent.transform, true);
        tempObject.name = ("boardPiece" + holder);
    }
    public void visualizer(int holder, int q, int w, GameObject pieceParent)
    {

        float x = (holder / 4) % 4 + 0.5f;
        float y = (holder / 16) + 0.5f;
        if (holder % 4 == 0)
        {
            PieceVisual[q][w] = Instantiate(pieceVisual, transform.position + new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
        }
        else if (holder % 4 == 1)
        {
            PieceVisual[q][w] = Instantiate(pieceVisual, transform.position + new Vector3(x, y, 0), Quaternion.Euler(0, 0, 90));
        }
        else if (holder % 4 == 2)
        {
            PieceVisual[q][w] = Instantiate(pieceVisual, transform.position + new Vector3(x, y, 0), Quaternion.Euler(0, 0, 180));
        }
        else if (holder % 4 == 3)
        {
            PieceVisual[q][w] = Instantiate(pieceVisual, transform.position + new Vector3(x, y, 0), Quaternion.Euler(0, 0, 270));
        }

        PieceVisual[q][w].transform.SetParent(pieceParent.transform, true);
        PieceVisual[q][w].name = ("piece" + holder);


        renderer = PieceVisual[q][w].GetComponent<Renderer>();
        switch (q % 9) // Add more colors
        {
            case 8:
                renderer.material.color = Color.grey;
                break;
            case 7:
                renderer.material.color = Color.white;
                break;
            case 6:
                renderer.material.color = Color.yellow;
                break;
            case 5:
                renderer.material.color = Color.cyan;
                break;
            case 4:
                renderer.material.color = Color.black;
                break;
            case 3:
                renderer.material.color = Color.green;
                break;
            case 2:
                renderer.material.color = Color.blue;
                break;
            case 1:
                renderer.material.color = Color.red;
                break;
            default:
                renderer.material.color = Color.magenta;
                break;
        }
    }
    public void cleanVisuals()
    {
        PieceVisual.Clear();
        Parents.Clear();
        for (int i = 0; i < pieceCount; i++) { Destroy(GameObject.Find("Piece" + i)); Destroy(GameObject.Find("BoardPiece" + i)); }
    }
}
