using UnityEngine;
using Battle.Abilities;

namespace Battle.Actors
{ 
    public class Actor
    {
        private IAbility[] Abilities;


        private string Name;
        public int Hp;
        public int Damage;
        private int MaxHp;

        public Actor(string name, int hp, int damage, IAbility[] abilities = null)
        {
            Abilities = abilities;
            Name = name;
            Hp = hp;
            Damage = damage;

            Initialize();
        }

        public void TakeDamage(Actor attaker)
        {
            Hp -= attaker.Damage;
            Log($"Was attakesd by {attaker.Name}");
        }

        public void PrintStatus()
        {
            if (IsDead())
                Log("Dead");
            else
                Log($"has {Hp}/{MaxHp} HP");
        }

        public void Log(string message)
        {
            Debug.Log($"{Name} : {message}");
        }

        private void Initialize()
        {
            MaxHp = Hp;
            Log("joins the fught");
        }

        public bool IsDead()
        {
            return Hp <= 0;
        }

        public virtual void UseAbility()
        {
            if (Abilities != null)
            {
                foreach (IAbility ability in Abilities)
                {
                    ability.Use(this);
                }
            }
        }
    }
}

