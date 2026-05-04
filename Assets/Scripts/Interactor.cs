using System;
using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractible
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;          //Positional source for the raycast (main camera)
    public float InteractRange;         //Reichweite für den Raycast

    [SerializeField] InputActionReference interactKey;      //input action

    private void Awake()        //link subscribtions to events in awake so you can reference them in start
    {
        interactKey.action.performed += onInteract;     //Input Action methode zuweisen
    }

    private void onInteract(InputAction.CallbackContext context)
    {
        Debug.Log("E pressed");
        Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractible interactObj))
            {
                interactObj.Interact();
            }
            
        }
    }

    private void OnEnable()
    {
        interactKey.action.Enable();
    }

    private void OnDisable()
    {
        interactKey.action.Disable();
    }

    private void OnDestroy()
    {
        interactKey.action.performed -= onInteract;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(InteractorSource.position,InteractorSource.position + InteractorSource.forward * InteractRange);
    }
}
