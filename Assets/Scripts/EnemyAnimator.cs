using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetState(int state)
    {
        StopAllCoroutines();
        animator.SetInteger("State", state);
        StartCoroutine(GoBackToIdle());
    }

    public IEnumerator GoBackToIdle()
    {
        yield return new WaitForSeconds(1);
        animator.SetInteger("State", 0);
    }
}
