using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class TopDownMouse : MonoBehaviour
{
    //This Script uses NavMesh navigation to move the character based on mouse location

    private NavMeshAgent _agent;


    [SerializeField] InputActionReference mouseClick;
    [SerializeField] InputActionReference mousePos;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        mouseClick.action.performed += OnClick;
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos.action.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _agent.SetDestination(hit.point);
        }
    }

    private void OnEnable()
    {
        mouseClick.action.Enable();
    }

    private void OnDisable()
    {
        mouseClick.action.Disable();
    }
}
