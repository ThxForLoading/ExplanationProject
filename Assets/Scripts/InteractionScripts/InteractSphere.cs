using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractSphere : MonoBehaviour, IInteractible
{
    public void Interact()
    {
        SceneHandler.instance.LoadScene("UIDialog");
    }
}
