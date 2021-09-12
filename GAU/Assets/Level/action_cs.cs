using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrits
{
    public class action_cs : MonoBehaviour, IMove, IAttack
    {
        public IMove.Pos _pos;
        public int[,] Move_map()
        {
            int x = Map.map.GetUpperBound(0) + 1;
            int y = Map.map.GetUpperBound(1) + 1;
            int[,] map = new int[x, y];
            for (int j = 0; j < y; j++)
                for (int i = 0; i < x; i++)
                {
                    map[i, j] = 0;
                    if (Map.map[i, j].GO != null)
                        switch (Map.map[i, j].GO.name)
                        {
                            case "Player":
                                map[i, j] = 0;
                                _pos.x = i;
                                _pos.y = j;
                                break;
                            case "H_Wall(Clone)":
                                map[i, j] = -2;
                                break;
                            case "Enemy(Clone)":
                                map[i, j] = -1;
                                break;
                            default:
                                Debug.Log(Map.map[i, j].GO.name);
                                break;
                        }
                }
            return map;
        }
        public int[,] Move(int targetx, int targety)
        {
            int[,] map = Move_map();
            int x = _pos.x;
            int y = _pos.y;

            int map_step = 1;
            map[targetx, targety] = map_step;
            Move_map(ref map, map_step, x, y);
            return map;
        }
        public void Move_map(ref int[,] map, int map_step, int x, int y)
        {
            int max_i = map.GetUpperBound(0) + 1;
            int max_j = map.GetUpperBound(1) + 1;
            bool move = true;
            while (move)
            {
                for (int j = 0; j < max_j; j++)
                    for (int i = 0; i < max_i; i++)
                        if (map[i, j] == map_step)
                        {
                            if (i + 1 < max_i && map[i + 1, j] == 0)
                                map[i + 1, j] = map_step + 1;

                            if (i - 1 > 0 && map[i - 1, j] == 0)
                                map[i - 1, j] = map_step + 1;

                            if (j + 1 < max_j && map[i, j + 1] == 0)
                                map[i, j + 1] = map_step + 1;

                            if (j - 1 > 0 && map[i, j - 1] == 0)
                                map[i, j - 1] = map_step + 1;
                        }

                map_step += 1;
                if (map[x, y] > 0 || map_step > max_i * max_j)
                {
                    move = false;
                }

            }
        }
    }
}
