using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] Sprite cursorSprite;

    public Texture2D cursor;
    public Texture2D cursorUpdate;
    private Vector2 cursorHotspot;

    private void Start()
    {
        SetImg();
        //SetSize();
    }
    void SetImg()
    {
        // if we want to center it, normal strategy game will have it like /1 /1
        cursorHotspot = new Vector2(cursor.width / 2, cursor.height / 2);
        UnityEngine.Cursor.SetCursor(cursor, cursorHotspot, CursorMode.ForceSoftware);
    }
    void SetSize()
    {
        cursor.width = cursor.width * 1;
        cursor.height = cursor.height * 1;
    }
}

