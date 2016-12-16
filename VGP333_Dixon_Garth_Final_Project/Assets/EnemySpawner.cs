using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public const int MAX_HEALTH = 1;
	[SerializeField]
	GameObject player;
	[SerializeField]
	public int Health = MAX_HEALTH;
	[SerializeField]
	GameObject SpawnerPoint;
	[SerializeField]
	GameObject enemy;
	[SerializeField]
	float spawnTime = 2f;

	void Start () 
	{
		InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
	}
	
	void SpawnEnemy () 
	{
		GameObject go = Instantiate(enemy, SpawnerPoint.transform.position, Quaternion.identity) as GameObject;
		go.transform.position = SpawnerPoint.transform.position;
		go.GetComponent<Enemy>().Damage(0, player.transform);
		go.GetComponent<Enemy>().player=player.GetComponent<Player>();
	}
	public void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "swords2") 
		{
			Destroy (col.gameObject);
		}

	}
	public void Damage(int points, Transform newTarget)
	{
		//Debug.Log ("attack");
		Health -= points;

		if (Health <= 0 )
		{
	    Destroy (gameObject);
		
		} 
		else 
		{
		}
	}
}
