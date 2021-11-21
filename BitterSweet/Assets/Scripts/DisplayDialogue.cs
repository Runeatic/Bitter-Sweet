using UnityEngine;

public class DisplayDialogue : MonoBehaviour
{
    public bool loadNextScene;
    public Conversation convo;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            DialogueManager.StartConversation(convo);
        }
    }
}
