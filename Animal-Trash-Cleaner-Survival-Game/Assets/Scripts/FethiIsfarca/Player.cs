using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    // Value types
    private int backpack;
    private int paperTrash, plasticTrash, electricTrash;
    private bool getTrash, setTrash;

    /// <summary>
    /// By trigger with campsite and press button 'Q', than lay down the trashes. 
    /// </summary>
    /// <param name="other">Was effected by.</param>
    private void OnTriggerStay(Collider other)
    {
        // ---------- Get the trash (Destroy). ----------
        if (Input.GetAxisRaw("Fire2") > 0)
        {
            // Have you a place in your backpack?
            if (backpack < 10)
            {
                // Is a getable trash?
                if (other.CompareTag("Paper"))
                {
                    paperTrash++;
                    Debug.Log("You get the trash!");
                    Destroy(other.gameObject);
                    backpack++;
                }
                else if (other.CompareTag("Plastic"))
                {
                    plasticTrash++;
                    Debug.Log("You get the trash!");
                    Destroy(other.gameObject);
                    backpack++;
                }
            }
            else
                Debug.Log("You have too much trash in your backpack!");
        }

        // ---------- Lay down the trash. ----------
        if (Input.GetAxisRaw("Fire2") < 0)
        {
            // Is a setable trash?
            if (other.CompareTag("PaperTent"))
                KillTrashes(ref paperTrash, ref backpack);
            else if (other.CompareTag("PlasticTent"))
                KillTrashes(ref plasticTrash, ref backpack);
        }
    }

    private void OnGUI()
    {
        // Declare variables
        Vector3 playerPosition;
        GUIStyle style = new GUIStyle();
        Font font;

        // Set the position from player.
        playerPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Set font for heading and button.
        font = (Font)Resources.Load("Fonts/Screen", typeof(Font));

        style.font = font;
        // Set font size for heading.
        style.fontSize = 10;

        EditorGUI.ProgressBar(new Rect(playerPosition.x + 100, playerPosition.y / 1.25f, 20, 100), 100f, "");
    }

    /// <summary>
    /// Kill trashes from backpack.
    /// </summary>
    /// <param name="trash">Number of trash-kind.</param>
    /// <param name="backpack">Number of trashes in backpack.</param>
    void KillTrashes(ref int trash, ref int backpack)
    {
        // When have a trash, than reduce the backpack.
        if (trash > 0)
        {
            for (int i = 0; i < trash; i++)
                backpack--;

            trash = 0;
        }
    }
}
