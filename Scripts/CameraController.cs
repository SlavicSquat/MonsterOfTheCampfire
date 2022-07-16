using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform playerTransform;
	public Vector3 offset;
	
	private float SmoothSpeed = 0.1f;
	

    private void Update()
	{
		Vector3 Position = playerTransform.position + offset;
		Vector3 SmoothVector = Vector3.Lerp(transform.position, Position, SmoothSpeed);
		
		transform.position = SmoothVector;
		
		
		//transform.position = playerTransform.position + offset;
	}
}
