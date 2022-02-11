using Dialogues;
using Text;
using UnityEngine;

namespace OtherLogic
{
    public class InterplayOpenDialogue : InterplayBase
    {
        [SerializeField]
        public Dialogue _dialogue;
        
        private DialogueWindow _dialogueWindow;

        public void Construct(DialogueWindow dialogueWindow)
        {
            _dialogueWindow = dialogueWindow;
        }
        
        public override void Interaction() => 
            _dialogueWindow.Show(_dialogue);
    }
}