using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class colliderchecker : MonoBehaviour {

   // public Transform Target;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");

        if (collision.gameObject.tag == "Enviroment" && gameObject.tag == "Player")
        {
            
            Collider collider = gameObject.GetComponent<CapsuleCollider>();
            collider.isTrigger = true;
            transform.position = new Vector3(0f, 0f, 0f);
            collider.isTrigger = false;
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("nTriggerStay");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
