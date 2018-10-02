using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    SpriteRenderer playerSprite;
    Rigidbody2D playerRigidBody;
    BoxCollider2D playerCollider;

    public int horSpeed;
    public int jumpHeight;

    public KeyCode upKey = KeyCode.W;

    public KeyCode jumpKey = KeyCode.Space;

    float distToGround;

    // Use this for initialization
    void Start()
    {
        //Initiating the rigidBody2D
        playerRigidBody = GetComponent<Rigidbody2D>();

        //Initializing the collider
        playerCollider = GetComponent<BoxCollider2D>();
        distToGround = playerCollider.bounds.extents.y + 0.2f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 horMovement = new Vector2(moveHorizontal * horSpeed, playerRigidBody.velocity.y);
        if (playerRigidBody.velocity.x < 5 )
        {
            playerRigidBody.velocity = horMovement;
        }
        else if (playerRigidBody.velocity.x > -5 )
        {
            playerRigidBody.velocity = horMovement;
        }

        Vector2 verMovement = new Vector2(playerRigidBody.velocity.x, jumpHeight);
        if (IsGrounded() && (Input.GetKeyDown(upKey) || Input.GetKeyDown(jumpKey)))
        {
            playerRigidBody.velocity = verMovement;
        }
    }
    public bool IsGrounded()
    {

        Vector3 tempPosition = playerRigidBody.transform.position;
        tempPosition.y -= distToGround - 0.05f;
        Vector2 ray1 = new Vector2(tempPosition.x + 0.2f, tempPosition.y);
        Vector2 ray2 = new Vector2(tempPosition.x - 0.2f, tempPosition.y);
        Debug.DrawRay(tempPosition, Vector2.down, Color.blue, 0.05f);
        Debug.DrawRay(ray1, Vector2.down, Color.blue, 0.05f);
        Debug.DrawRay(ray2, Vector2.down, Color.blue, 0.05f);
        return Physics2D.Raycast(tempPosition, Vector2.down, 0.05f) || Physics2D.Raycast(ray1, Vector2.down, 0.05f) || Physics2D.Raycast(ray2, Vector2.down, 0.05f);
    }
}