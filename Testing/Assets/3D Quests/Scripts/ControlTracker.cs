using UnityEngine;
using System.Collections;

public class ControlTracker : MonoBehaviour {

    private KeyCode interact = KeyCode.F;

    //Accessor Methods
    public KeyCode Interact { get { return interact; } set { interact = value; } }

}
