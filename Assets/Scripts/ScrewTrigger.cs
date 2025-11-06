using UnityEngine;

public class ScrewTrigger : MonoBehaviour
{
    public RotateScrew rotScrew;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            rotScrew.BeReady();
        }
    }
}
