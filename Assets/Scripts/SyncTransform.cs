using UnityEngine;

public class SyncTransform : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject cam;
    [SerializeField] private float smooth;

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 pos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            cam.transform.position = Vector3.Lerp ( cam.transform.position,pos, smooth);
        }
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
    