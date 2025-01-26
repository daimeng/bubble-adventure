using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class dialogue_print : MonoBehaviour {

    public TextMeshProUGUI Text; //this is TMP
    public float typingSpeed = 0.05f;
    public string[] dialogues;
    private int currentDialogueIndex = 0;
    private bool isPrinting = false;

    public Animator BlackFade;
    //public string next scene

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
        else if (!isPrinting && currentDialogueIndex == dialogues.Length - 1)
        {
            // Trigger fade animation and exit the scene
            StartCoroutine(FadeAndExit());
        }
    }

    private IEnumerator FadeAndExit()
    {
        // Trigger the fade animation
        BlackFade.SetTrigger("FadeOut");

        // Wait for the animation to finish (assuming 1 second fade duration)
        yield return new WaitForSeconds(1f);
        var scene = SceneManager.GetActiveScene().name;
        Debug.Log($"scene name: {scene}");
        if (scene == "Ending")
        {
            SceneManager.LoadScene("Title");
            yield break;
        }
        else if (scene == "Opening")
        {
            SceneManager.LoadScene("Test");
            yield break;
        }

        switch (scene[scene.Length - 1])
        {
            case '1':
                SceneManager.LoadScene("Level2");
                break;
            case '2':
                SceneManager.LoadScene("level3");
                break;
            default:
                Debug.LogError("WTF");
                break;
        }

    }
}



