using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour {
    
    public void createNPCInteractionScreen()
    {
        float outerBoxHeight =  Screen.height * 0.35f;
        float outerBoxWidth = Screen.width * 0.2f;
        float outerBoxLeft = outerBoxWidth;
        float outerBoxTop = (Screen.height - outerBoxHeight);

        float innerBoxHeight = outerBoxHeight * 0.9f;
        float innerBoxWidth = outerBoxWidth * 0.9f;
        float innerBoxLeft = (outerBoxWidth - innerBoxWidth) + outerBoxWidth;
        float innerBoxTop = outerBoxHeight - (outerBoxHeight - innerBoxHeight);

        Rect outerInteractBox = new Rect(outerBoxLeft, outerBoxTop, outerBoxWidth, outerBoxHeight);
        Rect innerInteractBox = new Rect(innerBoxLeft, innerBoxTop, innerBoxWidth, innerBoxHeight);
        
    }

}
