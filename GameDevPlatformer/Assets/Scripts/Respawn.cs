using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    private static Vector2 currentCheckpoint;


    private Vector2 initialStartPos;

    private void Start()
    {

        initialStartPos = transform.position;


        if (currentCheckpoint == Vector2.zero)
        {
            currentCheckpoint = initialStartPos;
        }
    }

    public void UpdateCheckpoint(Vector2 newCheckpoint)
    {
        
        currentCheckpoint = newCheckpoint;
        Debug.Log($"Checkpoint updated to: {currentCheckpoint}");
    }


    public static void respawn()
    {
        // Find the player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            
            player.transform.position = currentCheckpoint;

            Animator animator = player.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("isAlive", true);
            }
        }
        else
        {
            Debug.LogError("No player found in the scene!");
        }
    }
}
