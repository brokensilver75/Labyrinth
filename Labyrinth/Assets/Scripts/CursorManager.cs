using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D crossHair;
    Vector2 cursorHotspot;
    // Start is called before the first frame update
    void Start()
    {
        cursorHotspot = new Vector2(crossHair.width / 2, crossHair.height / 2);
        Cursor.SetCursor (crossHair, cursorHotspot, CursorMode.Auto);
    }
}
