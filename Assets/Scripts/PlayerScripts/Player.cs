using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	private Animator anim;
	private CharacterController controller;


	public float speed = 0.5f;
	public float turnSpeed = 0.5f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;

	void Start()
	{
		controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
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

		/*
		if(controller.isGrounded)
		{
		}

		moveDirection = transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed;
		 */


		float Hor = Input.GetAxisRaw("Horizontal");
		float Ver = Input.GetAxisRaw("Vertical");

		//키보드에 따른 이동
		transform.Translate(0.0f, 0.0f, Ver * Time.deltaTime);


		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
	}
}
