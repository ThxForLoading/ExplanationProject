using UnityEngine;

public class InteractableNumGenerator : MonoBehaviour, IInteractible
{
    public void Interact()
    {
        Debug.Log(Random.Range(0, 100));
    }
}
