using System.Collections;
using UnityEngine;

public class AgentYellowGunnerController : AgentGunner
{
    [SerializeField] private Transform bulletStartPosition;

    private void Start()
    {
        Speed = Data.AgentYellowGunnerSpeed;
        Defense = Data.AgentYellowGunnerDefense;
        ContactDamage = Data.AgentYellowGunnerContactDamage;
        Experience = Data.AgentYellowGunnerExperience;

        ChangeState();
    }

    private void FixedUpdate()
    {
        MoveToWayPoint();
    }

    /// <summary>
    /// Выстрел.
    /// </summary>
    private void Shot()
    {
        ShootLogic(bulletStartPosition);
    }

    /// <summary>
    /// Изменение состояния. Состояния описаны в enum AgentGunnerState.
    /// </summary>
    private void ChangeState()
    {
        CurrentState++;
        if (CurrentState > AgentGunnerState.Shooting)
        {
            CurrentState = 0;
        }

        switch (CurrentState)
        {
            case AgentGunnerState.None:
                WaitTime = 1f;
                StartCoroutine(Delay());
                break;

            case AgentGunnerState.Move:
                GetNewDirection();
                WaitTime = 5f;
                StartCoroutine(Delay());
                break;

            case AgentGunnerState.GunGuidance:
                transform.LookAt(PlayerTransform);
                WaitTime = 0.35f;
                StartCoroutine(Delay());
                break;

            case AgentGunnerState.Shooting:
                Shot();
                WaitTime = 1f;
                StartCoroutine(Delay());
                break;
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(WaitTime);
        ChangeState();
    }
}
