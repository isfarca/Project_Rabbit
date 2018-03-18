using UnityEngine;

public class Player : MonoBehaviour
{
    // Value types
    private float x, z;
    private float speed = 3f;
<<<<<<< HEAD
    private int slots = 10;

    // Reference types
    private GameObject[] backpack;

    /// <summary>
    /// Initialize variables and get scripts.
    /// </summary>
    private void Awake()
    {
        // Initialize the length from array.
        backpack = new GameObject[slots];
    }

    // Update is called once per frame
    void Update()
=======
	
	// Update is called once per frame
	void Update()
>>>>>>> 4d9dedd00d7d74f8db1b0e091613354b2cbd371e
    {
        // Player movement.
        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed; // Move right / left.
        z = Input.GetAxis("Vertical") * Time.deltaTime * speed; // Move forward / backward

        transform.Translate(x, 0, z);
    }

    /// <summary>
    /// By collision with trash and press button 'E', than get the trash.
    /// </summary>
    /// <param name="collision">Was effected by.</param>
    private void OnCollisionStay(Collision collision)
    {
        // Declare variables
        int numberOfGarbage = 0;

        // Press button 'E'.
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            // Add garbage in backpack.
            for (int i = 0; i < backpack.Length - 1; i++)
            {
                if (backpack[i] == null)
                {
                    backpack[i] = collision.gameObject;
                    collision.gameObject.SetActive(false);

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
    }

    /// <summary>
    /// By trigger with campsite and press button 'Q', than lay down the trashes. 
    /// </summary>
    /// <param name="other">Was effected by.</param>
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetAxisRaw("Fire2") > 0)
        {
            for (int i = 0; i < backpack.Length; i++)
            {
                if (backpack[i] != null)
                {
                    if (backpack[i].tag == other.tag)
                    {
                        backpack[i].transform.position = other.transform.position;
                        Debug.LogFormat("Garbage '{0}' filed!", backpack[i].tag);
                        backpack[i] = null;

                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Get or Set the trashes.
    /// </summary>
    public GameObject[] Backpack
    {
        get { return backpack; }
        set { backpack = value; }
    }
}
