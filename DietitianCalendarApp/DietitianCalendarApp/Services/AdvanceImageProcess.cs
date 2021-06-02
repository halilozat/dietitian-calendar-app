using LazZiya.ImageResize;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianCalendarApp.Services
{
    public class AdvanceImageProcess : IAdvanceImageProcess
    {
        //Github'dan bulduğumuz 3. parti bir image kütüphanesini projemize uyguluyoruz.
        public void AddWatermarkImage(Stream stream, string text, string filePath, Color color, Color outlineColor)
        {
            using (var img = Image.FromStream(stream))
            {
                var tOps = new TextWatermarkOptions
                {

                    TextColor = color,

                    OutlineColor = outlineColor
                };

                img.AddTextWatermark(text, tOps)
                   .SaveAs(filePath);
            }
        }
    }
}
