using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialogue, navButtonText;
    public Image speakerSprite;
    public float textSpeed;
    public AudioSource dialogueSFX;

    private int currentIndex;
    private Conversation currentConvo;
    public static DialogueManager instance;
    private Animator anim;
    private Coroutine typing;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void StartConversation(Conversation convo)
    {
        instance.anim.SetBool("isOpen", true);
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.dialogue.text = "";
        instance.navButtonText.text = ">";

        instance.readNext();
    }

    public void readNext()
    {
        if(currentIndex > currentConvo.GetLength())
        {
            dialogueSFX.Stop();
            instance.anim.SetBool("isOpen", false);
            return;
        }
        speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();

        if (typing == null)
        {
            typing = instance.StartCoroutine(TypeLine(currentConvo.GetLineByIndex(currentIndex).dialogue));
        }
        else
        {
            instance.StopCoroutine(typing);
            typing = null;
            typing = instance.StartCoroutine(TypeLine(currentConvo.GetLineByIndex(currentIndex).dialogue));
        }

        speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();
        dialogueSFX.Stop();
        currentIndex++;

        if(currentIndex >= currentConvo.GetLength() +1)
        {
            navButtonText.text = "X";
        }
    }

    private IEnumerator TypeLine(string text)
    {
        dialogue.text = "";
        bool complete = false;
        int index = 0;

        while (!complete)
        {
            dialogue.text += text[index];
            index++;
            dialogueSFX.Play();
            yield return new WaitForSeconds(textSpeed);
            dialogueSFX.Stop();

            if (index == text.Length)
            {
                complete = true;
            }
        }

        typing = null;

    }
}
