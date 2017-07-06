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

    virtual public void SayHello()
    {
        Debug.Log("Hello, I am a fruit.");


  


        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        capsule.GetComponent<Renderer>().material.color = color;

        int i = Random.Range(0, 1);

        capsule.gameObject.tag = i == 0 ? "enemy" : "Player";


        capsule.AddComponent<colliderchecker>();
        Rigidbody rigid = capsule.AddComponent<Rigidbody>();
        
        rigid.mass = 0;
        rigid.useGravity = false;

        Collider collider = capsule.GetComponent<CapsuleCollider>();
        collider.isTrigger = true;


      
    
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

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        sphere.GetComponent<Renderer>().material.color = color;
        Collider collider = sphere.AddComponent<BoxCollider>();

  
        collider.isTrigger = false;
        //collider.bounds = 10f;

    }
}

public class NewBehaviourScript : MonoBehaviour {



    Renderer render;

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
        Debug.Log("Creating the fruit");
        Fruit myFruit = new Fruit();
        Debug.Log("Creating the apple");
        Apple myApple = new Apple();

        Fruit myFruitOver = myApple;

        myFruitOver.SayHello();
        myFruitOver.Chop();

        //Call the methods of the Fruit class.
        myFruit.SayHello();
        myFruit.Chop();

        //Call the methods of the Apple class.
        //Notice how class Apple has access to all
        //of the public methods of class Fruit.
        myApple.SayHello();
        myApple.Chop();

        //Now let's illustrate inheritance with the 
        //constructors that read in a string.
        Debug.Log("Creating the fruit");
        myFruit = new Fruit(Color.yellow);
        Debug.Log("Creating the apple");
        myApple = new Apple(Color.green);

        //Call the methods of the Fruit class.
        myFruit.SayHello();
        myFruit.Chop();

        List<Fruit> fruits = new List<Fruit>();
        for(int i=0; i<10; i++)
        fruits.Add(new Fruit(Color.black));

        foreach (Fruit fruit in fruits)
            fruit.SayHello();
                
        //this.gameObject.GetComponent<Renderer>


        //Call the methods of the Apple class.
        //Notice how class Apple has access to all
        //of the public methods of class Fruit.
        myApple.SayHello();
        myApple.Chop();
    }

    

}