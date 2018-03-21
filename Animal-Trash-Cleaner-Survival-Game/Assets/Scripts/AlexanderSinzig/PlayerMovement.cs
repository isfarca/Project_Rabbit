using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool sprintEnable = false;
    private float sprintSpeedBonus = 0.5f;
    private CharacterMotorC cmotor;
    public float speed;
    private Vector3 forwardVector;


    //animator is integrated in movementScript to optimize synchrinisation
    private Transform rabbitBody;
    private Animator animator;


    void Awake()
    {
        cmotor = GetComponent<CharacterMotorC>();
        speed = 1.0f;
        rabbitBody = gameObject.transform.GetChild(0);
        animator = rabbitBody.GetComponent<Animator>();
    }


    void Update()
    {

        //movement animator information
        animator.SetFloat("InputForward", Input.GetAxisRaw("Vertical"));
        animator.SetFloat("InputSides", Input.GetAxisRaw("Horizontal"));
        //grabing animator information
        animator.SetBool("Grab", Input.GetButton("Fire2"));
        //removed
        //animator.SetBool("Jump", Input.GetButton("Jump"));

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        transform.Rotate(0, x, 0);


        //vector length alters if player sprints, or walks 
        //sprint gets enabled/disabled in BabyRabbitMovement script
        if (Input.GetButton("Fire3") && sprintEnable)
        {
            //sprint (only possible if babyrabbits dont follow)
            forwardVector = new Vector3(0, 0, Input.GetAxis("Vertical") * (speed + sprintSpeedBonus));
            //sprint animator information
            animator.SetBool("Sprint", true);
        }
        else
        {
            forwardVector = new Vector3(0, 0, Input.GetAxis("Vertical") * speed);
            //sprint animator information
            animator.SetBool("Sprint", false);
        }

        // use characterMotor to move
        cmotor.inputMoveDirection = transform.rotation * forwardVector;
    }
}
