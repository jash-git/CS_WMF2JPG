using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;

namespace CS_WMF2JPG
{
    /*
     sample wmf file : https://example-files.online-convert.com/vector%20image/wmf/example.wmf
     convert wmf to jpg c# : https://social.msdn.microsoft.com/Forums/vstudio/en-US/6341c2b2-ca60-45f0-9253-fdd35469d155/convert-wmf-to-jpg?forum=csharpgeneral
     */
    class Program
    {
        static void Pause()
        {
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        static void WMF2JPG(String StrInputFile)
        {
            String StrOutputFile = StrInputFile.Split('.')[0] + ".jpg";

            Image i = Image.FromFile(StrInputFile, true);
            Bitmap b = new Bitmap(i);

            Graphics g = Graphics.FromImage(b);
            /*
                If I recall correctly, WMF files do not store a background color which causes them to be transparent and when you convert it as we did previously, the color ends up being no color at all (ie black).

                In order to fix that we need to do a little more, namely create a new image, set it's background color and then paint the WMF file on top of it.
            */
            g.Clear(Color.White);

            g.DrawImage(i, 0, 0, i.Width, i.Height);
            b.Save(StrOutputFile, ImageFormat.Jpeg);

        }
        static void Main(string[] args)
        {
            WMF2JPG("example.wmf");
            Pause();
        }
    }
}
