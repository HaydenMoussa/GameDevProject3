using UnityEngine;

public class NPC : MonoBehaviour
{
    // It was always skipping the first dialogue and I couldn't figure it out.
    //
    // bool firstInteraction = true;
    // [SerializeField] int repeatStartPosition;

    // public string npcName;
    // public DialogueAsset dialogueAsset;

    // [HideInInspector]
    // public int StartPosition {
    //     get
    //     {
    //         if (firstInteraction)
    //         {
    //             Debug.Log("First interaction.");
    //             firstInteraction = false;
    //             return 1;
    //         }
    //         else
    //         {
    //             Debug.Log("Not first interaction.");
    //             return repeatStartPosition;
    //         }
    //     }
    // }
    //
    // So I just made it never skip it at all. -Fin

    public string npcName;
    public DialogueAsset dialogueAsset;

    [HideInInspector]
    public int StartPosition => 0;
}

