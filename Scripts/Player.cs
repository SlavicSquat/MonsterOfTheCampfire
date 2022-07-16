using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedMove;
	
	private float gravityForce;
	private Vector3 moveVector;
	
	private CharacterController ch_controller;
	
	public GameObject campfireToCreate;
	
	private void Start()
	{
		ch_controller = GetComponent<CharacterController>();
	}
	
	private void Update()
	{
		CharacterMove();
		GamingGravity();
		if (Input.GetKeyDown(KeyCode.F))
		{
			CreateCampfire();
		}
	}
	
	private void CharacterMove()
	{
		moveVector = Vector3.zero;
		moveVector.x = Input.GetAxis("Horizontal") * speedMove;
		moveVector.z = Input.GetAxis("Vertical") * speedMove;
		
		if(Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
		{
			Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
			transform.rotation = Quaternion.LookRotation(direct);
		}
		
		moveVector.y = gravityForce;
		
		ch_controller.Move(moveVector * Time.deltaTime);
	}
	
	private void GamingGravity()
	{
		if(!ch_controller.isGrounded)
			gravityForce -= 20f * Time.deltaTime;
		else
			gravityForce = -1f;
	}
	
	private void CreateCampfire()
	{
		Instantiate(campfireToCreate, transform.position, Quaternion.identity);
	}
}
