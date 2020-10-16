using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatusManager : MonoBehaviour {

	GameObject moneyText;
	GameObject successText;
	GameObject needMoneyText;
	GameObject LevelText;
	public float money; // 돈
	public float strength; // 공격력
	public float enhancementMoney = 100; // 강화 필요골드
	public int enhancementLevel=1; // 강화 레벨
	public float enhancementPercent=90f; // 강화 확률 
	public int nextLevel = 1; // 다음레벨 저장

	public float savedMoney; // 보유골드량
	public float savedStrength; // 공격력 저장
	public float savedNeedMoney; // 강화시 필요골드 저장
	public int savedLevel ; // 레벨 저장
	public float savedSuccess; // 강화 확률 저장

	public Text money_Text;
	public Text success_Text;
	public Text needMoney_Text;
	public Text nowLevel_Text;
	public Text nextLevel_Text;


	void Awake () 
	{
		enhancementMoney = (enhancementLevel * 100) * enhancementLevel;
		enhancementPercent = 100 - (enhancementLevel * 10);
		strength = 1;
		money = PlayerPrefs.GetFloat ("savedMoney");
		savedStrength = PlayerPrefs.GetFloat ("savedStrength");
		if (savedStrength != 1 && savedStrength != 0) 
		{
			strength = savedStrength;
		}

		savedSuccess = PlayerPrefs.GetFloat ("savedSuccess");
		savedNeedMoney = PlayerPrefs.GetFloat ("savedNeedMoney");
		savedLevel = PlayerPrefs.GetInt ("savedLevel");

		if (savedSuccess == 0 || savedNeedMoney == 0 || savedLevel == 0) 
		{
			savedSuccess = enhancementPercent;
			savedNeedMoney = enhancementMoney;
			savedLevel = enhancementLevel;
		}
		else if (savedSuccess != 90f || savedNeedMoney != 100 || savedLevel != 1) 
		{
			enhancementMoney = savedNeedMoney; // 강화 필요골드
			enhancementLevel= savedLevel; // 강화 레벨
			enhancementPercent = savedSuccess;
		}
		PlayerPrefs.Save();
		//money += this.savedMoney;
	}

	void Start () 
	{
		//this.moneyText = GameObject.Find ("savedMoney");
		//this.successText = GameObject.Find ("enhancementPercent");
		//this.needMoneyText = GameObject.Find ("enhancementMoney");
		//this.LevelText = GameObject.Find ("enhancementLevel");
		//DontDestroyOnLoad (gameObject.);
	}


	void Update () 
	{
		nextLevel = enhancementLevel + 1;

		PlayerPrefs.SetFloat("savedStrength", savedStrength);
		money += Time.deltaTime * strength ;
		savedMoney = money;
		PlayerPrefs.SetFloat("savedMoney", savedMoney);
		PlayerPrefs.SetFloat("savedSuccess", savedSuccess);
		PlayerPrefs.SetFloat("savedNeedMoney", savedNeedMoney);
		PlayerPrefs.SetInt("savedLevel", savedLevel);

		money_Text.text = savedMoney.ToString ("F1");
		success_Text.text = enhancementPercent.ToString ("F1") + " %";
		needMoney_Text.text = enhancementMoney.ToString ("F0") +" Gold";
		nowLevel_Text.text = enhancementLevel.ToString() + " Lv";
		nextLevel_Text.text = nextLevel.ToString () + " Lv";
		//this.moneyText.GetComponent<Text> ().text = money.ToString ("F1");// + "money";
	}

	public void Enhancement() 
	{ 

		if(enhancementLevel == 10 || enhancementPercent == 0 || money < enhancementMoney) // 강화 레벨이 10이거나 강화 확률이 0가 되면 
			return; // 아무것도 하지 말자. 

		 // 현재 강화 확률 : 강화 레벨이 0이면 100, 1이면 90, 2면 80 ... 9면 10. 10이면 0 
		money -= enhancementMoney;
		float percent = Random.Range(0, 100); // 전체 경우의 수 0~ 99 

		if (percent <= enhancementPercent - 1) // 만약 랜덤으로 경우의 수를 뽑은 것이 강화 확률 안에 들면 
		{ 
			enhancementLevel++; // 강화 레벨을 1 업.
			enhancementPercent = 100 - (enhancementLevel * 10);
			enhancementMoney = (enhancementLevel * 100) * enhancementLevel;
			strength *= 2;
			savedStrength = strength;
			savedSuccess = enhancementPercent;
			savedNeedMoney = enhancementMoney;
			savedLevel = enhancementLevel;

			Debug.Log("강화 성공"); // 결과 표시
			Debug.Log(enhancementPercent);
			Debug.Log(enhancementMoney);
			Debug.Log(enhancementLevel);
		} 
		else // 아니면 
		{ 
			Debug.Log("강화 실패"); // 강화 실패 표시 
		} 
	} 

}
