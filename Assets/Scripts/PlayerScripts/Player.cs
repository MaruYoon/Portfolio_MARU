using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{

	private Animator anim;
	private CharacterController controller;
	private Rigidbody Rigid;

	public float JumpPower = 10.0f;

	public float speed = 0.5f;
	public float turnSpeed = 0.5f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;

	private bool IsJumping;

	void Start()
	{
		controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();

		Rigid = GetComponent<Rigidbody>();
		Rigid.useGravity = false;

		IsJumping = false;
	}

	void Update()
	{
		if (Input.GetKey("w")||Input.GetKey("s"))
		{
			anim.SetInteger("AnimationPar", 1);
		}
		else
		{
			anim.SetInteger("AnimationPar", 0);
		}


		float Hor = Input.GetAxisRaw("Horizontal");
		float Ver = Input.GetAxisRaw("Vertical");

		//키보드에 따른 이동
		transform.Translate(0.0f, 0.0f, Ver * Time.deltaTime);


		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;

		Jump();

	}

	void Jump()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
			if(!IsJumping)
            {
				IsJumping = true;
				Rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);

					Rigid.useGravity = true;
			
			}
			else
			{
				return;
			}

			Rigid.useGravity = false;
		}

	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
			Debug.Log("충돌");
		}
    }


}
