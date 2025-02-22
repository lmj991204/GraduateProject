﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	public string unitName;
	public int unitLevel;
	public int damage;

	public int maxHP;
	public int currentHP;
	SoundManager SoundEffect;
	public string storeItemName;

	public int ADDHeal = 0;
	
	public bool TakeEdamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
            return true;
        else
            return false;
    }

	public bool TakeDamage(int dmg)
	{
        currentHP -= dmg + GameObject.Find("Battle System").GetComponent<BattleDamageCalc>().FinalDamageWithCard();

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	public void Heal()
	{
		currentHP += GameObject.Find("Battle System").GetComponent<BattleDamageCalc>().FinalHealWithCard();
		if (currentHP > maxHP)
			currentHP = maxHP;
	}

	public void UseStore()
	{
		int a;
		string b;
		storeItemName = GameObject.Find("player").GetComponent<PlayerClickItem>().clickItemName;
		a = int.Parse(storeItemName.Substring(4, 1));
		b = storeItemName.Substring(0, 4);
		if (b == "Mult")
		{
			switch (a)
			{
				case 9:
					currentHP -= (maxHP / 10) * 5;
					break;
				case 8:
				case 7:
				case 6:
				case 5:
					currentHP -= (maxHP / 10) * 4;
					break;
				case 4:
				case 3:
				case 2:
					currentHP -= (maxHP / 10) * 3;
					break;
				case 1:
					currentHP -= 10;
					break;
			}
		}
		else if (b == "Plus")
		{
			switch (a)
			{
				case 9:
					currentHP -= 15;
					break;
				case 8:
				case 7:
				case 6:
				case 5:
					currentHP -= 10;
					break;
				case 4:
				case 3:
				case 2:
				case 1:
					currentHP -= 5;
					break;
			}
		}
	}

	public void HealField()
    {
		SoundEffect = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		SoundEffect.SFXPlay("audioHealCenter");
		ADDHeal = (maxHP / 10) * 3;
		currentHP += ADDHeal;
		if(currentHP >= maxHP)
        {
			currentHP = maxHP;
        }
	}

	public void MaxHPIncrease()
    {
		maxHP += 10;
    }
}
