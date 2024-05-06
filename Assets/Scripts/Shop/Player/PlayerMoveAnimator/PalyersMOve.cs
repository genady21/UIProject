using UnityEngine;

public class PalyersMOve : MonoBehaviour
{
    private const string HorizontlAxisIsName = "Horizontal";
    private const string VerticallAxisIsName = "Vertical";
    private const string MoveForvardHash = "MoveValue";
    private const string StrafeValueHash = "StrafeValue";

    private Animator animator;
    private Vector2 InputDirection;
    private Rigidbody rb;
    [SerializeField] private float speed = 10f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputDirection = new Vector2(Input.GetAxis(HorizontlAxisIsName), Input.GetAxis(VerticallAxisIsName));
        if (Input.GetKey(KeyCode.LeftShift)) InputDirection.y += 1;
        animator.SetFloat(MoveForvardHash, InputDirection.y);
        animator.SetFloat(StrafeValueHash, InputDirection.x);

        var dirVector = new Vector3(Input.GetAxis(HorizontlAxisIsName), 0, Input.GetAxis(VerticallAxisIsName));
        rb.velocity = dirVector * speed * Time.deltaTime;
    }
}