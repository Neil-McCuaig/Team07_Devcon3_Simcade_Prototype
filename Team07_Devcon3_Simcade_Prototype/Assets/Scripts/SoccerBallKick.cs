using UnityEngine;
using UnityEngine.SceneManagement;

public class SoccerBallKick : MonoBehaviour
{
    [field: SerializeField] public Rigidbody SoccerBallRB { get; private set; }
    [field: SerializeField] public float KickForce { get; private set; } = 10;
    [field: SerializeField] public float KickSpinForce { get; private set; } = 1;
    [field: SerializeField] public bool DoKickBall { get; private set; }
    [field: SerializeField] public KeyCode KickKey { get; private set; } = KeyCode.Space;

    [field: SerializeField] public int ballCount = 0;

    Vector3 originalPosition;
    [field: SerializeField] public KeyCode ResetKey { get; private set; } = KeyCode.U;

    [field: SerializeField] public bool ballMobile;

    private void Awake()
    {
        ballMobile = false;
        originalPosition = gameObject.transform.position;
        if (SoccerBallRB == null)
        {
            string msg = $"Missing Component {nameof(Rigidbody)} {nameof(SoccerBallRB)}.";
            throw new MissingComponentException(msg);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KickKey) && ballCount <= 3)
        {
            DoKickBall = true;
            ballCount++;
            ballMobile = true;
        }

        if (Input.GetKeyDown(ResetKey))
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    public void FixedUpdate()
    {
        if (!DoKickBall)
            return;
        DoKickBall = false;

        Vector3 kickDirection = SoccerBallRB.transform.forward;
        Vector3 force = KickForce * kickDirection;
        SoccerBallRB.AddForce(force, ForceMode.Impulse);
        SoccerBallRB.useGravity = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Boarder")
        {
            SoccerBallRB.useGravity = false;
            transform.position = originalPosition;
            //Vector3 stopDirection = -SoccerBallRB.transform.forward;
            //Vector3 stopForce = KickForce * stopDirection;
            //SoccerBallRB.AddForce(stopForce, ForceMode.Impulse);
            SoccerBallRB.velocity = Vector3.zero;
            SoccerBallRB.angularVelocity = Vector3.zero;
            ballMobile = false;
        }
        else if (other.gameObject.name == "Missed Ball Collision")
        {
            SoccerBallRB.useGravity = false;
            transform.position = originalPosition;
            //Vector3 stopDirection = -SoccerBallRB.transform.forward;
            //Vector3 stopForce = KickForce * stopDirection;
            //SoccerBallRB.AddForce(stopForce, ForceMode.Impulse);
            SoccerBallRB.velocity = Vector3.zero;
            SoccerBallRB.angularVelocity = Vector3.zero;
            ballMobile = false;
        }
    }

    private void Reset()
    {
        if (SoccerBallRB == null)
            SoccerBallRB = GetComponent<Rigidbody>();
    }


}
