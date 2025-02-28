using UnityEngine;
using UnityEngine.SceneManagement;

public class CarrotEnd : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(" Carrot Hit");



        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit Carrot");

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            
            SceneManager.LoadScene(2);

        }
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
