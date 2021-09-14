using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrits
{
    public class action_cs : MonoBehaviour, IMove, IAttack,IHaracteristisc
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
            mp = 0;
        public bool isMelee = false;   

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

                case (IHaracteristisc.Race)3:
                    fiz_at += -20;
                    fiz_def += +20;
                    mag_at += -20;
                    mag_def += +20;
                    accuracy += 0;
                    evasion += 0;
                    speed += 0;
                    hp += 0;
                    mp += 0;
                    isMelee = true;
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

        public void hit_fiz(action_cs enemy)
        {
            if (this.accuracy - enemy.evasion > 0 || Random.Range(1, 100) == 1)
                enemy.hp -= this.fiz_at - enemy.fiz_def;
            else
                defence(enemy);

        }

        public void hit_mag(action_cs enemy)
        {
            if (this.accuracy - enemy.evasion > 0 || Random.Range(1, 100) == 1)
                enemy.hp -= this.mag_at - enemy.mag_def;
            else
                defence(enemy);
        }

        public void defence(action_cs enemy)
        {
            throw new System.NotImplementedException();
        }
    }
}
