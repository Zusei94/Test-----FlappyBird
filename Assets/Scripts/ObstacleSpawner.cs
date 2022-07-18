using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField] private float waitTime;
	[SerializeField] private GameObject[] obstaclePrefabsEasy;
	[SerializeField] private GameObject[] obstaclePrefabsHard;
	private float tempTime;
	// e = number obstaclePrefabsEasy was spawned, h = obstaclePrefabHard was spawned
	private int e, h, i;

	void Start(){
		tempTime = waitTime - Time.deltaTime;
	}

	void LateUpdate()
	{
		if (GameManager.Instance.GameState())
		{
			tempTime += Time.deltaTime;
			if (tempTime > waitTime)
			{
				// Wait for some time, create an obstacle, then set wait time to 0 and start again
				tempTime = 0;
				if (e == 0 && h == 0 || e < 3)
				{
					GameObject pipeClone = Instantiate(obstaclePrefabsEasy[Random.Range(0, 2)], transform.position, transform.rotation);
					e++;
				}
				else if (e == 3)
				{
					GameObject pipeClone = Instantiate(obstaclePrefabsHard[i], transform.position, transform.rotation);
					h++;
					i++;
					if (i == 3)
					{
						i = 0;
					}
					if (h == 3)
					{
						e = 0;
						h = 0;
					}
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.transform.parent != null){
			Destroy(col.gameObject.transform.parent.gameObject);
		}else{
			Destroy(col.gameObject);
		}
	}

}
