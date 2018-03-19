using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float sprintSpeed = 0f;

    void Update()
    {
        if (Input.GetButton("Fire3"))
        {
            sprintSpeed = 6f;
        }
        else
        {
            sprintSpeed = 0f;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * (12.0f + sprintSpeed);


        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
