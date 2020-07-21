using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace pong
{
    class Palla
    {
        public int x, y, d, v, vel = 20;//x, y, direzione, verso, velocità;
        public bool pausa = true;
        private double drad, xd, yd;
        Program gioco = new Program();
        Random rnd = new Random();
        char[,] sfondo;
        public Palla(char[,] m)
        {
            sfondo = m;
            rimessa();
        }
        public void muovi()
        {
            while (true)
            {
                if (pausa == false)
                {

                    doing();

                    drad = Math.PI * d / 180;
                    punta();
                    Console.Write(sfondo[y, x]);

                    if (v == 1)
                    {
                        xd += 2 * Math.Cos(drad);
                        yd += Math.Sin(drad);
                    }
                    else
                    {
                        xd -= 2 * Math.Cos(drad);
                        yd += Math.Sin(drad);
                    }

                    x = Convert.ToInt32(xd);
                    y = Convert.ToInt32(yd);
                    punta();
                    Console.Write("O");
                    gioco.contatto();
                    Console.SetCursorPosition(60, 29);
                    if (vel < 220)
                        Thread.Sleep(200 - vel);
                    else
                    {
                        Console.SetCursorPosition(56, 15);
                        Console.WriteLine("PAREGGIO");
                        rimessa();
                    }
                    //Console.Write(" d={0} v={1} vel={2} ",d,v,vel);
                }
            }
        }
        public void rimessa()
        {
            xd = 60;
            yd = 15;
            d = rnd.Next(1, 5);

            if (d == 1)
                d = 45;
            if (d == 2)
                d = 30;
            if (d == 3)
                d = 0;
            if (d == 4)
                d = -30;
            if (d == 5)
                d = -45;

            v = rnd.Next(0, 1);
            if (v == 0)
                v = -1;

            vel = 0;

            if (v == -1)
                gioco.ricevente = false;
            else
                gioco.ricevente = true;

            Console.SetCursorPosition(0, 29);
        }
        void doing()
        {
            if (y < 1 || y > 28)
            {
                d = d * (-1);
            }
            if (x < 1 || x > 119)
            {
                v = v * (-1);
            }

        }
        void punta()
        {
            if (x < 0 || x > 119 || y < 0 || y > 29)
            {
                if (x < 0)
                    x = 0;
                if (x > 119)
                    x = 119;
                if (y < 0)
                    y = 0;
                if (y > 29)
                    y = 29;
                //Console.Write("correzione di rotta");
            }
            Console.SetCursorPosition(x, y);
        }
    }
}
