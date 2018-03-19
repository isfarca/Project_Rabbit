using UnityEngine;

public class BabyRabbitMovement : MonoBehaviour
{
    
    public float speed = 6.0f;
    //variables to save own rigidbody, other ojects and other scripts
    public Transform target;
    public float followDistance = 3f;
    public float trashDistance = 0.5f;
    private Rigidbody babyRabbitRigidbody;
    private BabyRabbitControl babyRabbitControlScript;


    //find own ridigbody
    private void Awake()
    {
        babyRabbitRigidbody = GetComponent<Rigidbody>();
        babyRabbitControlScript = GetComponent<BabyRabbitControl>();
    }

    void Update()
    {
        //highest priority
        //follow player as usual
        if (babyRabbitControlScript.ForceMove)
        {
            //look at target
            if (target == null)
            {
                target = GameObject.Find("Player").transform;
            }
            MoveToPoint(target.position, followDistance);
        }
        else
        {
            //second highest priority
            //go to the veryInteresting pointOfInterest
            if (babyRabbitControlScript.VeryInteresting)
            {
                MoveToPoint(babyRabbitControlScript.PointOfInterest, trashDistance);
            }
            else
            {
                //standard babyRabbit-behaviour
                if (!babyRabbitControlScript.Stay)
                {
                    //look at target
                    if (target == null)
                    {
                        target = GameObject.Find("Player").transform;
                    }

                    MoveToPoint(target.position, followDistance);
                }
            } 

            //stay
            if (babyRabbitControlScript.Stay)
            {
                //turn to the interesting pointOfInterest
                //third highest priority
                if (babyRabbitControlScript.Interesting && babyRabbitControlScript.StartRoaming)
                {
                    MoveToPoint(babyRabbitControlScript.PointOfInterest, trashDistance);
                }
                else
                {
                    Stand();
                }
            }
        }
    }

    //all movements
    void MoveToPoint (Vector3 point, float minimumDistance)
    {
        //turn to the object
        transform.LookAt(point);

        if (Vector3.Distance(point, transform.position) >= minimumDistance)
        {
            //move forward
            babyRabbitRigidbody.velocity = transform.forward * speed;
        }
        else
        {
            Stand();
        }
    }

    //hold position
    void Stand()
    {
        babyRabbitRigidbody.velocity = Vector3.zero;
    }
}