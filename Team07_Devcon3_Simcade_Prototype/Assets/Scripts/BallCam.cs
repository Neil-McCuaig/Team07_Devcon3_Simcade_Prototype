using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCam : MonoBehaviour
{
    [field: SerializeField] public Transform Target { get; private set; }

    [field: SerializeField] public float XOffset { get; private set; }

    [field: SerializeField] public float YOffset { get; private set; }

    [field: SerializeField] public float ZOffset { get; private set; }

    [field: SerializeField, Range(0f, 1f)] public float LookAtStrength { get; private set; } = 1f;

    Vector3 camStartPosition;

    private void Awake()
    {
        //camStartPosition = gameObject.transform.position;
        //LookAtStrength = 0f;
    }

    void Update()
    {
        if (GameObject.Find("Sphere").GetComponent<SoccerBallKick>().ballMobile == true)
        {
            SetPosition();
            LookAtTarget();
            //LookAtStrength = 1f;
        }
        else if (GameObject.Find("Sphere").GetComponent<SoccerBallKick>().ballMobile == false)
        {
            //LookAtStrength = 0f;
            transform.position = camStartPosition;
        }
    }

    //private void OnValidate()
    //{
        //float positionZ = ComputePositionZ();
        //bool isIncorrectPosition =
            //this.transform.position.x != XOffset ||
            //this.transform.position.y != YOffset ||
            //this.transform.position.z != positionZ;
        //if (GameObject.Find("Sphere").GetComponent<SoccerBallKick>().ballMobile == true)
        //{
            //if (isIncorrectPosition)
            //{
                //SetPosition();
                //LookAtTarget();
            //}
        //}
        //else 
        //{
            //transform.position = camStartPosition;
        //}

    //}

    private float ComputePositionZ()
    {
        if (Target == null)
            return 0;

        float positionZ = Target.position.z + ZOffset;
        return positionZ;
    }

    private void LookAtTarget()
    {
            if (Target == null)
                return;

            Vector3 position = Target.position;
            position.y = Mathf.Lerp(0, position.y, LookAtStrength);
            transform.LookAt(position);
    }

    private void SetPosition()
    {
            if (Target == null)
                return;

            Vector3 position = new Vector3();
            position.x = XOffset;
            position.y = YOffset;
            position.z = ComputePositionZ();
            transform.position = position;
    }
}
