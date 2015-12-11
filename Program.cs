using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
namespace x264
{
    class Program

    {


        static void Main(string[] args)
        {
            /*sample 
            x264.exe --crf <integer> диапзон качества

                        
       ***********     --preset <string> ultrafast (ультра-быстрый):*********
       +++++++++++++++++++++
--no-8x8dct --aq-mode 0 --b-adapt 0 --bframes 0 --no-cabac --no-deblock --no-mbtree --me dia --no-mixed-refs --partitions none --rc-lookahead 0 --ref 1 --scenecut 0 --subme 0 --trellis 0 --no-weightb --weightp 0
superfast (супер-быстрый):
--no-mbtree --me dia --no-mixed-refs --partitions i8x8,i4x4 --rc-lookahead 0 --ref 1 --subme 1 --trellis 0 --weightp 1
veryfast (очень быстрый):
--no-mixed-refs --rc-lookahead 10 --ref 1 --subme 2 --trellis 0 --weightp 1
faster (еще быстрее):
--no-mixed-refs --rc-lookahead 20 --ref 2 --subme 4 --weightp 1
fast (быстрый):
--rc-lookahead 30 --ref 2 --subme 6 --weightp 1
medium (средний):
все значения по умолчанию
slow (медленный):
--b-adapt 2 --direct auto --me umh --rc-lookahead 50 --ref 5 --subme 8
slower (медленнее):
--b-adapt 2 --direct auto --me umh --partitions all --rc-lookahead 60 --ref 8 --subme 9 --trellis 2
veryslow (очень медленный):
--b-adapt 2 --bframes 8 --direct auto --me umh --merange 24 --partitions all --ref 16 --subme 10 --trellis 2 --rc-lookahead 60
placebo (плацебо):
--bframes 16 --b-adapt 2 --direct auto --slow-firstpass --no-fast-pskip --me tesa --merange 24 --partitions all --rc-lookahead 60 --ref 16 --subme 11 --trellis 2

            +++++++++++++++++++++








            --tune <string> 
            --profile <string>
            -o <выходное видео> <входное видео>
            */
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("x264 Command Interface \nWARNING only used preset 'ultrafast '!!! \nAudio track no encoding"+"\nVersion 0.1 beta");

            string core_x264 = "x264_core.exe";
            string keys_x264 = null;
            string input_file = null;
            string output_file = null;
            string bit_rate = null;
            var fps = "";
            var res = "";
            Console.WriteLine("Input file for encode ");
            input_file = Console.ReadLine();

            Console.WriteLine("Input name  for your *.mkv file ");
            output_file = Console.ReadLine();

            Console.WriteLine("Input bitrate p.s only numbers ");
              bit_rate/*качество */ = Console.ReadLine();

           // Console.WriteLine("Input resolution\nexample: 720:480 ");
      //      res = Console.ReadLine();

            Console.WriteLine("Input FPS\nexample: 23,976 ");
            fps = Console.ReadLine();

            keys_x264 = " -o " + output_file + ".mkv" + " " + input_file+" -B " +bit_rate+ " --ref 1 --subme 1  --me dia --rc-lookahead 25  --merange 8  --trellis 0 --level 5.1 --profile high444  " + " -- tune grain"  +" "  + " --fps "+fps            +"--asm -A all"           ;
            Console.WriteLine("start x264 for encoding video");
         File.WriteAllText(@".\build.cmd", core_x264 +" "+ keys_x264);
            System.Threading.Thread.Sleep(200);
            Process.Start(@".\build.cmd");
 
        
            Console.WriteLine("\nDone\nFor exit press any key");
            Console.ReadKey();














        }
    }
}