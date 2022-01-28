using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;

// create a new image with a blue background
using BitmapExportContext context = new PlatformBitmapExportService().CreateContext(500, 150);
ICanvas canvas = context.Canvas;
canvas.FillColor = Color.FromArgb("#003366");
canvas.FillRectangle(0, 0, context.Width, context.Height);

// measure the string and draw a rectangle around it
string message = "Hello, Maui.Graphics!";
Font font = new("Impact");
int fontSize = 36;
SizeF textSize = canvas.GetStringSize(message, font, fontSize);
PointF textLocation = new(50, 50);
RectangleF textRect = new(textLocation, textSize);
canvas.StrokeColor = Color.FromArgb("#006699");
canvas.StrokeSize = 3;
canvas.DrawRectangle(textRect);

// draw the string
canvas.FontColor = Colors.Yellow;
canvas.Font = font;
canvas.FontSize = fontSize;
canvas.DrawString(message, textLocation.X, textLocation.Y + textSize.Height, HorizontalAlignment.Left);

// save the canvas as an image file
string filePath = Path.GetFullPath("test.png");
using FileStream fs = new(filePath, FileMode.Create);
context.WriteToStream(fs);
Console.WriteLine(filePath);
