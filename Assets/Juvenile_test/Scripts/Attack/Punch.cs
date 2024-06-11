using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Punch : MonoBehaviour
{
    [Header("Internal References")]
    [SerializeField] GameObject controllerObject;
    [SerializeField] GameObject objectToLaunchPrefab;

    [Header("Launch Parameters")]
    [SerializeField] float launchForce = 100f;

    [Header("Haptics Parameters")]
    [SerializeField] float amplitude = 0.5f;
    [SerializeField] float duration = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object1") && other.isTrigger)
        {
            Vector3 controllerPosition = controllerObject.transform.position;
            Quaternion controllerRotation = controllerObject.transform.rotation;

            GameObject objectToLaunch = Instantiate(objectToLaunchPrefab, controllerPosition, controllerRotation);
            Rigidbody objectRigidbody = objectToLaunch.GetComponent<Rigidbody>();

            Vector3 launchDirection = controllerObject.transform.forward;
            objectRigidbody.AddForce(launchDirection * launchForce, ForceMode.Impulse);

            TriggerHaptics();
        }
    }

    private void TriggerHaptics()
    {
        controllerObject.GetComponent<XRBaseController>().SendHapticImpulse(amplitude, duration);
    }
}
