using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace pong
{
    class Program
    {

        static char[,] sfondo = new char[30,120];
        static Palla p;
        static Giocatore g1;
        static Giocatore g2;
        
        public bool ricevente; //true = g1 false= g2

        static void Main(string[] args)
        {
            intro();

            for (int i = 0; i < sfondo.GetLength(0); i++)
            {
                for (int j = 0; j < sfondo.GetLength(1); j++)
                {
                    Console.Write(sfondo[i, j]);
                }
            }

            System.ConsoleKey key;
            g1 = new Giocatore(1);
            g2 = new Giocatore(2);
            p = new Palla(sfondo);
            
            punteggio();

            Thread th = new Thread(p.muovi);
            th.Start();

            p.pausa = false;
            
            while (true)
            {
                key = Console.ReadKey().Key;

                if (key == ConsoleKey.W && g1.y > 0)
                {
                    g1.su();
                }
                if (key == ConsoleKey.S && g1.y < 24)
                {
                    g1.giu();
                }
                if (key == ConsoleKey.DownArrow && g2.y < 24)
                {
                    g2.giu();
                }
                if (key == ConsoleKey.UpArrow && g2.y > 0)
                {
                    g2.su();
                }
                /*if (key == ConsoleKey.R)
                {
                    p.rimessa();
                }*/
                if (key == ConsoleKey.P)
                {
                    
                    p.pausa = true;
                    Console.SetCursorPosition(58, 14);
                    Console.Write("PAUSA");
                    Console.SetCursorPosition(60, 29);
                    Console.ReadKey();

                    Console.SetCursorPosition(58, 14);
                    for (int i = 58; i < 63; i++)
                    {
                        Console.Write(sfondo[14, i]);
                    }
                    p.pausa = false;
                }
                

                Console.SetCursorPosition(60, 29);


                
                

            }
        }

        public void contatto()
        {
            if (p.x <= 1 && ricevente)
            {
                if (g1.colpita(p.x, p.y)!=420)
                {
                    p.v = p.v * (-1);
                    p.d = g1.colpita(p.x, p.y);
                    p.vel += 20;
                }
                else
                {
                    g2.punti++;
                    if (g2.punti == 10)
                        gameoiver();
                    else
                    {

                        p.rimessa();
                        punteggio();
                    }
                }
                
            }

            if (p.x >= 118 && !ricevente)
            {
                if (g2.colpita(p.x, p.y)!=420)
                {
                    p.v = p.v * (-1);
                    p.d = g2.colpita(p.x, p.y);
                    p.vel += 20;
                }
                else
                {
                    g1.punti++;
                    if (g1.punti == 10)
                        gameoiver();
                    else
                    {
                        p.rimessa();
                        punteggio();
                    }
                }
            }
            ricevente = !ricevente;//forse non va messo qui
        }
        static void punteggio()
        {
            Console.SetCursorPosition(57, 1);
            Console.WriteLine(g1.punti + " - " + g2.punti);
        }
        static void intro()
        {//fatto prima dell'impaginatore
            int r=32,c=3;
            Console.SetCursorPosition(r,c);             Console.Write(",ggggggggggg,                                      "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("dP\"\"\"88\"\"\"\"\"\"Y8,                                    "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("Yb,  88      `8b                                    "); c++;
            Console.SetCursorPosition(r,c);             Console.Write(" `\"  88      ,8P                                    "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("     88aaaad8P\"                                     "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("     88\"\"\"\"\"    ,ggggg,     ,ggg,,ggg,     ,gggg,gg "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("     88        dP\"  \"Y8ggg ,8\" \"8P\" \"8,   dP\"  \"Y8I "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("     88       i8'    ,8I   I8   8I   8I  i8'    ,8I "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("     88      ,d8,   ,d8'  ,dP   8I   Yb,,d8,   ,d8I "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("     88      P\"Y8888P\"    8P'   8I   `Y8P\"Y8888P\"888"); c++;
            Console.SetCursorPosition(r,c);             Console.Write("                                               ,d8I'"); c++;
            Console.SetCursorPosition(r,c);             Console.Write("                                             ,dP'8I "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("                                            ,8\"  8I "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("                                            I8   8I "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("                                            `8, ,8I "); c++;
            Console.SetCursorPosition(r,c);             Console.Write("                                             `Y8P\"  ");
            Console.SetCursorPosition(45, c + 2);       Console.Write("Premi per cominciare...");
            Console.SetCursorPosition(0, 28);           Console.Write("Premi [H] per le regole...\n...[I] per le impostazioni\t\t\t\t\t\t\t[C] per il codice sorgente contattatemi");

            for (int i = 0; i < sfondo.GetLength(0); i++)
            {
                for (int j = 0; j < sfondo.GetLength(1); j++)
                {
                    if (i == 0 || i == 29)
                        sfondo[i, j] = '-';
                    else
                    {
                        if (j == 59)
                            sfondo[i, j] = '|';
                        else
                            sfondo[i, j] = ' ';
                    }
                }
            }

            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.H)
                help();
            else if (key == ConsoleKey.C)
                crediti();
            else if (key == ConsoleKey.I)
                impostazioni();

            Console.Clear();
            

        }
        static void help()
        {
            Console.Clear();
            int r, c;
            for (int i = 0; i < sfondo.GetLength(0); i++)
            {
                for (int j = 0; j < sfondo.GetLength(1); j++)
                {
                    Console.Write(sfondo[i, j]);
                }
            }
            
            for (int i = 12; i < 17; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('█');
            }

            for (int i = 7; i < 12; i++)
            {
                Console.SetCursorPosition(119, i);
                Console.Write('█');
            }
            Console.SetCursorPosition(0, 11);
            Console.Write("^");
            Console.SetCursorPosition(4, 11);
            Console.Write("[W] per muoverti verso l'alto");

            Console.SetCursorPosition(119, 6);
            Console.Write("^");
            Console.SetCursorPosition(70, 6);
            Console.Write("[^] per muoverti verso l'alto");

            Console.SetCursorPosition(0, 17);
            Console.Write("V");
            Console.SetCursorPosition(4, 17);
            Console.Write("[S] per muoverti verso il basso");

            Console.SetCursorPosition(119, 12);
            Console.Write("V");
            Console.SetCursorPosition(70, 12);
            Console.Write("[V] per muoverti verso il basso");

            c = 100;
            for (r = 7; r > 0;r--)
            {
                
                Console.SetCursorPosition(c, r);
                Console.Write(".");
                c++;
            }
            for (c = c; c < 118; c++)
            {
                Console.SetCursorPosition(c, r);
                Console.Write(".");
                r++;
            }
            for (r = r; r < 20; r++)
            {
                Console.SetCursorPosition(c, r);
                Console.Write(".");
                c--;
            }
            Console.SetCursorPosition(c, r);
            Console.Write("O");
            r+=2; c -= 30;
            Console.SetCursorPosition(c, r);
            Console.Write("Ad ogni colpo la palla va più veloce");
            Console.SetCursorPosition(119, 29);
            Console.ReadKey();
            Console.Clear();
            intro();
        }
        static void impostazioni()
        {
            Console.Clear();



            Console.ReadKey();
            Console.Clear();
            intro();
        }
        static void crediti()
        {
            Console.Clear();
            Impaginanatore pagina = new Impaginanatore(30, 120);

            pagina.testo_al_centro(2, "Pong");
            pagina.testo_a_sinistra(4, 4, "Sviluppato da Diego Ammirabile 4s");

            Console.ReadKey();
            Console.Clear();
            intro();
        }
        static void gameoiver()
        {
            p.pausa = true;

            Console.SetCursorPosition(0, 7);
            for (int r = 0; r < 7; r++)
            {
                for (int i = 0; i < 40; i++)
                {
                    Console.Write(" ");
                }
                if (r == 0)
                    Console.WriteLine("     There are no more barriers to cross");
                if (r == 1)
                    Console.WriteLine("all I have in common with the uncontrollable,");
                if (r == 2)
                    Console.WriteLine("\t     and the insane,");
                if (r == 3)
                    Console.WriteLine("       the vicious and the evil,");
                if (r == 4)
                    Console.WriteLine("     all the mayhem I have caused,");
                if (r == 5)
                    Console.WriteLine("    and my utter indifference toward it");
                if (r == 6)
                    Console.WriteLine("\t    I have now surpassed.");

            }
            Thread.Sleep(500);
            Console.Clear();
            Console.Write("Fra...fai schifo");
            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine(" ::::::::      :::     ::::    ::::  ::::::::::       ::::::::  :::     ::: :::::::::: :::::::::  \n:+:    :+:   :+: :+:   +:+:+: :+:+:+ :+:             :+:    :+: :+:     :+: :+:        :+:    :+: \n+:+         +:+   +:+  +:+ +:+:+ +:+ +:+             +:+    +:+ +:+     +:+ +:+        +:+    +:+ \n:#:        +#++:++#++: +#+  +:+  +#+ +#++:++#        +#+    +:+ +#+     +:+ +#++:++#   +#++:++#:  \n+#+   +#+# +#+     +#+ +#+       +#+ +#+             +#+    +#+  +#+   +#+  +#+        +#+    +#+ \n#+#    #+# #+#     #+# #+#       #+# #+#             #+#    #+#   #+#+#+#   #+#        #+#    #+# \n ########  ###     ### ###       ### ##########       ########      ###     ########## ###    ### ");
            //Console.Write("gameover");//blody elite 4max alligator2 banner3 basic colossal [Fraktur(verificare)] Georgi16 Underlined Poison DaiR X992 
            ////                                 ^            ^!                  ^                ^!                                       ^    ^!  ^!
            Console.ReadKey();
        }

    }
}

/*
          * 
 There are no more barriers to cross
all I have in common with the uncontrollable,
           and the insane,
       the vicious and the evil,
     all the mayhem I have caused,
 and my utter indifference toward it
        I have now surpassed.
          * 
          */