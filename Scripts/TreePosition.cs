using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePosition : MonoBehaviour
{
	public GameObject Player;
	public Vector3 offset;
	public float throwStrenght;
	private bool onPlayer = false;
	private bool inContact = false;
	
	public AudioSource audioSource;
	public AudioClip scorchingSound;
	
	
    void Update()
    {
		CarryPosition();
    }
	
	private void OnTriggerStay(Collider collision)
	{
		inContact = true;
		if (collision.tag == "Campfire")
		{
			if (collision.GetComponent<Campfire>().Health + 20f > collision.GetComponent<Campfire>().maxHP)
			{
				collision.GetComponent<Campfire>().Health = collision.GetComponent<Campfire>().maxHP;
			}
			else
				collision.GetComponent<Campfire>().Health += 20f;
			
			audioSource.clip = scorchingSound;
			audioSource.Play();
			
			FireContact();
		}
	}
	
	private void OnTriggerExit(Collider collision)
	{
		inContact = false;
	}
	
	private void CarryPosition()
	{
		if (onPlayer && Input.GetKeyDown(KeyCode.G))
		{
			onPlayer = false;
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().isKinematic = false;
			transform.parent = null;
			GetComponent<Rigidbody>().AddForce(Player.transform.forward * throwStrenght, ForceMode.Impulse);
		
		}
		
		if (inContact && Input.GetKeyDown(KeyCode.Space))
		{
			onPlayer = true;
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().isKinematic = true;
			transform.parent = Player.transform;
			transform.localPosition = Vector3.zero + offset;
		}
	}
	
	private void FireContact()
	{
		Destroy(gameObject);
	}
}
