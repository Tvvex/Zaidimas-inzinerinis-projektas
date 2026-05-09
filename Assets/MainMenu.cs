using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;
    public SceneFader fader;
    public void Play()
    {
        fader.FadeAndLoad(sceneName, 1);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
