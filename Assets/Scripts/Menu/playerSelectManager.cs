using UnityEngine;
using UnityEngine.UI;
using TMPro;   // If you are using TextMeshPro (recommended)

public class PlayerSelectManager : MonoBehaviour
{
    [Header("Player Data")]
    public Sprite[] playerSprites;           // All full-size player images
    public string[] playerNames;             // Names for each player (must match sprite array length)

    [Header("UI References")]
    public Image selectedPlayerImage;        // Display selected player's sprite
    public TextMeshProUGUI playerNameText;   // Display selected player's name

    private int selectedIndex = 0;           // Start with 0th player

    void Start()
    {
        // Show first player by default
        if (playerSprites.Length > 0)
        {
            UpdatePlayerDisplay(0);
        }
    }

    public void SelectPlayer(int index)
    {
        if (index >= 0 && index < playerSprites.Length)
        {
            selectedIndex = index;
            UpdatePlayerDisplay(index);
        }
    }

    private void UpdatePlayerDisplay(int index)
    {
        // Update sprite
        selectedPlayerImage.sprite = playerSprites[index];

        // Update name if available
        if (index < playerNames.Length)
        {
            playerNameText.text = playerNames[index];
        }
        else
        {
            playerNameText.text = "Unknown";
        }
    }

    // Optional: Get selected player info
    public int GetSelectedPlayerIndex()
    {
        return selectedIndex;
    }
}
