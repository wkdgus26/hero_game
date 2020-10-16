using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Transform knight;
	public float speed;
	bool a,b,c;
	private Animator animator;
	int key =1;
	public Transform pos;
	public Vector2 boxSize;


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

		if (c) 
		{
			StatusManager statusmanager = GameObject.Find ("StatusManager").GetComponent<StatusManager> ();
			Collider2D[] collider2Ds = Physics2D.OverlapBoxAll (pos.position, boxSize, 0);
			foreach (Collider2D collider in collider2Ds) 
			{//statusmanager.money =0;
				statusmanager.money += Time.deltaTime * statusmanager.strength * 5f;
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

	public void AttacktUp()
	{	
		c = false;
		animator.SetBool ("Attack", false);
	}

	public void AttackDown()
	{
		c = true;

		animator.SetFloat("DirX", 1f);
		animator.SetFloat("DirY", 0f);
		animator.SetBool ("Attack", true);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (pos.position, boxSize);
	}

	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}
