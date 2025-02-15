using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody ballRB;
    private bool isBallLaunched;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
    }

    private void LaunchBall() {
        if (isBallLaunched) return;
        transform.parent = null;
        isBallLaunched = true;
        ballRB.isKinematic = false;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
