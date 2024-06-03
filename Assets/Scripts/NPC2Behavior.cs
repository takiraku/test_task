using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Behavior : MonoBehaviour
{
    public float jumpForce = 40f;
    public Collider2D interactCol;
    public LayerMask charaLayer;
    public LayerMask groundLayer;
    public BoxCollider2D NPCCol;
    public Rigidbody2D NPCRigidBody;
    private bool isGrounded = false;

    void FixedUpdate(){
        GroundedCheck();
        if (interactCol.IsTouchingLayers(charaLayer) && Input.GetAxisRaw("Submit") > 0 && isGrounded){
            NPCRigidBody.velocity = new Vector2(NPCRigidBody.velocity.x, jumpForce * Time.fixedDeltaTime);
        }
    }

    void GroundedCheck() {
        isGrounded = NPCCol.IsTouchingLayers(groundLayer);
    }
}
