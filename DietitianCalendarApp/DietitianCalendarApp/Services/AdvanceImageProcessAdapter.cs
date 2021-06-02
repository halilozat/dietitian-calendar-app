using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianCalendarApp.Services
{
    public class AdvanceImageProcessAdapter : IImageProcess
    {
        //Adapter kullanacağımız interface ile konuşmamızı sağlar.
        private readonly IAdvanceImageProcess _advanceImageProcess;
        public AdvanceImageProcessAdapter(IAdvanceImageProcess advanceImageProcess)
        {
            _advanceImageProcess = advanceImageProcess;
        }

        public void AddWaterMark(string text, string filename, Stream imageStream)
        {
            //Burada yaptığımız işlem sayesinde, proje kodlarını değiştirmeden,
            //3. parti kütüphaneden gelen kodları ImageProcess kodları yerine projemize adapte ediyoruz.
            //Bu işlemler sonunda projede sadece startup dosyasında servisimizi tanıtıyoruz, başka bir değişiklik yapmamıza gerek kalmıyor.
            _advanceImageProcess.AddWatermarkImage(imageStream, text, $"wwwroot/watermarks/{filename}", Color.FromArgb(128, 255, 255, 255), Color.FromArgb(0, 255, 255, 255));
        }
    }
}
