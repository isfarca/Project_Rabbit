﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRabbitControl : MonoBehaviour
{
    //variables to for the stay-command
    private bool stay = false;
    private bool startRoaming = false;
    private int roamingMaxTime;
    private int roamingTimer;

    //variables for forceMove
    private bool forceMove = false;
    private int forceMoveMaxTime;
    private int forceMoveTimer;
    private int forceMoveMaxCD;
    private int forceMoveCD;

    //variables for POI
    private Vector3 pointOfInterest;
    private bool interesting = false;
    private bool veryInteresting = false;

    //variables for life/damage
    private int health;
    public Transform tombstone;


    private void Awake()
    {
        //set start values for the variables
        roamingMaxTime = 600;
        forceMoveMaxTime = 300;
        forceMoveMaxCD = 600;
        health = 10;

    }

	
	void Update () {
        
        //toggle stay-command for all BabyRabbits
        if (Input.GetButtonDown("Submit"))
        {
            if (!stay)
            {
                stay = true;
                roamingTimer = roamingMaxTime;
                startRoaming = false;
            } 
            else
            {
                stay = false;
            }
        }


        //force-move
        if (Input.GetButtonDown("Fire1"))
        {
            if (forceMoveCD <= 0)
            {
                forceMove = true;
                forceMoveCD = forceMoveMaxCD;
                forceMoveTimer = forceMoveMaxTime;
            }
            else
            {
                Debug.Log(forceMoveCD);
            }
        }

        //if the roamingTimer reaches 0, the babyRabbits will start looking for trash in a greater area
        if (roamingTimer > 0)
        {
            roamingTimer--;
        }
        else
        {
            startRoaming = true;
        }

        //if the forceMoveTimer reaches 0, the command ends
        if (forceMoveTimer > 0)
        {
            forceMoveTimer--;
        }
        else
        {
            forceMove = false;
        }

        //if the forceMoveTimer reaches 0, the command ends
        if (forceMoveCD > 0)
        {
            forceMoveCD--;
        }
        else
        {
            forceMove = false;
        }


    }

    /// <summary>
    /// save the position of the area entered and how interesting it is
    /// </summary>
    /// <param name="areaName"></param>
    /// <param name="centerPosition">the position of the trash</param>
    public void EnterArea (string areaName, Vector3 centerPosition)
    {
        pointOfInterest = centerPosition;

        if (areaName == "PuddleLureArea1")
        {
            interesting = true;
        }
        else if (areaName == "PuddleLureArea2")
        {
            veryInteresting = true;
        }
    }

    /// <summary>
    /// the exact opposite of the EnterArea-function
    /// </summary>
    /// <param name="areaName"></param>
    /// <param name="centerPosition"></param>
    public void LeaveArea(string areaName, Vector3 centerPosition)
    {
        pointOfInterest = default(Vector3);

        if (areaName == "PuddleLureArea1")
        {
            interesting = false;
        }
        else if (areaName == "PuddleLureArea2")
        {
            veryInteresting = false;
        }
    }

    public void TakeDamage()
    {
        if (health > 0)
        {
            health--;
        }

        if (health <= 0)
        {
            Instantiate(tombstone, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


    /// <summary>
    /// to get read-access to the private variables from outside this script
    /// </summary>
    
    public bool Stay
    {
        get { return stay; }
    }

    public Vector3 PointOfInterest
    {
        get { return pointOfInterest; }
    }

    public bool Interesting
    {
        get { return interesting; }
    }

    public bool VeryInteresting
    {
        get { return veryInteresting; }
    }

    public bool ForceMove
    {
        get { return forceMove; }
    }

    public bool StartRoaming
    {
        get { return startRoaming; }
    }

}
