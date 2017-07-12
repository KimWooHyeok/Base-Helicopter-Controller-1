using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameController : MonoBehaviour
{
    public Text EngineForceView;
    public GameObject RestartButton;
   // public GameObject InfoButton;
  //  public GameObject InfoButton2;
  //  public GameObject InfoPanel;
  //  public GameObject InfoPanel2;
    public Text text;
    public HelicopterController helicontrol;
   
   


    // Use this for initialization
    public static UIGameController runtime;

    private void Awake()
    {
      //  InfoPanel2.SetActive(false);
        runtime = this;
    }

    void Start ()
	{
       
        ShowInfo();

	}
	
	// Update is called once per frame
	void Update () {

        EngineForceView.text = "Up Engine Foce : " + helicontrol.EngineForce.ToString()
            + "\nForward Engine Force : " + helicontrol.EngineForce2.ToString()
            + "\nRight Engine Force : " + helicontrol.EngineForce3.ToString();



        text.text = "목표 : 파괴 점수 달성 \n 현재 점수 : ";

    }


    public void Left ()
    {
        if (helicontrol.EngineForce3 > -0.01)
            helicontrol.EngineForce3 -= 0.002f;
    }

    public void Right()
    {
        if (helicontrol.EngineForce3 < 0.01)
            helicontrol.EngineForce3 += 0.002f;
    }

    public void Up()
    {
        if (helicontrol.EngineForce < 2)
            helicontrol.EngineForce += 0.4f;
    }

    public void Down()
    {
        if (helicontrol.EngineForce > -2)
            helicontrol.EngineForce -= 0.4f;
    }

    public void Forward()
    {
        if (helicontrol.EngineForce2 < 3)
            helicontrol.EngineForce2 += 0.5f;
    }

    public void Back()
    {
        if (helicontrol.EngineForce2 > -1)
            helicontrol.EngineForce2 -= 0.2f;
    }

    private void ShowInfoPanel(bool isShow)
    {
        EngineForceView.gameObject.SetActive(!isShow);
        RestartButton.SetActive(!isShow);
      //  InfoButton.SetActive(!isShow);
    //    InfoPanel.SetActive(isShow);
    }

    public void ShowInfo()
    {

     //   InfoPanel.SetActive(true);
    //    InfoPanel2.SetActive(false);
        //ShowInfoPanel(true);
    }
    public void HideInfo()
    {

        //InfoPanel.SetActive(false);
       // InfoPanel2.SetActive(true);

        //ShowInfoPanel(false);
    }

    public void RestartGame()
    {
        Application.LoadLevel("Project");
    }
}
