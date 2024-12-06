using UnityEngine;

public class SoccerBallKick : MonoBehaviour
{
    [field: SerializeField] public Rigidbody SoccerBallRB { get; private set; }
    [field: SerializeField] public float KickForce { get; private set; } = 10;
    [field: SerializeField] public float KickSpinForce { get; private set; } = 1;
    [field: SerializeField] public bool DoKickBall { get; private set; }
    [field: SerializeField] public KeyCode KickKey { get; private set; } = KeyCode.Space;
    [field: SerializeField] public int ballCount = 0;
    Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = gameObject.transform.position;
        if (SoccerBallRB == null)
        {
            string msg = $"Missing Component {nameof(Rigidbody)} {nameof(SoccerBallRB)}.";
            throw new MissingComponentException(msg);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KickKey) == ballCount <= 3)
        {
            DoKickBall = true;
            ballCount++;
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


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Boarder")
        {
            transform.position = originalPosition;
            Vector3 stopDirection = -SoccerBallRB.transform.forward;
            Vector3 stopForce = KickForce * stopDirection;
            SoccerBallRB.AddForce(stopForce, ForceMode.Impulse);
        }
        else if (other.gameObject.name == "Missed Ball Collision")
        {
            transform.position = originalPosition;
            Vector3 stopDirection = -SoccerBallRB.transform.forward;
            Vector3 stopForce = KickForce * stopDirection;
            SoccerBallRB.AddForce(stopForce, ForceMode.Impulse);
        }
    }

    private void Reset()
    {
        if (SoccerBallRB == null)
            SoccerBallRB = GetComponent<Rigidbody>();
    }


}
