using UnityEngine;
namespace Assets.Scrits
{
   public interface IUSE
    {
        public Vector3 Move_Use(Chest_sc cheast, ref bool ismove);
        public void Use(Chest_sc cheast);
    }
}
