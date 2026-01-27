using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
        anim.SetInteger("testParam", 5);
    }

    
}
