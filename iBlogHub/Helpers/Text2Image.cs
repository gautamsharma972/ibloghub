using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Helpers
{
    public class Text2Image
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public Text2Image(
           IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            
        }
        /// <summary>
        /// Converting text to image (png).
        /// </summary>
        /// <param name="text">text to convert</param>
        /// <param name="font">Font to use</param>
        /// <param name="textColor">text color</param>
        /// <param name="maxWidth">max width of the image</param>
        /// <param name="path">path to save the image</param>
        public string DrawText(String text, Font font, Color textColor, int maxWidth, String path)
        {
            //creating a image object   
            string filepath =  _hostingEnvironment.WebRootPath + "\\Uploads" + $@"\abstract2.jpg";
            //first, create a dummy bitmap just to get a graphics object
            Image img = (System.Drawing.Image)Bitmap.FromFile(filepath);
            Graphics drawing = Graphics.FromImage(img);           
            StringFormat sf = new StringFormat();           
            //sf.Trimming = StringTrimming.Word;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center; 
            
            img.Dispose();
            drawing.Dispose();
            img = Bitmap.FromFile(filepath);
            drawing = Graphics.FromImage(img);
            //Adjust for high quality
            drawing.CompositingQuality = CompositingQuality.HighQuality;
            drawing.InterpolationMode = InterpolationMode.HighQualityBilinear;
            drawing.PixelOffsetMode = PixelOffsetMode.HighQuality;
            drawing.SmoothingMode = SmoothingMode.HighQuality;
            drawing.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;            
            //paint the background
            //drawing.Clear(Color.Transparent);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);
            Color StringColor = System.Drawing.Color.FloralWhite;
            
            drawing.DrawString(text, font, new SolidBrush(StringColor), new Point(268, 245),sf); 

            //drawing.DrawString(text, font, textBrush, new RectangleF(0, 0, textSize.Width, textSize.Height), sf);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();
            img.Save(path, ImageFormat.Jpeg);
            img.Dispose();
            return path;
        }
        //public Image DrawText(string text, Font font, Color textColor, Color backColor)
        //{
        //    //first, create a dummy bitmap just to get a graphics object
        //    System.Drawing.Image img = new Bitmap(1, 1);
        //    Graphics drawing = Graphics.FromImage(img);

        //    //measure the string to see how big the image needs to be
        //    SizeF textSize = drawing.MeasureString(text, font);

        //    //free up the dummy image and old graphics object
        //    img.Dispose();
        //    drawing.Dispose();

        //    //create a new image of the right size
        //    img = new Bitmap((int)textSize.Width, (int)textSize.Height);

        //    drawing = Graphics.FromImage(img);

        //    //paint the background
        //    drawing.Clear(backColor);

        //    //create a brush for the text
        //    Brush textBrush = new SolidBrush(textColor);

        //    drawing.DrawString(text, font, textBrush, 0, 0);

        //    drawing.Save();

        //    textBrush.Dispose();
        //    drawing.Dispose();

        //    return img;

        //}
    }
}
