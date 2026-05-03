using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == controller.gameObject) return;

        controller.SetGrounded(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == controller.gameObject) return;

        controller.SetGrounded(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == controller.gameObject) return;

        controller.SetGrounded(true);
    }

}
