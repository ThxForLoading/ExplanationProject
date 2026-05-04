using UnityEngine;

public class ChangeGamestate : MonoBehaviour, IInteractible
{
    public void Interact()
    {
        StateMachine.instance.SetGameState(GameState.Gameplay);
    }
}
