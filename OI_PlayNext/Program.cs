using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoIt;
using System.Media;

namespace OI_PlayNext
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "     " + "Iniciando Robo");
            Thread.Sleep(3000);
            //AutoItX.MouseMove(1080, 635);
            //TestaStatusBar();
            ExecutaRobo();
            Console.ReadKey();
        }


        protected static void ExecutaRobo()
        {
            int iControle = 1;
            int iTotal = 40;
            bool bMantemLoop = true;
            int ixMouse = 500;
            //AutoItX.WinActivate("Player | balta.io - Mozilla Firefox");
            //AutoItX.WinSetState("Player | balta.io - Mozilla Firefox", "", AutoItX.SW_MAXIMIZE);

            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "     " + "Inicio do robo");
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "     " + "Loop Inicial: " + iControle.ToString());
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "     " + "Total de Loop controlado: " + iTotal.ToString());

            while (iControle < iTotal)
            {
                bMantemLoop = true;
                //Console.WriteLine("Pegando titulo");
                //string sT = AutoItX.WinGetTitle("[active]");

                //Console.WriteLine(sT);
                Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "     " + "Controle de quantidade de video");
                //Thread.Sleep(10000);

                while (bMantemLoop)
                {
                    //Console.WriteLine("Cor da carga " + iColorPix.ToString());

                    Thread.Sleep(500);
                    AutoItX.MouseMove(ixMouse, 300);
                    if (ixMouse == 500) ixMouse = 450; else ixMouse = 500;

                    if (PegaCorPixel(1640, 955) == 16666767)
                    {
                        iControle++;
                        bMantemLoop = false;

                        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "     " + "Aguardando 30 Segundos para fim do video.");

                        Thread.Sleep(30000);

                        AutoItX.MouseClick("left", ixMouse, 300, 1, 10);
                        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "     " + "Clicou no proximo video");
                        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "     " + "Video " + iControle.ToString() + " de " + iTotal.ToString());
                    }
                }
            }

            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "     " + "Finalizando Robo");

        }

        protected static void TestaStatusBar()
        {
            bool t = true;
            while (t)
            {
                Thread.Sleep(500);
                Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "     " + PegaCorPixel(1625, 955));
            }

        }

        protected static int PegaCorPixel(int x, int y)
        {
            int iColorPix = AutoItX.PixelGetColor(x, y);
            //string hexColorPix = iColorPix.ToString("X"); 
            //AutoItX.MouseMove(x, y);
            //Console.WriteLine(iColorPix.ToString());
            return iColorPix;
        }


    }
}
