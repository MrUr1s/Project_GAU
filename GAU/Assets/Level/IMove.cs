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
        public int[,] Move(int targetx, int targety);
        public void Move_map(ref int[,] map, int map_step, int x, int y);
    }
}
