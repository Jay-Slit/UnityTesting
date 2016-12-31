using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {

    public int mapHeight;
    public int mapWidth;

    public GridSquare gridSquare;

    public List<GridSquare> gridSquares = new List<GridSquare>();

	// Use this for initialization
	void Start () {
        generateMap();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void generateMap()
    {
        int xStart = 0 - (mapWidth / 2);
        int xEnd = mapWidth / 2;
        int yStart = 0 - (mapHeight / 2);
        int yEnd = mapHeight / 2;

        for (int i = yStart; i < yEnd; i++)
        {
            for (int j = xStart; j < xEnd; j++)
            {
                GridSquare square = Instantiate(gridSquare, new Vector2(i, j), this.transform.rotation) as GridSquare;
                square.transform.SetParent(transform, false);
                gridSquares.Add(square);
            }
        }
    }
}
