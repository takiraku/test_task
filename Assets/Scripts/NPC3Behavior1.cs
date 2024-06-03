using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3Behavior : MonoBehaviour
{
    public float movSpeed = 75f;
    public float jumpForce = 40f;
    public Collider2D interactLeftCol;
    public Collider2D interactRightCol;
    public BoxCollider2D NPCCol;
    public LayerMask charaLayer;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public Rigidbody2D NPCRigidBody;
    public GameObject sprite;
    private Vector2 mov;
    private bool isGrounded = false;
    private bool isFacingRight = true;

    // void Update(){
    // }

    void FixedUpdate(){
        GroundedCheck();
        MovementManager();
        MoveAvoid();
        SpriteDirection();
    }

    void MovementManager(){
        if (interactLeftCol.IsTouchingLayers(charaLayer) && isGrounded){
            if (interactRightCol.IsTouchingLayers(wallLayer)){
                mov = new Vector2(-movSpeed, jumpForce);
            }
            else{
                mov = new Vector2(movSpeed, 0);
            }
        }
        else if (interactRightCol.IsTouchingLayers(charaLayer) && isGrounded){
            if (interactLeftCol.IsTouchingLayers(wallLayer)){
                mov = new Vector2(movSpeed, jumpForce);
            }
            else{
                mov = new Vector2(-movSpeed, 0);
            }
        }
        else if (isGrounded) {
            mov = new Vector2(0,0);
        }
    }

    void MoveAvoid(){
        if(!isGrounded) {
            NPCRigidBody.velocity = new Vector2(NPCRigidBody.velocity.x, NPCRigidBody.velocity.y);
        }
        else {
            NPCRigidBody.velocity = new Vector2(mov.x * Time.fixedDeltaTime, mov.y * Time.fixedDeltaTime);
        }
    }

    void GroundedCheck() {
        isGrounded = NPCCol.IsTouchingLayers(groundLayer);
    }

    void Flip() {
        Vector3 scale = sprite.transform.localScale;
        scale.x *= -1;
        sprite.transform.localScale = scale;
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
