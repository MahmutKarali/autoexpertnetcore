using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using WebAPI.Models;

namespace WebAPI.Component
{
    public class AutoComponent
    {
        static Bitmap success = new Bitmap("C:\\Users\\Enqura\\Desktop\\JWT-Authentication-with-.Net-Core-Web-API-and-Angular-7-master\\WebAPI\\WebAPI\\App_Data\\success.png");
        static Bitmap localpaint = new Bitmap("C:\\Users\\Enqura\\Desktop\\JWT-Authentication-with-.Net-Core-Web-API-and-Angular-7-master\\WebAPI\\WebAPI\\App_Data\\localpaint.png");
        static Bitmap painted = new Bitmap("C:\\Users\\Enqura\\Desktop\\JWT-Authentication-with-.Net-Core-Web-API-and-Angular-7-master\\WebAPI\\WebAPI\\App_Data\\painted.png");
        static Bitmap changed = new Bitmap("C:\\Users\\Enqura\\Desktop\\JWT-Authentication-with-.Net-Core-Web-API-and-Angular-7-master\\WebAPI\\WebAPI\\App_Data\\changed.png");

        public static Bitmap GetIcon(int icon)
        {
            if (icon == 1)
            {
                return painted;
            }
            else if (icon == 2)
            {
                return changed;
            }
            else if (icon == 3)
            {
                return localpaint;
            }
            else if (icon == 4)
            {
                return success;
            }

            return null;
        }

        public static CarResponse GetAutoExpert(CarInfo car)
        {
            int remaining = UserComponent.GetUser(car.userName).RemainingCount;
            //if (remaining < 1)
            //{
            //    throw new Exception("Hakkınız Kalmamıştır! Lütfen yönetici ile iletişime geçiniz!");
            //}

            Bitmap bitmap = new Bitmap("C:\\Users\\Enqura\\Desktop\\JWT-Authentication-with-.Net-Core-Web-API-and-Angular-7-master\\WebAPI\\WebAPI\\App_Data\\kaporta.png");

            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(GetIcon(car.item3), 200, 350);
                g.DrawImage(GetIcon(car.item2), 590, 350);
                g.DrawImage(GetIcon(car.item1), 970, 350);

                g.DrawImage(GetIcon(car.item4), 160, 690);
                g.DrawImage(GetIcon(car.item5), 1010, 690);

                g.DrawImage(GetIcon(car.item6), 580, 940);

                g.DrawImage(GetIcon(car.item7), 160, 1000);
                g.DrawImage(GetIcon(car.item8), 1010, 1000);

                g.DrawImage(GetIcon(car.item11), 590, 1420);
                g.DrawImage(GetIcon(car.item9), 195, 1300);
                g.DrawImage(GetIcon(car.item10), 980, 1300);

                RectangleF rectf = new RectangleF(490, 1610, 290, 50);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawString(car.plate, new Font("Tahoma", 25), Brushes.Black, rectf);

                rectf = new RectangleF(990, 1610, 2900, 50);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawString("Şasi No:" + car.sasiNo, new Font("Tahoma", 25), Brushes.Black, rectf);

                rectf = new RectangleF(990, 1660, 2900, 50);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawString("Motor No:" + car.motorNo, new Font("Tahoma", 25), Brushes.Black, rectf);

                g.Flush();
            }
            bitmap.Save("kaporta.png", ImageFormat.Png);

            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();

            UserComponent.UpdateUser(car.userName);

            return new CarResponse { image = Convert.ToBase64String(byteImage), remainingRight = remaining -1};
        }
    }
}
