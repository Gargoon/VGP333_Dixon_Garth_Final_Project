using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GunControl : MonoBehaviour 
{

	[SerializeField]
	Animator myAnimator;

	[SerializeField]
	AudioSource myAudiosource;

	[SerializeField]
	GameObject PlayerFPCamera;
	public Player player;

	void Update () 
	{
		if (CrossPlatformInputManager.GetButtonDown("Fire1"))
		{
			myAnimator.SetTrigger("Slashing");

			RaycastHit hit;
			if (Physics.Raycast(PlayerFPCamera.transform.position, 
				PlayerFPCamera.transform.forward, out hit,3))
			{
				GameObject target = hit.collider.transform.gameObject;
				Enemy enemy = target.GetComponent<Enemy>();
				if (enemy)
				{
					enemy.Damage(50,PlayerFPCamera.transform.parent);
			 	}
				GameObject targ = hit.collider.transform.gameObject;
				EnemySpawner myEnemySpawner = target.GetComponent<EnemySpawner>();
				if (myEnemySpawner)
				{
					myEnemySpawner.Damage(1,PlayerFPCamera.transform.parent);
				}
			}
		}
	}
	public void OnTriggerEnter(Collider col)
	{
		
		GameObject target = col.transform.gameObject;
		if(target.tag == "Enemy")
		{
			Enemy enemy = target.GetComponent<Enemy>();
			enemy.Damage(25,PlayerFPCamera.transform.parent);
		}
		if (target.tag == "EnemySpawner")
		{
			EnemySpawner myEnemySpawner = target.GetComponent<EnemySpawner>();
			myEnemySpawner.Damage(1,PlayerFPCamera.transform.parent);
		}

	}

}

