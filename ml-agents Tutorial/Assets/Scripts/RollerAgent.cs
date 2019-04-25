using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
public class RollerAgent : Agent
{
    public Transform target;
    private Rigidbody rBody;

    public float speed = 10;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    public override void AgentReset()
    {
        if (transform.position.y < 0)
        {
            rBody.angularVelocity = Vector3.zero;
            rBody.velocity = Vector3.zero;
            transform.position = new Vector3(0, 0.5f, 0);
        }
        // 리셋 초기 위치를 랜덤으로 함
        target.position = new Vector3(Random.value * 8 - 4, 0.5f, Random.value * 8 - 4);
    }

    public override void CollectObservations()
    {
        // 좌표값을 state로 사용
        // 떨어질 때 y값도 변하므로 Vector3 모두를 사용함
        AddVectorObs(target.position);
        AddVectorObs(transform.position);

        // 속도값을 state로 사용
        AddVectorObs(rBody.velocity.x);
        AddVectorObs(rBody.velocity.z);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // vectorAction은 최초에 임의 값으로 들어오고 Brain은 이게 무슨 의미인지 아예 모름
        // 이게 학습을 거치면서 방향을 의미한다는걸 알게 될 것
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.z = vectorAction[1];

        rBody.AddForce(controlSignal * speed);

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Target에 도달했을때 리워드 1.0
        if (distanceToTarget < 1.42f)
        {
            SetReward(1.0f);
            Done();
        }

        // 떨어졌을 때 Done()
        if (transform.position.y < 0)
        {
            Done();
        }
    }    
}
