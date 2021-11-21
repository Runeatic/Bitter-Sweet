using UnityEngine;

public class Test : MonoBehaviour
{
    public Conversation convo;
    public void StartConvo()
    {
        DialogueManager.StartConversation(convo);
    }
}
