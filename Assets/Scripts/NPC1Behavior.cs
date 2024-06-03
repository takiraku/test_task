using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1Behavior : MonoBehaviour
{
    public Collider2D interactCol;
    public LayerMask charaLayer;
    private bool isFlipped = false;

    void FixedUpdate(){
        if (interactCol.IsTouchingLayers(charaLayer) && Input.GetAxisRaw("Submit") > 0 && !isFlipped){
            StartCoroutine(Interaction());
        }
    }

    void Flip() {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    IEnumerator Interaction(){
        isFlipped = true;
        Flip();
        yield return new WaitForSeconds(2);
        Flip();
        isFlipped = false;
    }
}
