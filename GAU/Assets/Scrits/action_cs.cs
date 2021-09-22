using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrits
{
    public class action_cs : MonoBehaviour, IMove, IAttack, IHaracteristisc,IUSE
    {
        public IHaracteristisc.Race race;
        public IHaracteristisc.Class clas;
        public int fiz_at = 0,
            fiz_def = 0,
            mag_at = 0,
            mag_def = 0,
            accuracy = 0,
            evasion = 0,
            speed = 0,
            hp = 0,
            mp = 0,
            r = 5;
        public bool isMelee = false;

        public int map_step = 1;
        public IMove.Pos _pos;

        public action_cs(IHaracteristisc.Race race, IHaracteristisc.Class clas, int fiz_at, int fiz_def, int mag_at, int mag_def,
            int accuracy, int evasion, int speed, int hp, int mp, bool isMelee)
        {
            this.race = race;
            this.clas = clas;
            this.fiz_at = fiz_at;
            this.fiz_def = fiz_def;
            this.mag_at = mag_at;
            this.mag_def = mag_def;
            this.accuracy = accuracy;
            this.evasion = evasion;
            this.speed = speed;
            this.hp = hp;
            this.mp = mp;
            this.isMelee = isMelee;
        }

        public action_cs(IHaracteristisc.Race race, IHaracteristisc.Class clas)
        {
            fiz_at = 0;
            fiz_def = 0;
            mag_at = 0;
            mag_def = 0;
            accuracy = 0;
            evasion = 0;
            speed = 0;
            hp = 0;
            mp = 0;
            isMelee = false;
            this.clas = clas;
            this.race = race;
            switch (clas)
            {
                case (IHaracteristisc.Class)0:
                    fiz_at += 120;
                    fiz_def += 60;
                    mag_at += 0;
                    mag_def += 30;
                    accuracy += 80;
                    evasion += 30;
                    speed += 0;
                    hp += 0;
                    mp += 0;
                    isMelee = true;
                    break;

                case (IHaracteristisc.Class)1:
                    fiz_at += 40;
                    fiz_def += 30;
                    mag_at += 120;
                    mag_def += 60;
                    accuracy += 100;
                    evasion += 30;
                    speed += 0;
                    hp += 0;
                    mp += 0;
                    isMelee = true;
                    break;

                case (IHaracteristisc.Class)2:
                    fiz_at += 100;
                    fiz_def += 40;
                    mag_at += 60;
                    mag_def += 40;
                    accuracy += 140;
                    evasion += 60;
                    speed += 0;
                    hp += 0;
                    mp += 0;
                    isMelee = true;
                    break;

                case (IHaracteristisc.Class)3:
                    fiz_at += 60;
                    fiz_def += 70;
                    mag_at += 40;
                    mag_def += 60;
                    accuracy += 60;
                    evasion += 20;
                    speed += 0;
                    hp += 0;
                    mp += 0;
                    isMelee = true;
                    break;
            }
            switch (race)
            {
                case (IHaracteristisc.Race)0:
                    fiz_at += 40;
                    fiz_def += 20;
                    mag_at += 0;
                    mag_def += 0;
                    accuracy += -20;
                    evasion += -20;
                    speed = 0;
                    hp += 0;
                    mp += 0;
                    isMelee = true;
                    break;

                case (IHaracteristisc.Race)1:
                    fiz_at += -20;
                    fiz_def += -20;
                    mag_at += +30;
                    mag_def += +30;
                    accuracy += 0;
                    evasion += 0;
                    speed = 0;
                    hp += 0;
                    mp += 0;
                    isMelee = true;
                    break;

                case (IHaracteristisc.Race)2:
                    fiz_at += +10;
                    fiz_def += +10;
                    mag_at += -30;
                    mag_def += +10;
                    accuracy += +40;
                    evasion += +20;
                    speed = 0;
                    hp += 0;
                    mp += 0;
                    break;

                default:
                    Debug.Log(race);
                    break;
            }
        }

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
                                map[i, j] = -1;
                                break;
                            case "Enemy(Clone)":
                                map[i, j] = -2;
                                break;
                            case "Chest(Clone)":
                                map[i, j] = -3;
                                break;
                            default:
                                Debug.Log(Map.map[i, j].GO.name);
                                break;
                        }
                }
            return map;
        }
        public Vector3 Move(int targetx, int targety, ref bool ismove)
        {
            int[,] map = Move_map();
            int x = _pos.x;
            int y = _pos.y;
            map_step = 1;

           
            if (Map.map[targetx, targety].GO == null)
                map[targetx, targety] = map_step;

            if (Map.map[targetx, targety].GO != null && Map.map[targetx, targety].GO.name == "Player")
                return Map.map[targetx, targety].GO.transform.position;
            Move_map(ref map, x, y, ref ismove);
            if (ismove)
            {
                if (x != targetx || y != targety)
                {

                    if (map[x + 1, y] == map[x, y] - 1)
                    {
                        x += 1;
                        ismove = true;
                    }
                    if (map[x - 1, y] == map[x, y] - 1)
                    {
                        x -= 1;
                        ismove = true;
                    }
                    if (map[x, y + 1] == map[x, y] - 1)
                    {
                        y += 1;
                        ismove = true;
                    }
                    if (map[x, y - 1] == map[x, y] - 1)
                    {
                        y -= 1;
                        ismove = true;
                    }
                }
                else ismove = false;
            }
            return Map.map[x, y].GetComponent<Transform>().position;
        }
        public void Move_map(ref int[,] map, int x, int y, ref bool ismove)
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
                if (map[x, y] > 0)
                {
                    move = false;
                }
                if (map_step > max_i * max_j)
                {
                    ismove = move = false;
                }

            }
        }

        public void hit_fiz(action_cs enemy)
        {
            Debug.Log("АТАКА!!");
            if (this.accuracy - enemy.evasion > 0 || Random.Range(1, 100) == 1)
                enemy.hp -= this.fiz_at - enemy.fiz_def;
            else
                defence(enemy);

        }

        public void hit_mag(action_cs enemy)
        {
            Debug.Log("МАГ. АТАКА!!");
            if (this.accuracy - enemy.evasion > 0 || Random.Range(1, 100) == 1)
                enemy.hp -= this.mag_at - enemy.mag_def;
            else
                defence(enemy);
        }

        public void defence(action_cs enemy)
        {
            Debug.Log("Уворот");
        }

        public Vector3 Attack(action_cs enemy, ref bool ismove)
        {
            int x, y;
            int targetx, targety;
            int min = int.MaxValue;
            if (isMelee)
            {
                targetx = x = enemy._pos.x;
                targety = y = enemy._pos.y;
                for (byte i = 0; i < 4; i++)
                {
                    bool move = true;
                    switch (i)
                    {
                        case 0:
                            Move(targetx + 1, targety, ref move);
                            if (min > map_step)
                            {
                                min = map_step;
                                x = targetx + 1;
                                y = targety;
                            }
                            break;
                        case 1:
                            Move(targetx - 1, targety, ref move);
                            if (min > map_step)
                            {
                                min = map_step;
                                x = targetx - 1;
                                y = targety;
                            }
                            break;
                        case 2:
                            Move(targetx, targety + 1, ref move);
                            if (min > map_step)
                            {
                                min = map_step;
                                x = targetx;
                                y = targety + 1;
                            }
                            break;
                        case 3:
                            Move(targetx, targety - 1, ref move);
                            if (min > map_step)
                            {
                                min = map_step;
                                x = targetx;
                                y = targety - 1;
                            }
                            break;
                    }

                }
                Vector3 Vec_move = Move(x, y, ref ismove);
                if (map_step <= 1)
                    hit_fiz(enemy);
                return Vec_move;
            }
            else
            {
                byte j = 1;
                targetx = x = enemy._pos.x;
                targety = y = enemy._pos.y;
                for (byte i = 0; i < 4; i++)
                    for (j = 1; j <= r; j++)
                    {
                        bool move = true;
                        switch (i)
                        {
                            case 0:
                                {
                                    Move(targetx + j, targety, ref move);
                                    if (min > map_step)
                                    {
                                        min = map_step;
                                        x = targetx + j;
                                        y = targety;
                                    }
                                }
                                break;
                            case 1:
                                Move(targetx - j, targety, ref move);
                                if (min > map_step)
                                {
                                    min = map_step;
                                    x = targetx - j;
                                    y = targety;
                                }
                                break;
                            case 2:
                                Move(targetx, targety + j, ref move);
                                if (min > map_step)
                                {
                                    min = map_step;
                                    x = targetx;
                                    y = targety + j;
                                }
                                break;
                            case 3:
                                Move(targetx, targety - j, ref move);
                                if (min > map_step)
                                {
                                    min = map_step;
                                    x = targetx;
                                    y = targety - j;
                                }
                                break;
                        }

                    }
                Vector3 Vec_move = Move(x, y, ref ismove);
                if (map_step <= r + 1)
                    hit_mag(enemy);
                return Vec_move;
            }

        }

        public Vector3 Move_Use(Chest_sc cheast, ref bool ismove)
        {
            int x, y;
            int targetx, targety;
            int min = int.MaxValue;          
                targetx = x = cheast._pos.x;
                targety = y = cheast._pos.y;
                for (byte i = 0; i < 4; i++)
                {
                    bool move = true;
                    switch (i)
                    {
                        case 0:
                            Move(targetx + 1, targety, ref move);
                            if (min > map_step)
                            {
                                min = map_step;
                                x = targetx + 1;
                                y = targety;
                            }
                            break;
                        case 1:
                            Move(targetx - 1, targety, ref move);
                            if (min > map_step)
                            {
                                min = map_step;
                                x = targetx - 1;
                                y = targety;
                            }
                            break;
                        case 2:
                            Move(targetx, targety + 1, ref move);
                            if (min > map_step)
                            {
                                min = map_step;
                                x = targetx;
                                y = targety + 1;
                            }
                            break;
                        case 3:
                            Move(targetx, targety - 1, ref move);
                            if (min > map_step)
                            {
                                min = map_step;
                                x = targetx;
                                y = targety - 1;
                            }
                            break;
                    }

                }
                Vector3 Vec_move = Move(x, y, ref ismove);
                if (map_step <= 1)
                    Use(cheast);
                return Vec_move;
            
        }

        public void Use(Chest_sc cheast)
        {
            Debug.Log("USE!!!");
        }
    }
}
