using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityBody : MonoBehaviour {

    public PlanetScript attractorPlanet;
    private Transform playerTransform;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    void FixedUpdate()
    {
        if (attractorPlanet)
        {
            attractorPlanet.Attract(playerTransform);
        }
    }
}
