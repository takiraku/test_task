using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    public GameObject NPC;
    
    public void Spawn()
    {
        Instantiate(NPC, transform.position, Quaternion.identity);
    }
}
