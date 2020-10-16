using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

	public Transform knight;
	public float speed;
	bool a,b;
	private Animator animator;
	int key =1;

	void Start () {
		animator = GetComponent<Animator> ();
	}

	void Update () 
	{

		if (a)
		{
			if (key == 0) 
			{
				key = 1;
			}
			knight.position += Vector3.right * speed * Time.deltaTime;
			if (key != 1) 
			{
				Flip ();
				key = 1;
			}
		}

		if (b)
		{	if (key == 0) 
			{
				key = -1;
			}
			knight.position += Vector3.left * speed * Time.deltaTime;
			if (key != -1) 
			{
				Flip ();
				key = -1;
			}
		}
	}

	public void RightUp()
	{
		animator.SetBool ("Walking", false);
		a = false;
	}

	public void RightDown()
	{
		animator.SetFloat("DirX", 1f);
		animator.SetFloat("DirY", 0f);
		animator.SetBool ("Walking", true);
		a = true;
	}

	public void LeftUp()
	{
		animator.SetBool ("Walking", false);
		b = false;
	}

	public void LeftDown()
	{

		animator.SetFloat("DirX", -1f);
		animator.SetFloat("DirY", 0f);
		animator.SetBool ("Walking", true);
		b = true;
	}


	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}
