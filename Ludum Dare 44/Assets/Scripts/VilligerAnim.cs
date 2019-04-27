using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Animator))]
public class VilligerAnim : MonoBehaviour
{
	public float attackTime = 2.0f;

	private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
	{
		
	}

	public void Attack()
	{
		anim.SetBool("attack", true);
		Invoke("UnAttack", attackTime);
	}

	private void UnAttack()
	{
		anim.SetBool("attack", false);
	}

	public void Die()
	{

	}
}
