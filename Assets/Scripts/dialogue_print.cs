using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogue_print : MonoBehaviour {
    public TextMeshProUGUI Text; //the text itself
    public float typingSpeed = 0.05f;
    public string[] dialogues;
    private int currentDialogueIndex = 0;
    private bool isPrinting = false;

    private void Start() {
        StartDialogue();
    }

    public void StartDialogue()
    {
        if (dialogues.Length > 0)
        {
            StartCoroutine(PrintDialogue());
        }
    }

    private IEnumerator PrintDialogue()
    {
        isPrinting = true;
        Text.text = ""; // Clear the current text
        foreach (char c in dialogues[currentDialogueIndex])
        {
            Text.text += c; // Add the next character
            yield return new WaitForSeconds(typingSpeed); // Wait for the typing speed
        }
        isPrinting = false;

        // Automatically move to the next dialogue after a pause (optional)
        yield return new WaitForSeconds(2f); // Pause before continuing
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        if (!isPrinting && currentDialogueIndex < dialogues.Length - 1)
        {
            currentDialogueIndex++;
            StartCoroutine(PrintDialogue());
        }
    }
}



