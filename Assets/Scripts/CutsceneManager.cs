using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] 
    private GameObject storyImage;
    [SerializeField] 
    private TextMeshProUGUI storyText;
    [SerializeField] 
    private GameObject continueButton;
    [SerializeField] 
    private CanvasGroup canvasGroup;

    [Header("Settings")]
    [TextArea(5, 10)]
    [SerializeField] 
    private string storyContent;
    [SerializeField] 
    private float textSpeed = 0.05f;
    [SerializeField] 
    private float fadeDuration = 1f;

    private bool textRevealComplete = false;

    [Header("Text Background")]
    public Image textBackgroundPanel;

    void Start()
    {
        storyText.gameObject.SetActive(false);
        continueButton.SetActive(false);

        StartCoroutine(FadeIn());

        if (textBackgroundPanel != null)
        {
            Color bgColor = textBackgroundPanel.color;
            bgColor.a = 0f;
            textBackgroundPanel.color = bgColor;
            textBackgroundPanel.gameObject.SetActive(false);
        }
    }

    private IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0;

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)
           || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            HandleScreenTap();
        }
    }

    private void HandleScreenTap()
    {
        if (!storyText.gameObject.activeSelf)
        {
            ShowStoryText();
        }

        else if (!textRevealComplete)
        {
            textRevealComplete = true;
            StopAllCoroutines();
            storyText.text = storyContent;
            continueButton.SetActive(true);
        }
    }

    private void ShowStoryText()
    {
        if (textBackgroundPanel != null)
        {
            textBackgroundPanel.gameObject.SetActive(true);
            StartCoroutine(FadeInTextBackground());
        }

        storyText.gameObject.SetActive(true);
        StartCoroutine(RevealText());
    }

    private IEnumerator FadeInTextBackground()
    {
        float duration = 0.5f;
        float timer = 0f;
        Color bgColor = textBackgroundPanel.color;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            bgColor.a = Mathf.Lerp(0f, 0.7f, timer / duration);
            textBackgroundPanel.color = bgColor;
            yield return null;
        }
        bgColor.a = 0.7f;
        textBackgroundPanel.color = bgColor;
    }

    private IEnumerator RevealText()
    {
        storyText.text = "";
        textRevealComplete = false;

        for (int i = 0; i < storyContent.Length; i++)
        {
            if (textRevealComplete) break;

            storyText.text += storyContent[i];
            yield return new WaitForSeconds(textSpeed);
        }

        textRevealComplete = true;
        continueButton.SetActive(true);
    }

    public void LoadNextScene()
    {
        StartCoroutine(TransitionToNextLevel());
    }

    private IEnumerator TransitionToNextLevel()
    {
        if (textBackgroundPanel != null)
        {
            float timer = 0f;
            Color bgColor = textBackgroundPanel.color;

            while (timer < fadeDuration / 2)
            {
                timer += Time.deltaTime;
                bgColor.a = Mathf.Lerp(0.7f, 0f, timer / (fadeDuration / 2));
                textBackgroundPanel.color = bgColor;
                yield return null;
            }
        }

        float sceneTimer = 0f;
        while (sceneTimer < fadeDuration)
        {
            sceneTimer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, sceneTimer / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene("Level2");
    }
}
