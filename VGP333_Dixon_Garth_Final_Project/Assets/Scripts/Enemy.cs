using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	[SerializeField]
	public Player player;
	private const int MAX_HEALTH = 100;
	[SerializeField]
	int Health = MAX_HEALTH;
	[SerializeField]
	Image ImgHealth;
	private Transform target;

	[SerializeField]
	Animator myAnimator;
	[SerializeField]
	AudioSource myAudioSource;
	private float timeToAttack;

	public void Damage(int points, Transform newTarget)
	{
		//Debug.Log ("attack");
		Health -= points;
		//Debug.Log (Health);
		ImgHealth.fillAmount = (float)Health / (float)MAX_HEALTH;

		if (Health <= 0)
		{
			Destroy (gameObject);
			player.UpDateCharge();
		}

		else
		{
			target = newTarget;
		}
	}
	void Update()
	{
		if (target)
		{
			GetComponent<NavMeshAgent>().SetDestination(target.position);
			float distance = Vector3.Distance(target.position, transform.position);

			if (distance > 2.5f)
			{
				myAnimator.SetBool("IsWalking", true);
				timeToAttack = 1.5f;
			}

			else
			{
				myAnimator.SetBool("IsWalking", false);
				Attack();
			}
		}
	}

	void Attack()
	{
		//Debug.Log ("enemyattacking"+timeToAttack);
		timeToAttack -= Time.deltaTime;
		if (timeToAttack > 0) 
		{
			return;
		}

			timeToAttack = 1.5f;
			Player player = target.GetComponent<Player> ();
		Debug.Log ("player="+target.name);
			if (player)
		{
			myAnimator.SetTrigger("Attack");
			player.Damage(10);
		}
	}
}
