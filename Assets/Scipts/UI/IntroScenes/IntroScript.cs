using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.Playables;
public class IntroScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public Image[] images;
    public float textSpeed;
    private int index;
    public string sceneName;
    private InputAction ClickAction;
    public PlayableDirector timeline;
    public SceneFader fader;
    public float changeTime;
    void Start()
    {
        textComponent.text = string.Empty;
        StartText();
        ClickAction = InputSystem.actions.FindAction("Click");
    }
    public void SwitchScene(string sceneName)
    {
        fader.FadeAndLoad(sceneName, 1);
    }
    private void Update()
    {
        if (ClickAction.WasPressedThisFrame())
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartText()
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
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            images[index].gameObject.SetActive(false);
            index++;
            images[index].gameObject.SetActive(true);
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            timeline.Play();
        }
    }
}
