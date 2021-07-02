using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;

    void Start ()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }


    void Update()
    {
        bool animWalking = animator.GetBool(isWalkingHash);

        if (!animWalking && Input.GetMouseButtonDown (0))
        {
            animator.SetBool(isWalkingHash, true);
        }
    }
}
