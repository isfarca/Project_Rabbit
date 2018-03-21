using UnityEngine;

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
                else if (other.CompareTag("Electric"))
                {
                    electricTrash++;
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
            else if (other.CompareTag("ElectricTent"))
                KillTrashes(ref electricTrash, ref backpack);
        }
    }

    private void OnGUI()
    {
        // Declare variables
        int paperTrash = 0, plasticTrash = 0, restTrash = 0;
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

        // Count the number of trash-kind.
        /*for (int i = 0; i < backpack.Length; i++)
        {
            if (backpack[i] != null)
            {
                if (backpack[i].tag == "Paper")
                    paperTrash++;
                else if (backpack[i].tag == "Plastic")
                    plasticTrash++;
                else if (backpack[i].tag == "Rest")
                    restTrash++;
            }
        }*/

        // Heading.
        GUI.Label(new Rect(playerPosition.x / 16, Screen.height - playerPosition.y + 50, 20, 10), "Paper: " + paperTrash, style);
        GUI.Label(new Rect(playerPosition.x / 16, Screen.height - playerPosition.y + 70, 20, 10), "Plastic: " + plasticTrash, style);
        GUI.Label(new Rect(playerPosition.x / 16, Screen.height - playerPosition.y + 90, 20, 10), "Rest: " + restTrash, style);

        // Reset the number of trash-kinds.
        paperTrash = 0;
        plasticTrash = 0;
        restTrash = 0;
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
