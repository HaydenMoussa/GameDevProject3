using UnityEngine;

public class DeathBlock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D collision)
    {    Debug.Log("Death block hit");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit death block");
            
            Respawn.respawn();
        }
    }








}
