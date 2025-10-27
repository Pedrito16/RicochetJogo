using UnityEngine;

public abstract class Abilities : ScriptableObject
{
    public AbilityActivationMethod activationMethod;
    public virtual void UseAbility(BasicEnemy enemyUser)
    {

    }
}

#region Abilities Classes
[System.Serializable]
public class ProtectConfig
{
    public bool use;
    public int howManyRoundsProtected = 1;
}
public enum AbilityActivationMethod
{
    None,
    Round_End
}
#endregion

[CreateAssetMenu(menuName = "Habilidade/Nova Habilidade")]
public class Ability : Abilities
{
    public ProtectConfig protectConfig;

    BasicEnemy enemyUser;
    public override void UseAbility(BasicEnemy enemyUser)
    {
        this.enemyUser = enemyUser;
        if (protectConfig.use) Protect();
    }
    void Protect()
    {
        //implementar configurações de rounds
        enemyUser.canTakeDamage = !enemyUser.canTakeDamage;
        bool found = enemyUser.HasParameter("CanTakeDmg");
        if (found)
        {
            enemyUser.components.animator.SetBool("CanTakeDmg", enemyUser.canTakeDamage);
        }
    }
}
