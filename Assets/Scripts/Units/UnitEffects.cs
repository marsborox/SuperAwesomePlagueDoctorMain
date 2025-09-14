using System.Collections.Generic;

using UnityEngine;

public class UnitEffects : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    List<Effect_SO> activeEffectList = new List<Effect_SO>();
    public void AddEffect(Effect_SO effect)
    {
        activeEffectList.Add(effect);
    }
    void ApplyEffects()
    {
        foreach (Effect_SO effect in activeEffectList)
        { 
            effect.ApplyEffect();
        }
    }
}
