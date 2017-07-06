using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnner : MonoBehaviour {

    // Use this for initialization
    void Start() {


    }

    public GameObject bullet;
    RaycastHit hit;
	
	// Update is called once per frame
	void Update () {


        Ray pickray = Camera.main.ScreenPointToRay(Input.mousePosition);

       if(Physics.Raycast(pickray, out hit))
        {
            Debug.Log("맞은애 = " + hit.transform);
            bullet.transform.LookAt(hit.point);
        }
            else
        {
            Debug.Log("없음");
        }

       /*
       if(Input.GetKeyDown(KeyCode.Z))
        {
            GameObject go = Instantiate(bullet, transform.position, transform.rotation);
            //go velocity = transform
        }
        */
	}
}


