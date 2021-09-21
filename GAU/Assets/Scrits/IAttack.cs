using UnityEngine;
namespace Assets.Scrits
{
    public interface IAttack
    {
        public Vector3 Attack(action_cs enemy,ref bool ismove);
        public void hit_fiz(action_cs enemy);
        public void hit_mag(action_cs enemy);
        public void defence(action_cs enemy);

    }
}
