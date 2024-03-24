using SkiaSharp;

namespace NutritionLabelGen;

class Program
{
    static void Main(string[] args)
    {
        const string outputPath = "./nutrition_label_skiasharp.png";

        const string heavyFontPath = "./Fonts/Roboto-Bold.ttf";
        const string regularFontPath = "./Fonts/Roboto-Regular.ttf";

        const int canvasWidth = 400;
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
            Typeface = typefaceHeavy,
            TextSize = 24,
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

        // Set up the image size
        using (var surface = SKSurface.Create(new SKImageInfo(canvasWidth, canvasHeight)))
        {
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            // add border to the canvas
            canvas.DrawRect(borderRect, borderPaint);

            // add heading to canvas
            canvas.DrawText("Nutrition Facts", 10, 35, fontTitle);

            // // draw paint for the black line (recatange)
            // var linePaint = new SKPaint
            // {
            //     Style = SKPaintStyle.Stroke,
            //     Color = SKColors.Black,
            //     StrokeWidth = 4,
            // };

            // // draw a black line across the image, by drawing a thin rectangle
            // SKRect lineRect = new SKRect(10, 150, 390, 154); // startX, startY, endX, endY
            // canvas.DrawRect(lineRect, linePaint);

            // var thinLinePaint = new SKPaint
            // {
            //     Style = SKPaintStyle.Stroke,
            //     Color = SKColors.Black,
            //     StrokeWidth = 2,
            // };

            // float startX = 10;
            // float startY = 200;
            // float endX = 390;
            // float endY = 200;

            // canvas.DrawLine(startX, startY, endX, endY, thinLinePaint);

            // Save the image
            using (var image = surface.Snapshot())
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = System.IO.File.OpenWrite(outputPath))
            {
                data.SaveTo(stream);
            }
        }
        
        // dispose of elements
        fontTitle.Dispose();
        borderPaint.Dispose();
        fontServingsInfo.Dispose();

        Console.WriteLine($"Nutrition label generated at {outputPath}");
    }
}
