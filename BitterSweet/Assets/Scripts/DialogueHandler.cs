using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public MenuManager menuManager; 
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public AudioSource dialogueSFX;
    
    void Start()
    {
        textComponent.text = string.Empty;
        menuManager.GetComponent<MenuManager>();
    }
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if (textComponent.text == lines[index])
            {
                dialogueSFX.Stop();
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

        private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            menuManager.showDialogue();
            StartDialogue();
            Debug.Log("Bonk");
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            dialogueSFX.Play();
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
           index++;
           textComponent.text = string.Empty;
           StartCoroutine(TypeLine()); 
           dialogueSFX.Play();
        }
        else
        {
            menuManager.hideDialogue();
        }
    }

}