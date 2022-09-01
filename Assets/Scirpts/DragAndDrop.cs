using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    private bool dragOn = false;
    private Vector2 offset;

    void Update()
    {
        if (dragOn)
        {
            Vector2 mouseP = GetMousePoisiton();

            transform.parent.position = mouseP - offset; //add transform.parent.position 
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            dragOn = true;
            offset = GetMousePoisiton() - (Vector2)transform.parent.position; //add transform.parent.position 
        }
    }

    private Vector2 GetMousePoisiton()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        GameObject boardObject;
        dragOn = false;
        boardObject = GetBoardObject();

        if (Mathf.Abs(transform.position.x - boardObject.transform.position.x) <= 0.5f && Mathf.Abs(transform.position.y - boardObject.transform.position.y) <= 0.5f)
        {
            Debug.Log("dropble position");
            transform.parent.position = new Vector3(boardObject.transform.parent.position.x - 6, boardObject.transform.parent.position.y, boardObject.transform.parent.position.z);
        }

    }

    private GameObject GetBoardObject()
    {
        GameObject boardObject;
        string nameHolder = transform.name;
        char lastCharacter = nameHolder[nameHolder.Length - 1];
        char secondLastCharacter = nameHolder[nameHolder.Length - 2];
        if (Char.IsNumber(secondLastCharacter))
        {
            Debug.Log("Holding " + secondLastCharacter + lastCharacter);
            boardObject = GameObject.Find("boardPiece" + secondLastCharacter + lastCharacter);
        }
        else
        {
            Debug.Log("Holding " + lastCharacter);
            boardObject = GameObject.Find("boardPiece" + lastCharacter);
        }

        return boardObject;
    }
}
