using UnityEngine;

public class GravityController : MonoBehaviour {
    [SerializeField] private Transform arCameraTransform;

    void FixedUpdate() {
        if (arCameraTransform != null) { Physics.gravity = arCameraTransform.up * -9.81f; }
    }
}

/*
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public Transform multiTargetTransform; // El cubo con los patrones

    [Range(0f, 20f)]
    public float gravityScale = 9.81f;

    void FixedUpdate()
    {
        if (multiTargetTransform != null)
        {
            // Dirección de "abajo" según la inclinación del cubo
            Vector3 gravityDirection = -multiTargetTransform.up;

            // Aplicamos la gravedad global
            Physics.gravity = gravityDirection * gravityScale;

            // Visual debug
            Debug.DrawRay(multiTargetTransform.position, gravityDirection * 2f, Color.red);
        }
    }
}
*/