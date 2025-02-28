using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Respawn respawnManager;

    private void Start()
    {
        respawnManager = FindAnyObjectByType<Respawn>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            if (respawnManager != null)
            {
                respawnManager.UpdateCheckpoint(transform.position);
            }
            else
            {
                Debug.LogError("No Respawn component found in the scene!");
            }
        }
    }
}