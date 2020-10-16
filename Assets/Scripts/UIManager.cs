using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {
	public StatusManager sM;
	void Start () 
	{
		sM = GameObject.Find("StatusManager").GetComponent<StatusManager>();
	}

	void Update () 
	{
		
	}

	public void ButtonClick(string type)
	{
		switch (type) 
		{
			case "START":
				SceneManager.LoadScene ("Field");
				break;
				// 돈벌기
			case "ENHANCE":
				SceneManager.LoadScene ("Enhance");
				break;
				// 강화하기
			case "RESET":
				sM.money = 0;
				sM.strength = 1;
				sM.enhancementMoney = 100;
				sM.enhancementLevel = 1;
				sM.enhancementPercent = 90f;
				sM.nextLevel = 1;
				sM.savedMoney = 0;
				sM.savedStrength = 0;
				sM.savedNeedMoney = 0;
				sM.savedLevel = 0;
				sM.savedSuccess = 0;
				break;
				// 리셋
			case "EXIT":
				PlayerPrefs.DeleteAll ();
				System.Diagnostics.Process.GetCurrentProcess ().Kill ();
				break;
		}
	}
}
