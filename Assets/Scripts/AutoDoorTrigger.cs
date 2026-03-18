using UnityEngine;

public class AutoDoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private string openTriggerName = "Open";
    [SerializeField] private string closeTriggerName = "Close";
    [SerializeField] private float closeDelay = 2f;

    private bool isDoorOpen = false;
    private Coroutine closeCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScheduleCloseDoor();
        }
    }

    private void OpenDoor()
    {
        if (!isDoorOpen)
        {
            isDoorOpen = true;
            doorAnimator.SetTrigger(openTriggerName);

            if (closeCoroutine != null)
                StopCoroutine(closeCoroutine);
        }
    }

    private void ScheduleCloseDoor()
    {
        if (closeCoroutine != null)
            StopCoroutine(closeCoroutine);

        closeCoroutine = StartCoroutine(CloseDoorAfterDelay());
    }

    private System.Collections.IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay);
        
        if (isDoorOpen)
        {
            isDoorOpen = false;
            doorAnimator.SetTrigger(closeTriggerName);
        }
    }
}