using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine.SceneManagement;

public class VNSystem : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string characterName;
        [TextArea(3, 5)] public string dialogueText;
        public Sprite characterSprite;
        public CharacterPosition characterPosition;
        public bool flipCharacter;
    }

    public enum CharacterPosition { None, Left, Right }

    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
    private int currentLineIndex = 0;

    [Header("UI References")]
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image leftCharacterImage;
    public Image rightCharacterImage;
    public GameObject dialoguePanel;

    [Header("Settings")]
    public float textSpeed = 0.05f;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        InitializeDialogue();
        ShowDialogueLine(currentLineIndex);
    }

    void InitializeDialogue()
    {
        leftCharacterImage.preserveAspect = true;
        rightCharacterImage.preserveAspect = true;

        SetCharacterAlpha(leftCharacterImage, 0);
        SetCharacterAlpha(rightCharacterImage, 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                CompleteText();
            }
            else
            {
                currentLineIndex++;
                if (currentLineIndex < dialogueLines.Count)
                {
                    ShowDialogueLine(currentLineIndex);
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    void ShowDialogueLine(int index)
    {
        DialogueLine line = dialogueLines[index];

        nameText.text = line.characterName;

        dialogueText.text = "";

        UpdateCharacterDisplay(line);

        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeText(line.dialogueText));
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        dialogueText.maxVisibleCharacters = 0;
        dialogueText.text = text;

        for (int i = 0; i <= text.Length; i++)
        {
            dialogueText.maxVisibleCharacters = i;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void CompleteText()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.maxVisibleCharacters = dialogueText.textInfo.characterCount;
            isTyping = false;
        }
    }

    void UpdateCharacterDisplay(DialogueLine line)
    {
        ResetCharacter(leftCharacterImage);
        ResetCharacter(rightCharacterImage);

        switch (line.characterPosition)
        {
            case CharacterPosition.Left:
                SetCharacter(leftCharacterImage, line.characterSprite, line.flipCharacter);
                break;

            case CharacterPosition.Right:
                SetCharacter(rightCharacterImage, line.characterSprite, line.flipCharacter);
                break;
        }
    }

    void SetCharacter(Image characterImage, Sprite sprite, bool flip)
    {
        if (sprite != null)
        {
            characterImage.sprite = sprite;
            characterImage.rectTransform.localScale = new Vector3(flip ? -1 : 1, 1, 1);
            characterImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            characterImage.color = new Color(1, 1, 1, 0);
        }
    }

    void ResetCharacter(Image characterImage)
    {
        characterImage.color = new Color(1, 1, 1, 0);
    }

    void SetCharacterAlpha(Image image, float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        SceneManager.LoadScene("WinScene");
    }
}