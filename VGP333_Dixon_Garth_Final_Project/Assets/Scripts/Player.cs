using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	private const int MAX_HEALTH = 100;
	public int MAX_charge = 10;
	[SerializeField]
	int Health = MAX_HEALTH;
	[SerializeField]
	public int Charge;
	[SerializeField]
	Image ImgHealth;
	[SerializeField]
	Image ChargingBar;
	[SerializeField]
	AudioSource myAudioSource;
	[SerializeField]
	AudioClip PlayerHurt;

	void Start()
	{
		
	}
	public void Damage(int points)
	{

		Debug.Log ("Player being hit");
		Health -= points;
		ImgHealth.fillAmount = (float)Health / (float)MAX_HEALTH;
		if (Health <= 0)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

		else
		{
			myAudioSource.clip = PlayerHurt;
			myAudioSource.Play();
		}
	}
	public void UpDateCharge()
	{
		if (Charge < MAX_charge)
		{
			Charge ++ ;
		}
		else if (Charge >= MAX_charge)
		{
			Charge = MAX_charge;
		}
		ChargingBar.fillAmount = (float)Charge/(float)MAX_charge;
		
	}
	public int GetMaxCharge()
	{
		return MAX_charge;
	}
	void update()
	{
		UpDateCharge ();
	}

}
