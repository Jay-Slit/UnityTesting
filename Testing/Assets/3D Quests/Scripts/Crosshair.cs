using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    [SerializeField]
    private Texture2D crosshairImage;

    Rect cursorRect;

    //Color array to store the original colors for the crosshairImage to revert on quit
    //TODO: Change Crosshair System
    Color[,] originalColors;

    // Use this for initialization
    void Start()
    {
        //Define color array size
        originalColors = new Color[crosshairImage.width, crosshairImage.height];

        //Lock cursor to center
        Cursor.lockState = CursorLockMode.Locked;
        saveOriginalTexture(crosshairImage);
        //TODO: Relocate to a crosshair edit screen
        changeCrosshairColor(Color.blue, crosshairImage);
    }

    void OnGUI()
    {
        //Update cursor image to match mouse
        cursorRect = new Rect(Input.mousePosition.x - (crosshairImage.width / 2),
                               Screen.height - Input.mousePosition.y - (crosshairImage.height / 2),
                               crosshairImage.width, crosshairImage.height);

        //Draw the cursor on the screen
        GUI.DrawTexture(cursorRect, crosshairImage);

    }

    void OnApplicationQuit()
    {
        //Revert cursor image back to original colors
        applyOriginalTexture(crosshairImage);
    }

    void saveOriginalTexture(Texture2D texture)
    {
        //Nested loop to access every pixel in texture
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color newColor = texture.GetPixel(x, y);
                //Save pixel color into array
                originalColors[x, y] = newColor;
            }
        }
    }

    void applyOriginalTexture(Texture2D texture)
    {
        //Nested loop to access every pixel in texture
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color newColor = originalColors[x, y];
                //Set pixel color to original color
                texture.SetPixel(x, y, newColor);
            }
        }
        //Update DrawInfo
        texture.Apply();
    }

    void changeCrosshairColor(Color color, Texture2D texture)
    {
        //Nested loop to access every pixel in texture
        for(int y = 0; y < texture.height; y++)
        {
            for(int x = 0; x < texture.width; x++)
            {
                //Check if current pixel is transparent
                if (texture.GetPixel(x,y) != new Color(1,1,1,0))
                {
                    texture.SetPixel(x, y, color);
                }
                else
                {
                    texture.SetPixel(x, y, Color.clear);
                }
            }
        }
        //Update DrawInfo
        texture.Apply();
    }
}
