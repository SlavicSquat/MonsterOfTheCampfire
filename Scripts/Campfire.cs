using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Campfire : MonoBehaviour
{
	public Image bar;
	
    public float maxHP = 100f;
	public float Health;
	
	public float damagePerTime = 0.005f;
	
	void Start()
	{
		Health = maxHP;
	}
	
    void Update()
    {
		if (Health > 0)
			Health -= damagePerTime;
        bar.fillAmount = Health/maxHP;
    }

}
