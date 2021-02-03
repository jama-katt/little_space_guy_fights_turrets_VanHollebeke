using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D cursorTex;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 startSpot = Vector2.zero;

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTex, startSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
