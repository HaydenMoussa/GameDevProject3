using UnityEngine;

public class MoveSpeed : MonoBehaviour
{

    


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("MS Buff Hit");

        

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit MS Buff");

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            disableBuff();

            player.incWalkSpeed();


        }
    }



    private void disableBuff()
    {
        Destroy(this.gameObject);
    }







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
