using Battle.Actors;

namespace Battle.Abilities
{
    public interface IAbility
    {
        void Use(Actor target);
    }
}