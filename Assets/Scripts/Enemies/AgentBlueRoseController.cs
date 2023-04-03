public class AgentBlueRoseController : Enemy
{
    private void Start()
    {
        Speed = Data.AgentBlueRoseSpeed;
        Defense = Data.AgentBlueRoseDefense;
        ContactDamage = Data.AgentBlueRoseContactDamage;
        Experience = Data.AgentBlueRoseExperience;
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }
}
