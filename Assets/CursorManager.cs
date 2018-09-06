﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {
    public Texture2D cursorTexture;
    private Vector2 hotspot=Vector2.zero;
 private void Start()
    {
        Cursor.SetCursor(cursorTexture,hotspot,CursorMode.Auto);    
    }

	
}
