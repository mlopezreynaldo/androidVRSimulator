using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWindZones : MonoBehaviour {

	public GameObject WindZone;

	public Vector3 center;
	public Vector3 size;
    public GameObject boatPosition;
	private int count = 0;
    public int numberWindZones = 150;
    public GameObject arrow; 

	void Start () {

        SpawnWindZones(false);
    }
	
	void Update () {

		if(count == numberWindZones){

		} else {
			SpawnWindZones(true);
			count++;
			//Debug.Log("Este es el numero " + count);
		}
	}

	public void SpawnWindZones(bool random){

        if (random)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.x / 2, size.x / 2));
            Vector3 windDirectionRandom = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20 , 20));

            WindZone.GetComponent<WindArea>().WindSet(windDirectionRandom, Random.Range(20, 80));

            Instantiate(WindZone as GameObject, pos, Quaternion.identity);

            arrow.GetComponent<Transform>().LookAt(pos);
            Instantiate(arrow as GameObject, pos, Quaternion.identity);
 
        }
        else
        {

            Vector3 windDirectionNear = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
            Vector3 nearWindZone = new Vector3(boatPosition.transform.position.x, 0 , boatPosition.transform.position.z + 270);
            float force = Random.Range(20 , 80);
           
            WindZone.GetComponent<WindArea>().WindSet(windDirectionNear, force);
            Instantiate(WindZone as GameObject, nearWindZone, Quaternion.identity);

            Vector3 arrowPosition = new Vector3(windDirectionNear.x, 15 ,windDirectionNear.z); 
            arrow.GetComponent<Transform>().LookAt(arrowPosition);
            
           // Transform directionArrow = new Vector3(windDirectionNear.x, 0 , windDirectionNear.z);
            //Vector3 posDesired = directionArrow - arrow.GetComponent<Transform>().position;
            //GameObject target = new GameObject();
            //target.AddComponent<Transform>();

            Instantiate(arrow as GameObject, nearWindZone, Quaternion.identity); 
          
            Debug.Log("Near created " + windDirectionNear.ToString());
            Debug.Log("Force Using " + force);
        }
	}

	private void OnDrawGizmosSelected() {		
		Gizmos.color = new Color(1,0,0,0.5f);
		Gizmos.DrawCube(center, size);
	}
}
