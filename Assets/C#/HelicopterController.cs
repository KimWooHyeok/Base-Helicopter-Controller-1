using UnityEngine;
using UnityEngine.UI;

public class HelicopterController : MonoBehaviour
{
    public AudioSource HelicopterSound;
    public ControlPanel ControlPanel;
    public Rigidbody HelicopterModel;

    public float TurnForce = 0.03f;
    public float SwingForce = 1f;
    public float ForwardForce = 0.05f;
    public float ForwardTiltForce = 20f;
    public float TurnTiltForce = 30f;
    public float EffectiveHeight = 100f;

    public float turnTiltForcePercent = 1.5f;
    public float turnForcePercent = 1.3f;

    public bool isturn = false;

    [SerializeField]
    private float _engineForce;
    public float EngineForce;
    public float EngineForce2;
    public float EngineForce3;
    /*
    {
        
        get { return _engineForce; }
        set
        {
            HelicopterSound.pitch = Mathf.Clamp(value / 40, 0, 1.2f);
            if (UIGameController.runtime.EngineForceView != null)
                UIGameController.runtime.EngineForceView.text = string.Format("Engine value [ {0} ] ", (int)value);

            _engineForce = value;
        }
    }*/

    public Vector2 hMove = Vector2.zero;
    private Vector2 hTilt = Vector2.zero;
    private float hTurn = 0f;
    public bool IsOnGround = true;
    public bool IsKeyInput = false;

    // Use this for initialization
	void Start ()
	{
        ControlPanel.KeyPressed += OnKeyPressed;
	}

	void Update () {
	}
  
    void FixedUpdate()
    {
        //LiftProcess();
        MoveProcess();
        TiltProcess();
        //SwingProcess();
    }

    private void MoveProcess()
    {


        var turn = TurnForce * Mathf.Lerp(hMove.x, hMove.x * (turnTiltForcePercent - Mathf.Abs(hMove.y)), Mathf.Max(0f, hMove.y));  // 첫번째 값과 두번째 값을 세번째 값의 비율에 맞도록 가져온다.

        //값을 보간하고 시간에 비례해서 한번더 보간을한다.

        hTurn = Mathf.Lerp(hTurn, turn, Time.fixedDeltaTime * TurnForce);   //turnforce = 스피드, hmove = 이동, hturn = 회전.


        //if(isturn)
        //HelicopterModel.AddRelativeTorque(0f, hTurn * HelicopterModel.mass, 0f);
        //else
        //HelicopterModel.AddRelativeTorque(0f, 0f, 0f);

        //HelicopterModel.AddRelativeForce(transform.forward * Mathf.Max(hMove.y * ForwardForce * HelicopterModel.mass));   // 실질적으로 이동하는부분. 위의 세 줄은 회전을 처리한다.


        HelicopterModel.AddRelativeTorque(0f, EngineForce3 , 0f);
        HelicopterModel.AddRelativeForce(Vector3.forward * EngineForce2);
        HelicopterModel.AddRelativeForce(Vector3.up * EngineForce);
    }

    private void LiftProcess()  // 현재는 사용안함. 위로 올라갔다 내려갔다
    {
        var upForce = 1 - Mathf.Clamp(HelicopterModel.transform.position.y / EffectiveHeight, 0, 1);
        upForce = Mathf.Lerp(0f, EngineForce, upForce) * HelicopterModel.mass;
        HelicopterModel.AddRelativeForce(Vector3.up * EngineForce);
    }

    private void SwingProcess()
    {
        

      
        
        HelicopterModel.AddRelativeForce(transform.right * Mathf.Max(0f, hMove.x * SwingForce * HelicopterModel.mass));   // 실질적으로 이동하는부분. 위의 세 줄은 회전을 처리한다.
    }


    private void TiltProcess()
    {
        hTilt.x = Mathf.Lerp(hTilt.x, hMove.x * TurnTiltForce, Time.deltaTime); // Lerp 사용하면 시간변화에따라 점진적으로 각을 틔워준다.
        hTilt.y = Mathf.Lerp(hTilt.y, hMove.y * ForwardTiltForce, Time.deltaTime);
        HelicopterModel.transform.localRotation = Quaternion.Euler(hTilt.y, HelicopterModel.transform.localEulerAngles.y, -hTilt.x);
    }

    private void OnKeyPressed(PressedKeyCode[] obj) // 배열에서 입력받은 키를 하나씩 가져온다.
    {

        

        if (!IsKeyInput) return;    // 플레이어만 움직이기 위해 추가한 조건.

        float tempY = 0;
        float tempX = 0;

        // stable forward
        if (hMove.y > 0)
            tempY = -Time.fixedDeltaTime;
        else
            if (hMove.y < 0)
            tempY = Time.fixedDeltaTime;

        
        // stable lurn
        if (hMove.x > 0)
            tempX = -Time.fixedDeltaTime;
        else
            if (hMove.x < 0)
            tempX = Time.fixedDeltaTime;



        foreach (var pressedKeyCode in obj) // 하나씩 배열에서 꺼내온다.
        {
            switch (pressedKeyCode)
            {
                case PressedKeyCode.SpeedUpPressed:
                    if(EngineForce < 2)
                    EngineForce += 0.02f;
                    
                    break;

                case PressedKeyCode.SpeedDownPressed:
                    if (EngineForce > -2)
                        EngineForce -= 0.02f;
                    //if (EngineForce < 0) EngineForce = 0;
                    break;

                case PressedKeyCode.ForwardPressed:
                    //if (IsOnGround) break;

                    if (EngineForce2 < 3)
                        EngineForce2 += 0.1f;
                    tempY = Time.fixedDeltaTime;
                    break;

                case PressedKeyCode.BackPressed:
                    //if (IsOnGround) break;

                    if (EngineForce2 > -1)
                        EngineForce2 -= 0.07f;
                    //isturn = false;
                    tempY = -Time.fixedDeltaTime;
                    break;

                case PressedKeyCode.LeftPressed:
                    //if (IsOnGround) break;

                    if (EngineForce3 > -0.01)
                        EngineForce3 -= 0.0003f;

                    
                    //isturn = true;
                    tempX = -Time.fixedDeltaTime;
                    break;

                case PressedKeyCode.RightPressed:
                    //if (IsOnGround) break;
                    if (EngineForce3 < 0.01)
                        EngineForce3 += 0.0003f;
                    //isturn = true;
                    tempX = Time.fixedDeltaTime;
                    break;

                case PressedKeyCode.TurnRightPressed:
                    {
                   
                        // if (IsOnGround) break;
                        var force = (turnForcePercent - Mathf.Abs(hMove.y)) * HelicopterModel.mass;
                        HelicopterModel.AddRelativeTorque(0f, force, 0);    // 힘을 지역적으로 준다(다른걸로 월드로도 줄 수 있음)
                    }
                    break;

                case PressedKeyCode.TurnLeftPressed:
                    {
                        //  if (IsOnGround) break;
                      
                        var force = -(turnForcePercent - Mathf.Abs(hMove.y)) * HelicopterModel.mass;
                        HelicopterModel.AddRelativeTorque(0f, force, 0);
                    }
                    break;
            }
        }

        
            hMove.x += tempX;
            hMove.x = Mathf.Clamp(hMove.x, -1, 1);  // clamp는 수치를 -1~1 사이로 보간시켜준다.

        
        

        hMove.y += tempY;
        hMove.y = Mathf.Clamp(hMove.y, -1, 1);
       
        
    }

    private void OnCollisionEnter()
    {
        IsOnGround = true;
    }

    private void OnCollisionExit()
    {
        IsOnGround = false;
    }
}