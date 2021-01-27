using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public GameObject planet;
    public GameObject camera;
    public float jumpStrength = 100f;

    public Vector3 moveDirection;
    public Vector3 planetToPlayerRay;

    void Update()
    {
        Move();
        Jump();
    }

    void FixedUpdate()
    {
        MovePlayer();
        
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        planetToPlayerRay = (new Vector3(transform.position.x - planet.transform.position.x, transform.position.y - planet.transform.position.y, transform.position.z - planet.transform.position.z).normalized);
        Vector3 playerLookDirection = (camera.transform.forward).normalized;
        
        Vector3 forwardDirection = Vector3.ProjectOnPlane(playerLookDirection, planetToPlayerRay).normalized;
     
        // Debug.Log(planetToPlayerRay + " " + playerLookDirection + " " + forwardDirection);

        Vector3 verticalMoveDirection = forwardDirection * verticalInput;
        Vector3 horizontalMoveDirection = (- Vector3.Cross(forwardDirection, planetToPlayerRay).normalized) * horizontalInput;
        
        moveDirection = (verticalMoveDirection + horizontalMoveDirection).normalized;
    }

    void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 gravityUp = (transform.position - planet.transform.position).normalized;
            this.GetComponent<Rigidbody>().AddForce(jumpStrength * gravityUp);
        }
    }

    void MovePlayer()
    {
        // GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        this.GetComponent<Rigidbody>().AddForce((moveDirection + planetToPlayerRay * 2) * moveSpeed * Time.deltaTime);
    }

    // void OnDrawGizmosSelected(Vector3 forwardDirection)
    // {
    //     // Draws a 5 unit long red line in front of the object
    //     Gizmos.color = Color.red;
    //     // Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
    //     Gizmos.DrawRay(transform.position, (forwardDirection*10));
    // }
    
}
