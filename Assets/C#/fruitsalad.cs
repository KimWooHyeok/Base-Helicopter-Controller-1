using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Fruit
{
    public Color color;

    //This is the first constructor for the Fruit class
    //and is not inherited by any derived classes.
    public Fruit()
    {
        color = Color.red;
        Debug.Log("1st Fruit Constructor Called");
    }

    //This is the second constructor for the Fruit class
    //and is not inherited by any derived classes.
    public Fruit(Color newColor)
    {
        color = newColor;
        Debug.Log("2nd Fruit Constructor Called");
    }

    public void Chop()
    {
        Debug.Log("The " + color + " fruit has been chopped.");

        //GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //cylinder.transform.position = Vector3.zero;


    }

    public GameObject gometeo;

    public void instantiate()
    {
        gometeo = GameObject.Instantiate(GameObject.Find("meteospawn").GetComponent<fruitsalad>().meteo, new Vector3(Random.Range(-300.0f, 300.0f), Random.Range(-300.0f, 300.0f),
            Random.Range(-300.0f, 300.0f)), Quaternion.identity);

        gometeo.GetComponent<Renderer>().material.color = color;

    }

    virtual public void SayHello()
    {
        Debug.Log("Hello, I am a fruit.");


  

        /*
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        sphere.transform.position = new Vector3(Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f));
        sphere.GetComponent<Renderer>().material.color = color;

        int i = Random.Range(0, 1);

        sphere.gameObject.tag = i == 0 ? "Enemy" : "Player";


        sphere.AddComponent<colliderchecker>();
        Rigidbody rigid = sphere.AddComponent<Rigidbody>();

        rigid.mass = 0.01f;
        rigid.useGravity = false;

        Collider collider = sphere.GetComponent<CapsuleCollider>();
        collider.isTrigger = false;
        */
        
       // rigid.AddForce(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)), ForceMode.Force);




    }
}
public class Apple : Fruit
{
    //This is the first constructor for the Apple class.
    //It calls the parent constructor immediately, even
    //before it runs.
    public Apple()
    {
        //Notice how Apple has access to the public variable
        //color, which is a part of the parent Fruit class.
        color = Color.blue;
        Debug.Log("1st Apple Constructor Called");
    }

    //This is the second constructor for the Apple class.
    //It specifies which parent constructor will be called
    //using the "base" keyword.
    public Apple(Color newColor) : base(newColor)
    {
        //Notice how this constructor doesn't set the color
        //since the base constructor sets the color that
        //is passed as an argument.
        Debug.Log("2nd Apple Constructor Called");
    }

    override public void SayHello()
    {
        Debug.Log("Hello, I am a fruit.");

        /*
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        sphere.GetComponent<Renderer>().material.color = color;
        Collider collider = sphere.AddComponent<BoxCollider>();

  
        collider.isTrigger = false;
        //collider.bounds = 10f;
        */
    }
}

public class fruitsalad  : MonoBehaviour {

    

    Renderer render;

    public GameObject meteo;

    private void Awake()
    {
        render = this.transform.GetComponent<Renderer>();


    }

    private void Update()
    {
        
    }



    void Start()
    {
        //Let's illustrate inheritance with the 
        //default constructors.
      //  Debug.Log("Creating the fruit");
      //  Fruit myFruit = new Fruit();
      //  Debug.Log("Creating the apple");
      //  Apple myApple = new Apple();

      //  Fruit myFruitOver = myApple;

        //myFruitOver.SayHello();
        //myFruitOver.Chop();

        //Call the methods of the Fruit class.
        //myFruit.SayHello();
        //myFruit.Chop();

        //Call the methods of the Apple class.
        //Notice how class Apple has access to all
        //of the public methods of class Fruit.
        //myApple.SayHello();
        //myApple.Chop();

        //Now let's illustrate inheritance with the 
        //constructors that read in a string.
       // Debug.Log("Creating the fruit");
       // myFruit = new Fruit(Color.yellow);
        //Debug.Log("Creating the apple");
        //myApple = new Apple(Color.green);

        //Call the methods of the Fruit class.
        //myFruit.SayHello();
        //myFruit.Chop();

        List<Fruit> fruits = new List<Fruit>();
        for(int i=0; i<200; i++)
        fruits.Add(new Fruit(Color.cyan));

        foreach (Fruit fruit in fruits)
            fruit.instantiate();

        Random.seed = (int)System.DateTime.Now.Ticks;

        Debug.LogWarning(Random.seed + " : " + Random.value);

        float mag = 3000f;

        foreach (Fruit fruit in fruits)
            fruit.gometeo.GetComponent<Rigidbody>().AddForce(
                new Vector3(Random.Range(mag * -1, mag),
                Random.Range(mag * -1, mag),
                Random.Range(mag * -1, mag)),
                ForceMode.Force);

 

     
     

        //this.gameObject.GetComponent<Renderer>


        //Call the methods of the Apple class.
        //Notice how class Apple has access to all
        //of the public methods of class Fruit.
        //myApple.SayHello();
       // myApple.Chop();
    }

    

}