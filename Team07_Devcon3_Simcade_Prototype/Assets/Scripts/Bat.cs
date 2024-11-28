using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [field: SerializeField] public Rigidbody ball { get; private set; }
    [field: SerializeField] public float KickForce { get; private set; } = 20;
    [field: SerializeField] public float UpForce { get; private set; } = 15;
    [field: SerializeField] public float KickSpinForce { get; private set; } = 2;
    [field: SerializeField] public bool DoKickBall { get; private set; }
    [field: SerializeField] public KeyCode KickKey { get; private set; } = KeyCode.B;


    private void Awake()
    {
        if (ball == null)
        {
            string msg = $"Missing Component {nameof(Rigidbody)} {nameof(ball)}.";
            throw new MissingComponentException(msg);
        }
    }

    private void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    { 
        {
            if (Input.GetKeyDown(KickKey))
        {
            DoKickBall = true;
        }
            if (DoKickBall == true)
            {
                Vector3 kickDirection = ball.transform.forward;
                Vector3 batdirection = ball.transform.up;
                Vector3 force = KickForce * kickDirection;
                Vector3 batforce = UpForce * batdirection;
                ball.AddForce(force, ForceMode.Impulse);
                ball.AddForce(batforce, ForceMode.Impulse);
            }
            }
        }


    }
