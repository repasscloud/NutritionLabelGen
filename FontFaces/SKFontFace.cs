using SkiaSharp;

namespace NutritionLabelGen.FontFaces;

public static class SKFontFace

{
    public static SKPaint FontFace(SKTypeface typeface, float textSize)
    {
        using (SKPaint fontFace = new SKPaint())
        {
            fontFace.Typeface = typeface;
            fontFace.TextSize = textSize;
            fontFace.IsAntialias = true;
            fontFace.Color = SKColors.Black;
        
            return fontFace;
        }
    }

    public static RightText RightFontFace(SKTypeface typeface, float textSize, string text, int canvasWidth, float yAxis)
    {
        using (SKPaint rightText = new SKPaint())
        {
            rightText.TextSize = textSize;
            rightText.IsAntialias = true;
            rightText.Color = SKColors.Black;
            rightText.Typeface = typeface;

            float textWidth = rightText.MeasureText(text);

            float x = canvasWidth - textWidth - 10;
            float y = yAxis;

            RightText RightText = new RightText()
            {
                XAxis = x,
                YAxis = y,
                RightHandText = rightText,
            };

            return RightText;
        }
    }

    public class RightText
    {
        public float XAxis { get; set; }
        public float YAxis { get; set; }
        public SKPaint RightHandText { get; set; } = new SKPaint();
    }
}

