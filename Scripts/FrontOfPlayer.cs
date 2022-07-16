using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontOfPlayer : MonoBehaviour
{
	public Transform playerTransform;
	public Vector3 offset;
	

    private void Update()
	{
		transform.position = playerTransform.position + offset;
	}
}
