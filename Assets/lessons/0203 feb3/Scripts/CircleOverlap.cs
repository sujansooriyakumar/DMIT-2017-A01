using UnityEngine;

public class CircleOverlap : MonoBehaviour
{
    public float radius;
    public string tagToCheck;

    private void Update()
    {
        CustomDebug.DrawDebugCircle(transform.position, radius, Color.red, 50);
        Debug.Log(CircleOverlapCheck());
    }

    public bool CircleOverlapCheck()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag(tagToCheck))
            {
                return true;
            }
        }
        return false;
    }
}
