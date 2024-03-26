using SkiaSharp;

namespace NutritionLabelGen.Lines;

public static class SKLine
{
    public static SKPaint ThickLine()
    {
        SKPaint thickLinePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 7,
        };

        return thickLinePaint;
    }

    public static SKPaint MediumLine()
    {
        SKPaint mediumLinePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 3,
        };

        return mediumLinePaint;
    }

    public static SKPaint ThinLine()
    {
        SKPaint thinLinePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 0.5F,
        };

        return thinLinePaint;
    }
}

