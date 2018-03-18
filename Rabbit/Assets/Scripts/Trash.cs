using UnityEngine;

public class Trash : MonoBehaviour
{
    // Value types
    private bool collisionWithPlayer = false;
    public bool throwTrash;
    public float minThrowFar;
    public float maxThrowFar;

    // Reference types
    private Rigidbody trashRigidbody;
    private GameObject playerGameObject;

    /// <summary>
    /// Get components from the current scene.
    /// </summary>
    private void Awake()
    {
        // Get rigidbody from the current trash.
        trashRigidbody = GetComponent<Rigidbody>();

        // Find the asset from player in the current scene.
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Use this for initialization
    void Start()
    {
        // Throw trash.
        if (throwTrash)
        {
            trashRigidbody.AddForce(-Vector3.right * Random.Range(minThrowFar, maxThrowFar));
            trashRigidbody.useGravity = true;

            Debug.Log("Trash throwed!");
        }
    }

    /// <summary>
    /// By collision with player, set the variable true;
    /// </summary>
    /// <param name="collision">Was effected by.</param>
    private void OnCollisionEnter(Collision collision)
    {
        collisionWithPlayer = collision.collider.CompareTag("Player") ? true : false;
    }

    /// <summary>
    /// By exit collision from player, set the variable false. 
    /// </summary>
    /// <param name="collision">Was effected by.</param>
    private void OnCollisionExit(Collision collision)
    {
        collisionWithPlayer = collision.collider.CompareTag("Player") ? false : true;
    }

    /// <summary>
    /// By collision, show what the player can do.
    /// </summary>
    private void OnGUI()
    {
        // Declare variables
        Vector3 playerPosition;
        GUIStyle style = new GUIStyle();
        Font font;

        if (collisionWithPlayer)
        {
            // Set the position from player.
            playerPosition = Camera.main.WorldToScreenPoint(playerGameObject.transform.position);

            // Set font for heading and button.
            font = (Font)Resources.Load("Fonts/Screen", typeof(Font));

            style.font = font;
            // Set font size for heading.
            style.fontSize = 20;

            // Heading.
            GUI.Label(new Rect(playerPosition.x - 130, Screen.height - playerPosition.y + 50, 100, 50), "Press 'E' to get garbage", style);
        }
    }
}
