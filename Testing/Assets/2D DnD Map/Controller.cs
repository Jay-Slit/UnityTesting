using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    private int height;
    private int width;
    [SerializeField]
    private InputField inputHeight;
    [SerializeField]
    private InputField inputWidth;

    GridSquare gridSquare;

    List<GridSquare> grid;

    public Canvas canvas;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GenerateWorkArea() {

        //Get the height and width from user input
        height = int.Parse(inputHeight.text);
        width = int.Parse(inputWidth.text);

        //Define boundaries for WorkSpace
        int xStart = 0 - (width / 2);
        int yStart = 0 - (height / 2);
        int xEnd = width / 2;
        int yEnd = height / 2;



    }
}
