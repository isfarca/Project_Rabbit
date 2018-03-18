using UnityEngine;

public class Options : MonoBehaviour
{
    // Value types
    private float currentSliderValue = 0f;
    private float minSliderValue = 0f;
    private float maxSliderValue = 1f;

    // Reference types
    public Texture2D backButton;

    /// <summary>
    /// Output the options.
    /// </summary>
    private void OnGUI()
    {
        // Declare variables
        GUIStyle style = new GUIStyle();
        Font font;

        // Set font.
<<<<<<< HEAD
        font = (Font)Resources.Load("Fonts/Screen", typeof(Font));
=======
        font = (Font)Resources.Load("Fonts/Screens", typeof(Font));
>>>>>>> 4d9dedd00d7d74f8db1b0e091613354b2cbd371e

        style.font = font;
        // Set font for heading.
        style.fontSize = 50;

        // Heading.
        GUI.Label(new Rect((Screen.width / 2 - 420), (Screen.height / 2 - 250), 300, 100), "Options", style);

        // Set font size for settings.
        style.fontSize = 20;

        // Settings.
        GUI.Label(new Rect((Screen.width / 2 - 420), (Screen.height / 2 - 120), 200, 20), "Volume", style);
        GUI.HorizontalSlider(new Rect((Screen.width / 2 - 320), (Screen.height / 2 - 115), 200, 20), currentSliderValue, minSliderValue, maxSliderValue);
        AudioListener.volume = currentSliderValue;

        // Back button.
        if (GUI.Button(new Rect((Screen.width / 2 - 420), (Screen.height / 2 + 50), 50, 50), backButton, style))
            Debug.Log("Back");
    }
}
