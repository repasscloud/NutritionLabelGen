using System.Net.Http.Headers;
using SkiaSharp;

namespace NutritionLabelGen.Labels;

public static class Builder
{
    public static void StandardLabel(string[] fontPaths, int[] dimensions, string outputPath)
    {
        int cWidth = dimensions[0];
        int cHeight = dimensions[1];

        // load fonts
        using (var typefaceRegular = SKTypeface.FromFile(fontPaths[1]))
        {
            using (var typefaceHeavy = SKTypeface.FromFile(fontPaths[0]))
            {
                /*
                * Set fonts
                */
                SKPaint titleFont = new SKPaint
                {
                    Typeface = typefaceHeavy,
                    TextSize = 36,
                    IsAntialias = true,
                    Color = SKColors.Black,
                };

                SKPaint servingFont = new SKPaint
                {
                    Typeface = typefaceRegular,
                    TextSize = 16,
                    IsAntialias = true,
                    Color = SKColors.Black,
                };

                SKPaint servingSizeFont = new SKPaint
                {
                    Typeface = typefaceHeavy,
                    TextSize = 16,
                    IsAntialias = true,
                    Color = SKColors.Black,
                };

                SKPaint amtPerServingFont = new SKPaint
                {
                    Typeface = typefaceHeavy,
                    TextSize = 15,
                    IsAntialias = true,
                    Color = SKColors.Black,
                };

                SKPaint msrPerServingFont = new SKPaint
                {
                    Typeface = typefaceRegular,
                    TextSize = 15,
                    IsAntialias = true,
                    Color = SKColors.Black,
                };

                SKPaint servingFontHeavy = new SKPaint
                {
                    Typeface = typefaceHeavy,
                    TextSize = 18,
                    IsAntialias = true,
                    Color = SKColors.Black,
                };

                /*
                * LINES
                */
                // thick line
                var thicklinePaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.Black,
                    StrokeWidth = 7,
                };
                
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

                // border rectangle
                var borderPaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.Black,
                    StrokeWidth = 2,
                };

                SKRect borderRect = new SKRect(
                    borderPaint.StrokeWidth / 2,
                    borderPaint.StrokeWidth / 2,
                    (float)dimensions[0] - borderPaint.StrokeWidth / 2,
                    (float)dimensions[1] - borderPaint.StrokeWidth / 2
                );

                // Set up the image size
                using (var surface = SKSurface.Create(new SKImageInfo(dimensions[0], dimensions[1])))
                {
                    var canvas = surface.Canvas;
                    canvas.Clear(SKColors.White);

                    // add border to the canvas
                    canvas.DrawRect(borderRect, borderPaint);

                    // add heading to canvas (title)
                    canvas.DrawText("Nutrition Facts", 10, 35, titleFont);
                    SKRect titleThinLine = new SKRect(10, 40, cWidth - 10, 40.5F);
                    canvas.DrawRect(titleThinLine, thinlinePaint);

                    // X servings per Y
                    canvas.DrawText("X servings per Y", 10, 60, servingFont);

                    // serving size
                    canvas.DrawText("Serving size", 10, 80, servingSizeFont);

                    // serving measure
                    string servingMeasure = "1 cookie (26g)";
                    using (var paint = new SKPaint())
                    {
                        paint.IsAntialias = true;
                        paint.Color = SKColors.Black;
                        paint.Typeface = typefaceHeavy;
                        paint.TextSize = 16;

                        float textWidth = paint.MeasureText(servingMeasure);

                        float x = cWidth - textWidth - 10;
                        float y = 80;

                        canvas.DrawText(servingMeasure, x, y, paint);
                    }

                    // thick line
                    SKRect thicklineRect = new SKRect(10, 90, cWidth - 10, 97); // startX, startY, endX, endY
                    canvas.DrawRect(thicklineRect, thicklinePaint);

                    // amount per serving text (static)
                    canvas.DrawText("Amount Per Serving", 10, 120, amtPerServingFont);

                    // calories text (static)
                    canvas.DrawText("Calories", 10, 155, titleFont);

                    // calories index
                    string caloriesIndex = "110";
                    using (var paint = new SKPaint())
                    {
                        paint.IsAntialias = true;
                        paint.Color = SKColors.Black;
                        paint.Typeface = typefaceHeavy;
                        paint.TextSize = 42;

                        float textWidth = paint.MeasureText(caloriesIndex);

                        float x = cWidth - textWidth - 10;
                        float y = 155;

                        canvas.DrawText(caloriesIndex, x, y, paint);
                    }

                    // medium line
                    SKRect mediumRect01 = new SKRect(10, 165, cWidth - 10, 168); // startX, startY, endX, endY
                    canvas.DrawRect(mediumRect01, mediumLinePaint);

                    // % daily value* (static)
                    string pcDailyValue = "% Daily Value*";
                    using (var paint = new SKPaint())
                    {
                        paint.IsAntialias = true;
                        paint.Color = SKColors.Black;
                        paint.Typeface = typefaceHeavy;
                        paint.TextSize = 15;

                        float textWidth = paint.MeasureText(pcDailyValue);

                        float x = cWidth - textWidth - 10;
                        float y = 188;

                        canvas.DrawText(pcDailyValue, x, y, paint);
                    }

                    // thin line 01
                    SKRect thinLine01 = new SKRect(10, 194, cWidth - 10, 194 + thinlinePaint.StrokeWidth);
                    canvas.DrawRect(thinLine01, thinlinePaint);

                    // total fat text (static)
                    canvas.DrawText("Total Fat", 10, 212, amtPerServingFont);

                    // total fat (g)
                    float totalFat = 4;
                    float totalFatWidth = amtPerServingFont.MeasureText("Total Fat ");
                    canvas.DrawText($"{totalFat}g", 10 + totalFatWidth, 212, msrPerServingFont);

                    // total fat (%)
                    float totalFatX = amtPerServingFont.MeasureText("6%");
                    canvas.DrawText("6%", cWidth - totalFatX - 10, 212, amtPerServingFont);
                    SKRect thinLine02 = new SKRect(10, 218, cWidth - 10, 218 + thinlinePaint.StrokeWidth);
                    canvas.DrawRect(thinLine02, thinlinePaint);

                    // saturated fat
                    float saturatedFat = 2.5F;
                    canvas.DrawText($"   Saturated Fat {saturatedFat}", 10, 234, msrPerServingFont);
                    float saturdatedFatX = amtPerServingFont.MeasureText($"13%");
                    canvas.DrawText("13%", cWidth - saturdatedFatX - 10, 234, amtPerServingFont);

                    // Save the image
                    using (var image = surface.Snapshot())
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                    using (var stream = System.IO.File.OpenWrite(outputPath))
                    {
                        data.SaveTo(stream);
                    }
                }
            }
        }
    }
}
