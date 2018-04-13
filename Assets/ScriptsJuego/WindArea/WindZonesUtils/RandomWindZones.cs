using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWindZones : MonoBehaviour {

	public GameObject WindZone;

	public Vector3 center;
	public Vector3 size;
	private int count = 0;

	void Start () {

		SpawnWindZones();

	}
	
	void Update () {

		if(count == 150){

		} else {
			SpawnWindZones();
			count++;
			//Debug.Log("Este es el numero " + count);
		}
	}

	public void SpawnWindZones(){

		Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x / 2),0,Random.Range(-size.x / 2 , size.x / 2));
		//Instantiate(WindZone, pos, Quaternion.identity);
		Instantiate(WindZone as GameObject);
		WindZone.GetComponent<WindArea>(pos,50f);
		
	}

	private void OnDrawGizmosSelected() {
		
		Gizmos.color = new Color(1,0,0,0.5f);
		Gizmos.DrawCube(center, size);

	}
}
