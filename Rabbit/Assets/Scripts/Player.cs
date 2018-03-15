using UnityEngine;

public class Player : MonoBehaviour
{
    // Value types
    private float x, z;
    private float speed = 3f;
	
	// Update is called once per frame
	void Update()
    {
        // Player movement.
        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed; // Move right / left.
        z = Input.GetAxis("Vertical") * Time.deltaTime * speed; // Move forward / backward

        transform.Translate(x, 0, z);
    }
}
