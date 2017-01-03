
public class Quest {

    private string questName;
    private string questAcceptText;
    private string questDescription;
    private string questCompleteText;

    //Accessors
    public string QuestName { get { return questName; } set { questName = value; } }
    public string QuestAcceptText { get { return questAcceptText; } set { questAcceptText = value; } }
    public string QuestDescription { get { return questDescription; } set { questDescription = value; } }
    public string QuestCompleteText { get { return questCompleteText; } set { questCompleteText = value; } }
}
