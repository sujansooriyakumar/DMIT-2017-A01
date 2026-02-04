using System.Collections;
using System.Collections.Specialized;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float range;
    public float moveSpeed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InitializeMovement(Vector3 newPosition)
    {
        StartCoroutine(MoveToPosition(newPosition));
    }
    private IEnumerator MoveToPosition(Vector3 newPosition_)
    {
        bool inRange = false;

        while (!inRange)
        {
            Vector2 moveDir = newPosition_ - transform.position;
            moveDir.Normalize();
            rb.linearVelocity = moveDir * moveSpeed;
            inRange = (Vector2.Distance(transform.position, newPosition_) < range);

            if (inRange)
            {
                rb.linearVelocity = Vector3.zero;
            }
            yield return null;
        }
        yield return null;
    }
}
