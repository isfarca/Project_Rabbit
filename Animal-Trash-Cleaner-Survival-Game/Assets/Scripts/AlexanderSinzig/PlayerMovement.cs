using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float sprintSpeedBonus = 0f;
    private CharacterMotorC cmotor;

    void Awake()
    {
        cmotor = GetComponent<CharacterMotorC>();
    }


    void Update()
    {

        if (Input.GetButton("Fire3"))
        {
            sprintSpeedBonus = 6f;
        }
        else
        {
            sprintSpeedBonus = 0f;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        transform.Rotate(0, x, 0);

        Vector3 forwardVector;

        //var z = Input.GetAxis("Vertical") * Time.deltaTime * (12.0f + sprintSpeedBonus);
        forwardVector = new Vector3(0, 0, Input.GetAxis("Vertical"));

        if (Input.GetAxis("Vertical") > 0)
        {
            float directionLength = forwardVector.magnitude;
            forwardVector = forwardVector / directionLength;

            
            directionLength = Mathf.Min(1, directionLength);

            
            directionLength = directionLength * directionLength;


            forwardVector = forwardVector * directionLength;
        }

        // Apply the direction to the CharacterMotor
        cmotor.inputMoveDirection = transform.rotation * forwardVector;



        //transform.Translate(0, 0, z);
    }
}
