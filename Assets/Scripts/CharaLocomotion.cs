using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharaLocomotion : MonoBehaviour
{
    public float movSpeed = 75f;
    public float jumpForce = 40f;
    public Rigidbody2D rigidBody;
    public BoxCollider2D charaCol;
    // public BoxCollider2D groundCol;
    public LayerMask groundLayer;

    private Vector2 mov;
    private bool isGrounded;
    private bool isFacingRight = true;

    // Update is called once per frame
    void Update()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal") * movSpeed, Input.GetAxisRaw("Vertical") * jumpForce);
    }

    void FixedUpdate() {
        GroundedCheck();
        Move();
        SpriteDirection();
    }

    void Move(){
        if (isGrounded && mov.y > 0) {
            rigidBody.velocity = new Vector2(mov.x * Time.fixedDeltaTime, mov.y * Time.fixedDeltaTime);
        }
        else{
            rigidBody.velocity = new Vector2(mov.x * Time.fixedDeltaTime, rigidBody.velocity.y);
        }
    }

    void GroundedCheck() {
        isGrounded = charaCol.IsTouchingLayers(groundLayer);
    }
    

    void Flip() {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void SpriteDirection(){
        if (mov.x > 0 && !isFacingRight) {
            Flip();
            isFacingRight = true;
        } else if (mov.x < 0 && isFacingRight) {
            Flip();
            isFacingRight = false;
        }
    }
}
