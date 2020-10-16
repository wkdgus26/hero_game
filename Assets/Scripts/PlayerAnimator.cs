using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

	public float speed;
	private Vector3 vector;

	public int walkCount;
	private int currentWalkCount;

	private bool canMove = true;

	private Animator animator;

	void Start () 
	{	
		animator = GetComponent<Animator> ();
	}

	IEnumerator MoveCoroutine()
	{
		vector.Set (Input.GetAxisRaw ("Horizontal"), transform.position.y, transform.position.z);

		animator.SetFloat ("DirX", vector.x);
		animator.SetFloat ("DirY", 0);
		animator.SetBool ("Walking", true);

		while (currentWalkCount < walkCount) 
		{
			if (vector.x != 0) 
			{
				transform.Translate (vector.x *speed, 0, 0);
			}
			currentWalkCount++;
			yield return new WaitForSeconds (0.01f);
		}

		currentWalkCount = 0;

		animator.SetBool ("Walking", false);
		canMove = true;
	}

	void Update ()
	{
		if (canMove) 
		{
			if (Input.GetAxisRaw ("Horizontal") != 0) 
			{
				canMove = false;
				StartCoroutine (MoveCoroutine ());
			}
		}

	}
}
