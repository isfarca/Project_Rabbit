using UnityEngine;

public class Player : MonoBehaviour
{
    // Value types
    private int slots = 10;

    // Reference types
    private GameObject[] backpack;
    public GameObject[] trashes;

    /// <summary>
    /// Initialize variables and get scripts.
    /// </summary>
    private void Awake()
    {
        // Initialize the length from array.
        backpack = new GameObject[slots * 5];
    }

    /// <summary>
    /// By trigger with campsite and press button 'Q', than lay down the trashes. 
    /// </summary>
    /// <param name="other">Was effected by.</param>
    private void OnTriggerStay(Collider other)
    {
        // Declare variables
        int numberOfGarbage = 0;

        // ---------- Get the trash. ----------
        if (Input.GetAxisRaw("Fire2") > 0)
        {
            // Add garbage in backpack.
            for (int i = 0; i < backpack.Length - 1; i++)
            {
                if (backpack[i] == null)
                {
                    backpack[i] = other.gameObject;
                    other.gameObject.SetActive(false);

                    Debug.LogFormat("Index: {0} | Garbage added in your backpack!", i);

                    break;
                }
            }

            // Check, if the backpack is full.
            for (int i = 0; i < backpack.Length; i++)
            {
                if (backpack[i] != null)
                    numberOfGarbage++;
                else if (backpack[i] == null)
                    break;
            }

            if (numberOfGarbage == backpack.Length - 1)
                Debug.Log("You have too much trash in your backpack!");
        }

        // ---------- Lay down the trash. ----------
        if (Input.GetAxisRaw("Fire2") < 0)
        {
            for (int i = 0; i < backpack.Length; i++)
            {
                if (backpack[i] != null)
                {
                    if (backpack[i].tag == other.tag)
                    {
                        backpack[i].SetActive(true);
                        backpack[i].transform.GetChild(0).gameObject.SetActive(true);
                        Debug.Log("Activated!");
                        backpack[i].transform.position = new Vector3
                        (
                            other.transform.position.x + Random.Range(-5f, 5f),
                            other.transform.position.y,
                            other.transform.position.z + Random.Range(-5f, 5f)
                        );
                        Debug.LogFormat("Garbage '{0}' filed!", backpack[i].tag);
                        backpack[i] = null;
                    }
                }
            }
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
        for (int i = 0; i < backpack.Length; i++)
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
        }

        // Heading.
        GUI.Label(new Rect(playerPosition.x / 16, Screen.height - playerPosition.y + 50, 20, 10), "Paper: " + paperTrash, style);
        GUI.Label(new Rect(playerPosition.x / 16, Screen.height - playerPosition.y + 70, 20, 10), "Plastic: " + plasticTrash, style);
        GUI.Label(new Rect(playerPosition.x / 16, Screen.height - playerPosition.y + 90, 20, 10), "Rest: " + restTrash, style);

        // Reset the number of trash-kinds.
        paperTrash = 0;
        plasticTrash = 0;
        restTrash = 0;
    }
}
