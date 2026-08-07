using UnityEngine;

public enum ZombieState
{
    Chasing,
    Attack,
    Dead
}

public class ZombieAI : MonoBehaviour
{
    private ZombieMovement movement;
    private ZombieCombat combat;
    private ZombieHealth health;
    private ZombieAnimationHandle animationHandle;

    private Transform player;

    private ZombieState currentState;

    public ZombieState CurrentState => currentState;

    private void Awake()
    {
        movement = GetComponent<ZombieMovement>();
        combat = GetComponent<ZombieCombat>();
        health = GetComponent<ZombieHealth>();
        animationHandle = GetComponent<ZombieAnimationHandle>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        ChangeState(ZombieState.Chasing);
    }

    private void Update()
    {
        switch (currentState)
        {
            case ZombieState.Chasing:
                movement.MoveTo(player);

                if (combat.IsPlayerInRange(player))
                    ChangeState(ZombieState.Attack);

                break;

            case ZombieState.Attack:

                movement.Stop();

                combat.Attack(player);

                if (!combat.IsPlayerInRange(player))
                    ChangeState(ZombieState.Chasing);

                break;

            case ZombieState.Dead:
                movement.Stop();
                break;
        }
    }

    public void ChangeState(ZombieState newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;

        switch (currentState)
        {
            case ZombieState.Chasing:
                animationHandle.PlayWalk();
                break;

            case ZombieState.Attack:
                animationHandle.PlayAttack();
                break;

            case ZombieState.Dead:
                animationHandle.PlayDead();
                break;
        }
    }

    public void ResetAI()
    {
        ChangeState(ZombieState.Chasing);
    }

}
