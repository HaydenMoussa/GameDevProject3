using UnityEngine;

public class JumpPower : MonoBehaviour
{



    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("JP Buff Hit");



        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit JP Buff");

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            disableBuff();

            player.incJump();


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
