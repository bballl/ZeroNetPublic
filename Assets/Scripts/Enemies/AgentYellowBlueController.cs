public class AgentYellowBlueController : Enemy
{
    private void Start()
    {
        Speed = Data.AgentYellowBlueSpeed;
        Defense = Data.AgentYellowBlueDefense;
        ContactDamage= Data.AgentYellowBlueContactDamage;
        Experience= Data.AgentYellowBlueExperience;
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }
}