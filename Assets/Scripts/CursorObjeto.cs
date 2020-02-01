using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorObjeto : MonoBehaviour
{
    public Texture2D CursorNormal;
    //public Texture2D CursorEnter;
    //public Texture2D CursorExit;

    void Start() {
        Cursor.SetCursor(CursorNormal, Vector2.zero, CursorMode.ForceSoftware);
    }
    /*
    void OnMouseEnter() {
        Cursor.SetCursor(CursorEnter, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit() {
        Cursor.SetCursor(CursorExit, Vector2.zero, CursorMode.ForceSoftware);
    }
    */
}
