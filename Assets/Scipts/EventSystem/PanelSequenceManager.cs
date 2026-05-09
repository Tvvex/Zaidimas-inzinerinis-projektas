using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSequenceManager : MonoBehaviour
{
    public List<GameObject> panels;
    public List<GameObject> notActivePanels;
    public List<Image> buttonImages;
    public Sprite active;
    public Sprite passive;

    private int currentIndex = 0;

    void Start()
    {
        SetActive();
        ShowPanel(currentIndex);
        SetNonActive();
    }

    public void ShowPanel(int index)
    {
        if (panels.Count == 0) return;

        // apsauga
        if (index < 0 || index >= panels.Count) return;

        // iðjungiam visus
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        // ájungiam vienà
        panels[index].SetActive(true);

        currentIndex = index;
    }

    public void NextPanel()
    {
        SetPassive();
        if (currentIndex + 1 >= panels.Count) return;

        currentIndex++;
        SetActive();
        ShowPanel(currentIndex);
        SetNonActive();
    }

    public void IncreaseIndex()
    {
        if (currentIndex + 1 < panels.Count)
        {
            currentIndex++;
        }
    }

    public int GetIndex()
    {
        return currentIndex;
    }
    public void SetActive()
    {
        if (currentIndex + 1 >= panels.Count) return;
        buttonImages[currentIndex].sprite = active;
    }
    public void SetPassive()
    {
        buttonImages[currentIndex].sprite = passive;
    }
    public void SetNonActive()
    {
        // ijungiam visus
        foreach (var panel in notActivePanels)
        {
            panel.SetActive(true);
        }
        // ájungiam vienà
        notActivePanels[currentIndex].SetActive(false);
    }
}