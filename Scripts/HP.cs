using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
	public Image bar;
	
    public float maxHP = 100f;
	private float Health;
	
	void Start()
	{
		Health = maxHP;
	}
	
    void Update()
    {
		if (Health > 0)
			Health -= 0.01f;
        bar.fillAmount = Health/100f;
    }
}
