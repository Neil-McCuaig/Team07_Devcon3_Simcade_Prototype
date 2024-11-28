using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [field: SerializeField] public Rigidbody SoccerBallRB { get; private set; }
    [field: SerializeField] public float KickForce { get; private set; } = 40;
    [field: SerializeField] public float KickSpinForce { get; private set; } = 1;
    [field: SerializeField] public bool DoKickBall { get; private set; }
    [field: SerializeField] public KeyCode KickKey { get; private set; } = KeyCode.B;


    private void Awake()
    {
        if (SoccerBallRB == null)
        {
            string msg = $"Missing Component {nameof(Rigidbody)} {nameof(SoccerBallRB)}.";
            throw new MissingComponentException(msg);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KickKey))
        {
            DoKickBall = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        {
            if (!DoKickBall)
                return;
            DoKickBall = false;

            Vector3 kickDirection = SoccerBallRB.transform.forward;
            Vector3 force = KickForce * kickDirection;
            SoccerBallRB.AddForce(force, ForceMode.Impulse);
        }


    }

    private void Reset()
    {
        if (SoccerBallRB == null)
            SoccerBallRB = GetComponent<Rigidbody>();
    }
}
