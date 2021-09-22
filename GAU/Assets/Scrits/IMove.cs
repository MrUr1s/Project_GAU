using UnityEngine;
namespace Assets.Scrits
{
    public interface IMove
    {
        public struct Pos
        {
            public int x;
            public int y;
        }
        int[,] Move_map();
        public Vector3 Move(int targetx, int targety,ref bool ismove);
        public void Move_map(ref int[,] map, int x, int y,ref bool ismove);
    }
}
