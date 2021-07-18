using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    CharacterController2D characterController;
    private Typewriter typewriterEffect;



    private void Start()
    {


            GameObject.Find("Slime").GetComponent<CharacterController2D>().enabled = false;
            typewriterEffect = GetComponent<Typewriter>();
            CloseDialogueBox();
            ShowDialogue(testDialogue);

    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue (DialogueObject dialogueObject)
    {
        foreach(string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueBox();
        GameObject.Find("Slime").GetComponent<CharacterController2D>().enabled = true;


    }
    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
