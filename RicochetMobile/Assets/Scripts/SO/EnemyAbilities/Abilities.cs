using UnityEngine;
public enum AbilityActivationMethod
{
    None,
    Round_End,
    FirstTime
}
public abstract class Abilities : ScriptableObject
{
    public AbilityActivationMethod activationMethod;
    public virtual void UseAbility(BasicEnemy enemyUser)
    {

    }
}


