using UnityEngine;
using Battle.Abilities;

namespace Battle.Actors
{
    public class Game : MonoBehaviour
    {
        private void Start()
        {
            Actor hero = new Actor("Joseph", 100, 20, new IAbility[] { new DamageBuff(5), new HpBuff(2) });
            Actor[] enemies = 
            { 
                new Actor("Kars", 30, 10, new IAbility[] { new HpBuff(4) }), 
                new Actor("Esidisi", 40, 15, new IAbility[] { new HpBuff(5), new DamageBuff(5) }), 
                new Actor("Wamuu", 30, 15, new IAbility[] { new DamageBuff(7), new HpBuff(4) }) 
            };

            Debug.Log("Fight!");

            for (int buttleTrun = 1; buttleTrun < 5; buttleTrun++)
            {
                Debug.Log($"{buttleTrun} Turn");

                bool isHeroDead = false;
                bool isAllEnemiesDead = true;

                foreach (Actor enemy in enemies)
                {
                    if (enemy.IsDead()) continue;

                    enemy.UseAbility();

                    if (isHeroDead) break;

                    hero.UseAbility();
                    var isEnemyDeaed = Attack(hero, enemy);
                    isAllEnemiesDead = isAllEnemiesDead && isEnemyDeaed;
                }

                if (isHeroDead || isAllEnemiesDead) break;

            }
        }

        bool Attack(Actor attacker, Actor defender)
        {
            defender.TakeDamage(attacker);
            defender.PrintStatus();

            return defender.IsDead();
        }
    }

}
