
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datatype : MonoBehaviour {


    enum Direction { North = 1, East, South, West };
    public GameObject[] players;
    public GameObject[] npcs;
    public Transform playerTransform;

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "enemy")
        {
            datatype enemy = collision.gameObject.GetComponent<datatype>();
            enemy.ReverseDirection(Direction.East);

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.mass += 10;
            rb.Sleep();

             Debug.Log("rigid Enter");
        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }

    [System.Serializable]
public class Polygon
    {

        public Vector2[] points;

        public IEnumerator PointEnumerator()
        {

            foreach (Vector2 eachPoint in points) yield return eachPoint;
            yield break;
        }
    }

    public Polygon polygon;

    IEnumerator Example()
    {
        print(Time.time);

        yield return new WaitForSeconds(5);
        print(Time.time);



    }
    
    // Use this for initialization
    void Start () {

        StartCoroutine(Example());

        IEnumerator pointEnumerator = polygon.PointEnumerator();
        while (pointEnumerator.MoveNext())
        {
            Debug.Log(pointEnumerator.Current);

        }



        // component
        playerTransform = this.gameObject.GetComponent<Transform>();



        // array

        npcs = GameObject.FindGameObjectsWithTag("enemy");

        for (int i = 0; i < npcs.Length; i++)
        {
            Debug.Log("Player Number " + i + " is named " + npcs[i].name);
        }

        // enum
        Direction myDirection = Direction.North;
        Direction reversedDirection =  ReverseDirection(myDirection);

        TransformRefvalue();

    }

    void TransformRefvalue()
    {
        Vector3 pos = transform.position;
        pos = new Vector3(0, 2, 0);
        Transform tran = transform;
        tran.position = new Vector3(0, 2, 0);

    }


    Direction ReverseDirection(Direction dir)
    {
        if (dir == Direction.North)
            dir = Direction.South;
        else if (dir == Direction.South)
            dir = Direction.North;
        else if (dir == Direction.East)
            dir = Direction.West;
        else if (dir == Direction.West)
            dir = Direction.East;

        return dir;
    }

    // Update is called once per frame
    void Update () {
		
	}

}
