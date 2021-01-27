using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterScript : MonoBehaviour
{

    public float boosterStrength = 200f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay()
    {
        player.GetComponent<Rigidbody>().AddForce(player.GetComponent<PlayerMovementScript>().planetToPlayerRay * boosterStrength);
    }
}
