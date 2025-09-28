using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.3f;
    public float moveSpeed = 2f;
    public float moveRange = 3f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Pulsate
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = new Vector3(scale, scale, scale);

        // Move side to side
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);   // destroy enemy
            Destroy(other.gameObject); // destroy projectile
            GameManager.score++;   // increase score
        }
    }
}
