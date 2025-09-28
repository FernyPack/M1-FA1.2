using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 10f;
    public float rotationSpeed = 5f;

    private Rigidbody rb;
    private float fixedY; // store floor Y position

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fixedY = transform.position.y; // initial Y
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(h, 0, v).normalized;

        if (inputDir.magnitude >= 0.1f)
        {
            Vector3 moveDir = transform.TransformDirection(inputDir);
            Vector3 nextPos = rb.position + moveDir * moveSpeed * Time.fixedDeltaTime;
            nextPos.y = fixedY; 
            rb.MovePosition(nextPos);

            Vector3 currentEuler = rb.rotation.eulerAngles;
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            Quaternion finalRotation = Quaternion.Euler(currentEuler.x, targetRotation.eulerAngles.y, currentEuler.z);

            rb.MoveRotation(Quaternion.Slerp(rb.rotation, finalRotation, rotationSpeed * Time.fixedDeltaTime));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GameObject proj = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody projRb = proj.GetComponent<Rigidbody>();
            projRb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
            Destroy(proj, 5f);
        }
    }
}
