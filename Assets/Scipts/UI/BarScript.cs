using UnityEngine;

public class Bar : MonoBehaviour
{
    public RectTransform fillBar;

    public float value = 50;
    public float maxValue = 100;
    public float maxWidth = 200;

    void Update()
    {
        float width = maxWidth * (value / maxValue);
        fillBar.sizeDelta = new Vector2(width, fillBar.sizeDelta.y);
    }
}

