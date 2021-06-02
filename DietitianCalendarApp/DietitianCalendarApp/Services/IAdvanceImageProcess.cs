using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianCalendarApp.Services
{
    public interface IAdvanceImageProcess
    {
        // void AddWatermark(string text, string filename, Stream imageStream);


        //3. parti kütüphane için kullanacağımız interface.
        void AddWatermarkImage(Stream stream, string text, string filePath, Color color, Color outlineColor);
    }
}
