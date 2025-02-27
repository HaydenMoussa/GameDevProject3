using UnityEngine;

public class BuffController : MonoBehaviour
{

    [SerializeField] float talkDistance = 3f;


    void Interact()
    {
        Debug.Log("Interact");

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, talkDistance, Vector2.up, 0, LayerMask.GetMask("Buff"));

        if (hit)
        {
            Debug.Log("Hit Something");

            if (hit.collider.gameObject.tag == "Buff")
            {
                Debug.Log("Hit Buff");
                print("Buff");
            }

        }
    }











    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
}
