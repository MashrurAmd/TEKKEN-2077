using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [Header("Vibration Button")]
    public Button toggleButton;   // The button component
    public Image buttonImage;     // The image shown on the button
    public Sprite onSprite;       // Sprite for ON
    public Sprite offSprite;      // Sprite for OFF

    private bool isOn = true; // Start state (true = ON, false = OFF)

    void Start()
    {
        // Set initial sprite
        buttonImage.sprite = onSprite;

        // Add listener to button
        toggleButton.onClick.AddListener(ToggleState);
    }

    void ToggleState()
    {
        isOn = !isOn;

        if (isOn)
        {
            buttonImage.sprite = onSprite;
        }
        else
        {
            buttonImage.sprite = offSprite;
        }
    }
}
