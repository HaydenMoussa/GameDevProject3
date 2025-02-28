using UnityEngine;

public class PlayerConvo : MonoBehaviour
{
    [SerializeField] float talkDistance = 2;
    bool inConversation;
    private bool hasTriggered = false;
    public GameObject ground;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("in collider");
        if(!hasTriggered){
            Interact();
            hasTriggered = true;
        }
        
        
    }
    void OnDialogueFinished()
    {
        Destroy(ground); 
    }

    public void Interact()
    {
        if (inConversation)
        {
            GameManager.Instance.SkipLine();
        }
        else
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, talkDistance, Vector2.up, 0, LayerMask.GetMask("NPC"));
            if (hit && !hasTriggered)
            {

                if (hit.collider.gameObject.TryGetComponent(out NPC npc))
                {
                    Debug.Log("Interacting with " + npc.npcName);

                    GameManager.Instance.StartDialogue(npc.dialogueAsset.dialogue, npc.StartPosition, npc.npcName);

                    hasTriggered = true;

                }
            }
        }
    }

    void JoinConversation()
    {
        inConversation = true;
    }

    void LeaveConversation()
    {
        inConversation = false;
    }

    private void OnEnable()
    {
        GameManager.OnDialogueStarted += JoinConversation;
        GameManager.OnDialogueEnded += LeaveConversation;
        GameManager.OnDialogueEnded += OnDialogueFinished;
    }

    private void OnDisable()
    {
        GameManager.OnDialogueStarted -= JoinConversation;
        GameManager.OnDialogueEnded -= LeaveConversation;
        GameManager.OnDialogueEnded -= OnDialogueFinished;
    }

}
