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
[System.Serializable]
public class MagicBarrierConfig
{
    public bool use;
    public int barrierHealth = 5;
}
public enum AbilityActivationMethod
{
    None,
    Round_End,
    FirstTime
}
#endregion

[CreateAssetMenu(menuName = "Habilidade/Nova Habilidade")]
public class Ability : Abilities
{
    public ProtectConfig protectConfig;
    public MagicBarrierConfig magicBarrierConfig;

    BasicEnemy enemyUser;
    public override void UseAbility(BasicEnemy enemyUser)
    {
        this.enemyUser = enemyUser;
        if (protectConfig.use) Protect();
        if(magicBarrierConfig.use) MagicBarrier();
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
    void MagicBarrier()
    {
        MagicBarrierController.instance.SpawnBarrier(enemyUser.transform, magicBarrierConfig.barrierHealth);
    }
}
