using SkiaSharp;
using NutritionLabelGen.Labels;

namespace NutritionLabelGen;

class Program
{
    static void Main(string[] args)
    {
        const string outputPath = "./nutrition_label_skiasharp.png";

        const string heavyFontPath = "./Fonts/Roboto-Bold.ttf";
        const string regularFontPath = "./Fonts/Roboto-Regular.ttf";

        const int canvasWidth = 300;
        const int canvasHeight = 600;

        string[] fonts = { heavyFontPath, regularFontPath };
        int[] dimensions = { canvasWidth, canvasHeight };

        Builder.StandardLabel(fonts, dimensions, outputPath);
        
        // SKPaint fontCaloriesRegular = new SKPaint
        // {
        //     Typeface = typefaceRegular,
        //     TextSize = 15,
        //     IsAntialias = true,
        //     Color = SKColors.Black,
        // };

        // SKPaint fontNotes = new SKPaint
        // {
        //     Typeface = typefaceRegular,
        //     TextSize = 11,
        //     IsAntialias = true,
        //     Color = SKColors.Black,
        // };

        

        

        // // Set up the image size
        // using (var surface = SKSurface.Create(new SKImageInfo(canvasWidth, canvasHeight)))
        // {
        //     var canvas = surface.Canvas;
        //     canvas.Clear(SKColors.White);

        //     // add border to the canvas
        //     canvas.DrawRect(borderRect, borderPaint);

        //     // add heading to canvas
        //     // canvas.DrawText("Nutrition Facts", 10, 35, SKFontFace.FontFace(typefaceHeavy, 36));
        //     // SKRect titleThinLine = new SKRect(10, 40, canvasWidth - 10, 40.5F);
        //     // canvas.DrawRect(titleThinLine, SKLine.ThinLine());

        //     // // add serving info
        //     // canvas.DrawText("1 serving per container", 10, 62, SKFontFace.FontFace(typefaceRegular, 16));
        //     // canvas.DrawText("Serving size", 10, 82, SKFontFace.FontFace(typefaceHeavy, 18));
            

        //     // // thick line
        //     // SKRect thicklineRect = new SKRect(10, 90, canvasWidth - 10, 97); // startX, startY, endX, endY
        //     // canvas.DrawRect(thicklineRect, thicklinePaint);

        //     // // amount per serving text
        //     // canvas.DrawText("Amount Per Serving", 10, 118, fontAmtPerServing);
        //     // SKRect thinLine01 = new SKRect(10, 124, canvasWidth - 10, 124.5F);
        //     // canvas.DrawRect(thinLine01, thinlinePaint);

        //     // // calories
        //     // canvas.DrawText("Calories", 10, 140, fontCaloriesHeavy);
        //     // canvas.DrawText("260", 70, 140, fontCaloriesRegular);

        //     // // calories from fat (right-aligned)
        //     // string caloriesFromFat = "Calories from Fat 120";
        //     // using (var rightText = new SKPaint())
        //     // {
        //     //     rightText.TextSize = fontCaloriesRegular.TextSize;
        //     //     rightText.IsAntialias = true;
        //     //     rightText.Color = SKColors.Black;

        //     //     float textWidth = rightText.MeasureText(caloriesFromFat);

        //     //     float x = canvasWidth - textWidth - 10;
        //     //     float y = 140;

        //     //     canvas.DrawText(caloriesFromFat, x, y, rightText);
        //     // }

        //     // SKRect belowCaloriesLine = new SKRect(10, 146, canvasWidth - 10, 146 + mediumLinePaint.StrokeWidth); // startX, startY, endX, endY
        //     // canvas.DrawRect(belowCaloriesLine, mediumLinePaint);

        //     // // % Daily Value* text
        //     // string textDailyValuePercent = "% Daily Value*";
        //     // using (var rightText = new SKPaint())
        //     // {
        //     //     rightText.TextSize = fontNotes.TextSize;
        //     //     rightText.IsAntialias = true;
        //     //     rightText.Color = SKColors.Black;
        //     //     float textWidth = rightText.MeasureText(textDailyValuePercent);
        //     //     float x = canvasWidth - textWidth - 10;
        //     //     float y = 163;
        //     //     canvas.DrawText(textDailyValuePercent, x, y, rightText);
        //     // }
        //     // SKRect belowDailyValuePercentLine = new SKRect(10, 170, canvasWidth - 10, 170 + thinlinePaint.StrokeWidth);
        //     // canvas.DrawRect(belowDailyValuePercentLine, thinlinePaint);       

        //     // Save the image
        //     using (var image = surface.Snapshot())
        //     using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
        //     using (var stream = System.IO.File.OpenWrite(outputPath))
        //     {
        //         data.SaveTo(stream);
        //     }
        // }
    
        
        Console.WriteLine($"Nutrition label generated at {outputPath}");
    }
}
