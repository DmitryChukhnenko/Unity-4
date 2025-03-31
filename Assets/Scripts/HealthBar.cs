using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float maxValue = 100;
    public Color color = Color.red;
    public int width = 4;
    public Slider slider;
    public bool isRight; 

    public static float current;

    // Start is called before the first frame update
    void Start()
    {
        slider.fillRect.GetComponent<Image>().color = color;
        slider.maxValue = maxValue;
        slider.minValue = 0;
        current = maxValue;

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (current < 0) current = 0;
        if (current > maxValue) current = maxValue;
        slider.value = current;
    }

    void UpdateUI() {
        RectTransform rect = slider.GetComponent<RectTransform> ();
        int rectDeltaX=Screen.width / width;
        float rectPosX = rect.position.x + (rectDeltaX-rect.sizeDelta.x)/2;
        if (isRight) {
            slider.direction = Slider.Direction.RightToLeft;
        }
        else {
            slider.direction = Slider.Direction.LeftToRight;
        }
        rect.sizeDelta = new Vector2(rectDeltaX, rect.sizeDelta.y);
        rect.position = new Vector3(rectPosX, rect.position.y, rect.position.z);
    }

    public static void AdjustCurrentValue (float adjust) {
        current += adjust;
    }

    public static float currentValue {
        get {return current;}
    }
}
