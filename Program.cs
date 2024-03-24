using SkiaSharp;

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

        // load the fonts
        var typefaceHeavy = SKTypeface.FromFile(heavyFontPath);
        var typefaceRegular = SKTypeface.FromFile(regularFontPath);

        // set the fonts used
        SKPaint fontTitle = new SKPaint
        {
            Typeface = typefaceHeavy,
            TextSize = 36,
            IsAntialias = true,
            Color = SKColors.Black,
        };

        SKPaint fontServingsInfo = new SKPaint
        {
            Typeface = typefaceRegular,
            TextSize = 16,
            IsAntialias = true,
            Color = SKColors.Black,
        };

        SKPaint fontAmtPerServing = new SKPaint
        {
            Typeface = typefaceHeavy,
            TextSize = 13,
            IsAntialias = true,
            Color = SKColors.Black,
        };

        SKPaint fontCaloriesHeavy = new SKPaint
        {
            Typeface = typefaceHeavy,
            TextSize = 15,
            IsAntialias = true,
            Color = SKColors.Black,
        };
        
        SKPaint fontCaloriesRegular = new SKPaint
        {
            Typeface = typefaceRegular,
            TextSize = 15,
            IsAntialias = true,
            Color = SKColors.Black,
        };

        SKPaint fontNotes = new SKPaint
        {
            Typeface = typefaceRegular,
            TextSize = 11,
            IsAntialias = true,
            Color = SKColors.Black,
        };

        // create border line
        var borderPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 2,
        };

        SKRect borderRect = new SKRect(
            borderPaint.StrokeWidth / 2,
            borderPaint.StrokeWidth / 2,
            (float)canvasWidth - borderPaint.StrokeWidth / 2,
            (float)canvasHeight - borderPaint.StrokeWidth / 2
        );

        // thick line
        var thicklinePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 7,
        };
        SKRect thicklineRect = new SKRect(10, 90, canvasWidth - 10, 97); // startX, startY, endX, endY

        // medium line
        var mediumLinePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 3,
        };

        // thin line
        var thinlinePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 0.5F,
        };

        // Set up the image size
        using (var surface = SKSurface.Create(new SKImageInfo(canvasWidth, canvasHeight)))
        {
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            // add border to the canvas
            canvas.DrawRect(borderRect, borderPaint);

            // add heading to canvas
            canvas.DrawText("Nutrition Facts", 10, 35, fontTitle);

            // add serving info
            canvas.DrawText("Serving Size 1 cup (228g)", 10, 60, fontServingsInfo);
            canvas.DrawText("Servings Per Container 2", 10, 78, fontServingsInfo);

            // thick line
            canvas.DrawRect(thicklineRect, thicklinePaint);

            // amount per serving text
            canvas.DrawText("Amount Per Serving", 10, 118, fontAmtPerServing);
            SKRect thinLine01 = new SKRect(10, 124, canvasWidth - 10, 124.5F);
            canvas.DrawRect(thinLine01, thinlinePaint);

            // calories
            canvas.DrawText("Calories", 10, 140, fontCaloriesHeavy);
            canvas.DrawText("260", 70, 140, fontCaloriesRegular);

            // calories from fat (right-aligned)
            string caloriesFromFat = "Calories from Fat 120";
            using (var rightText = new SKPaint())
            {
                rightText.TextSize = fontCaloriesRegular.TextSize;
                rightText.IsAntialias = true;
                rightText.Color = SKColors.Black;

                float textWidth = rightText.MeasureText(caloriesFromFat);

                float x = canvasWidth - textWidth - 10;
                float y = 140;

                canvas.DrawText(caloriesFromFat, x, y, rightText);
            }

            SKRect belowCaloriesLine = new SKRect(10, 146, canvasWidth - 10, 146 + mediumLinePaint.StrokeWidth); // startX, startY, endX, endY
            canvas.DrawRect(belowCaloriesLine, mediumLinePaint);

            // % Daily Value* text
            string textDailyValuePercent = "% Daily Value*";
            using (var rightText = new SKPaint())
            {
                rightText.TextSize = fontNotes.TextSize;
                rightText.IsAntialias = true;
                rightText.Color = SKColors.Black;
                float textWidth = rightText.MeasureText(textDailyValuePercent);
                float x = canvasWidth - textWidth - 10;
                float y = 163;
                canvas.DrawText(textDailyValuePercent, x, y, rightText);
            }
            SKRect belowDailyValuePercentLine = new SKRect(10, 170, canvasWidth - 10, 170 + thinlinePaint.StrokeWidth);
            canvas.DrawRect(belowDailyValuePercentLine, thinlinePaint);            

            // Save the image
            using (var image = surface.Snapshot())
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = System.IO.File.OpenWrite(outputPath))
            {
                data.SaveTo(stream);
            }
        }
        
        // dispose of elements
        borderPaint.Dispose();
        fontTitle.Dispose();
        fontServingsInfo.Dispose();
        fontAmtPerServing.Dispose();
        fontCaloriesHeavy.Dispose();
        fontCaloriesRegular.Dispose();
        
        Console.WriteLine($"Nutrition label generated at {outputPath}");
    }
}
