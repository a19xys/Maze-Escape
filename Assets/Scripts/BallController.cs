using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody rb;

    [SerializeField] private Transform multiTargetTransform;
    private Vector3 localStartPosition;
    private float fallThresholdY = -1.5f;

    void Start() {
        rb = GetComponent<Rigidbody>();

        if (multiTargetTransform == null) {
            Debug.LogError("Debes asignar el MultiTarget en el Inspector.");
            return;
        }
        localStartPosition = multiTargetTransform.InverseTransformPoint(transform.position);
    }

    void Update() {
        if (transform.position.y <= fallThresholdY) {
            Debug.Log("La bola ha caído. Reiniciando posición...");
            ResetBall();
        }
    }

    public void enableRigidBody(bool enable) {
        Debug.Log("enableRigidBody " + enable);
        rb.constraints = enable ? RigidbodyConstraints.None : RigidbodyConstraints.FreezeAll;
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "goal") {
            Debug.Log("¡Enhorabuena, has llegado a la meta!");
        } else if (other.CompareTag("Hazard")) {
            Debug.Log("Has tocado un peligro. Reiniciando posición...");
            ResetBall();
        }
    }

    private void ResetBall() {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = multiTargetTransform.TransformPoint(localStartPosition);
    }

}