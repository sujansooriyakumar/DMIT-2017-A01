using UnityEngine;

public class Treasure : MonoBehaviour, IInteractable, IDamagable
{
    public void Interact()
    {
    }

    public void TakeDamage()
    {
    }

    public void Explode()
    {
        GameObject[] inRadius;
        foreach (GameObject g in inRadius) {
            g.GetComponent<IDamagable>().TakeDamage();
        }
    }
}
