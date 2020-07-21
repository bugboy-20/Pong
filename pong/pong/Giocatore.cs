using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pong
{
    class Giocatore
    {

        public int x, y = 12, punti = 0;

        public Giocatore(int n)
        {

            if (n == 1)
                x = 0;
            else
                x = 119;
            for (int i = y; i < y+5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write('█');
            }

        }

        public void su()
        {
            y--;
            Console.SetCursorPosition(x, y);
            Console.Write("█");
            Console.SetCursorPosition(x, y + 5);
            Console.Write(" ");
        }

        public void giu()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            y++;
            Console.SetCursorPosition(x, y + 4);
            Console.Write("█");


        }

        public int colpita(int xp, int yp)
        {
            if (yp > y && yp < y + 5)
            {
                if (yp - y == 0)
                    return -45;
                if (yp - y == 1)
                    return -30;
                if (yp - y == 2)
                    return 0;
                if (yp - y == 3)
                    return 30;
                if (yp - y == 4)
                    return 45;
                return 420;//esiste perchè se no il compilatore brontola
            }
            else
                return 420;
        }
    }
}
