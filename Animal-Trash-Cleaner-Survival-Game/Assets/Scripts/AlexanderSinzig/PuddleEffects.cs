using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleEffects : MonoBehaviour {

    private Vector3 puddlePosition;
    private string objectName;
    private GameObject collidingBaby;
    private BabyRabbitControl babyRabbitControlScript;
    private Transform child;

    private int damageIntervall;
    private int intervallCounter;


    void Awake () {
        damageIntervall = 90;
        intervallCounter = damageIntervall;

        objectName = gameObject.name;
        //puddle-area saves its position wich equals the puddle-position
        if (objectName != "Puddle")
        {
            child = this.gameObject.transform.GetChild(0);
            puddlePosition = child.position;
        }
	}

    private void OnTriggerEnter (Collider other)
    {
        //only if a RabbitBaby enters the area
        if (other.gameObject.tag == "BabyRabbit")
        {
            //get acess to the script of the colliding RabbitBaby
            collidingBaby = other.gameObject;
            babyRabbitControlScript = collidingBaby.GetComponent<BabyRabbitControl>();
            //send position of the puddle
            if (puddlePosition != new Vector3(0f, 0f, 0f))
            {
                babyRabbitControlScript.EnterArea(objectName, puddlePosition);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //only if a RabbitBaby leaves the area
        if (other.gameObject.tag == "BabyRabbit")
        {
            //get acess to the script of the colliding RabbitBaby
            collidingBaby = other.gameObject;
            babyRabbitControlScript = collidingBaby.GetComponent<BabyRabbitControl>();
            //send position of the puddle
            if (puddlePosition != new Vector3(0f, 0f, 0f))
            {
                babyRabbitControlScript.LeaveArea(objectName, puddlePosition);
            }
        }
    }

    /// <summary>
    /// The puddle deals damage to all BabyRabbits inside the trigger zone, in an intervall
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (objectName == "Puddle")
        {
            if (other.gameObject.tag == "BabyRabbit")
            {
                //get acess to the script of the colliding RabbitBaby
                collidingBaby = other.gameObject;
                babyRabbitControlScript = collidingBaby.GetComponent<BabyRabbitControl>();

                //count down or dmage the BabyRabbit
                if (intervallCounter > 0)
                {
                    intervallCounter--;
                }
                else
                {
                    intervallCounter = damageIntervall;
                    babyRabbitControlScript.TakeDamage();
                }
            }
        }
    }
}
