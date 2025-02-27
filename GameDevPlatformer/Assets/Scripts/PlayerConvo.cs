using UnityEngine;

public class PlayerConvo : MonoBehaviour
{
    [SerializeField] float talkDistance = 2;
    bool inConversation;
    private bool hasTriggered = false;
    public string[] finalD = {"Wow that was fast, thank you for your work! I'm going to enjoy this!"};

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasTriggered){
            Interact();
            hasTriggered = true;
        }
        
        
    }

    void Interact()
    {
        if (inConversation)
        {
            GameManager.Instance.SkipLine();
        }
        else
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, talkDistance, Vector2.up, 0, LayerMask.GetMask("NPC"));
            if (hit)
            {

                if (hit.collider.gameObject.TryGetComponent(out NPC npc))
                {
                    
                    GameManager.Instance.StartDialogue(npc.dialogueAsset.dialogue, npc.StartPosition, npc.npcName);
                    
                    
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
    }

    private void OnDisable()
    {
        GameManager.OnDialogueStarted -= JoinConversation;
        GameManager.OnDialogueEnded -= LeaveConversation;
    }
}
