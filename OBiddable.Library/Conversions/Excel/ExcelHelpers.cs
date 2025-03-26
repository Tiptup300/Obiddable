using System.Drawing;
using OBiddable.Library.Conversions.Excel;
using OfficeOpenXml;

namespace OBiddable.Library.Conversions.Excel;

public static class ExcelHelpers
{
    #region DATA VALIDATION
    public static ExcelRange MustBePositiveDecimal(this ExcelRange c)
    {
        var dataValidation = c.DataValidation.AddDecimalDataValidation();
        dataValidation.Operator = ExcelDataValidationOperator.greaterThan;
        dataValidation.Formula.Value = 0;
        dataValidation.ShowErrorMessage = true;
        dataValidation.ShowInputMessage = true;
        dataValidation.Error = "Field must be a postive decimal.";
        dataValidation.Prompt = "Field must be a postive decimal.";
        dataValidation.AllowBlank = true;

        return c;
    }
    public static ExcelRange MustBeStringUnderLength(this ExcelRange c, int length)
    {
        var dataValidation = c.DataValidation.AddTextLengthDataValidation();
        dataValidation.Operator = ExcelDataValidationOperator.lessThan;
        dataValidation.Formula.Value = length;
        dataValidation.ShowErrorMessage = true;
        dataValidation.ShowInputMessage = true;
        dataValidation.Error = $"Field must be below { length } characters long.";
        dataValidation.Prompt = $"Field must be below { length } characters long.";
        dataValidation.AllowBlank = true;

        return c;
    }
    #endregion

    #region COLUMN
    public static ExcelColumn BackgroundFillColor(this ExcelColumn c, Color color)
    {
        c.Style.Fill.BackgroundColor.SetColor(color);
        return c;
    }
    public static ExcelColumn Width(this ExcelColumn c, double width)
    {
        c.Width = width;
        return c;
    }
    public static ExcelColumn FontColor(this ExcelColumn c, Color color)
    {
        c.Style.Font.Color.SetColor(color);
        return c;
    }
    public static ExcelColumn Unlock(this ExcelColumn c)
    {
        c.Style.Locked = false;
        return c;
    }
    public static ExcelColumn Format(this ExcelColumn c, string format)
    {
        c.Style.Numberformat.Format = format;
        return c;
    }
    public static ExcelColumn BorderAroundDark(this ExcelColumn c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.BorderAround(borderStyle, Color.Black);
        return c;
    }
    public static ExcelColumn BorderAroundLight(this ExcelColumn c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.BorderAround(borderStyle, Color.FromArgb(212, 212, 212));
        return c;
    }
    public static ExcelColumn BorderTop(this ExcelColumn c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.Top.Style = borderStyle;
        return c;
    }
    public static ExcelColumn BorderLeft(this ExcelColumn c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.Left.Style = borderStyle;
        return c;
    }
    public static ExcelColumn BorderRight(this ExcelColumn c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.Right.Style = borderStyle;
        return c;
    }
    public static ExcelColumn BorderBottom(this ExcelColumn c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.Bottom.Style = borderStyle;
        return c;
    }
    public static ExcelColumn WrapText(this ExcelColumn c)
    {
        c.Style.WrapText = true;
        return c;
    }
    public static ExcelColumn Bold(this ExcelColumn c)
    {
        c.Style.Font.Bold = true;
        return c;
    }
    public static ExcelColumn Size(this ExcelColumn c, int fontsize)
    {
        c.Style.Font.Size = fontsize;
        return c;
    }
    public static ExcelColumn Left(this ExcelColumn c)
    {
        c.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
        return c;
    }
    public static ExcelColumn Center(this ExcelColumn c)
    {
        c.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        return c;
    }
    public static ExcelColumn Right(this ExcelColumn c)
    {
        c.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        return c;
    }
    public static ExcelColumn Top(this ExcelColumn c)
    {
        c.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
        return c;
    }
    public static ExcelColumn Middle(this ExcelColumn c)
    {
        c.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        return c;
    }
    public static ExcelColumn Bottom(this ExcelColumn c)
    {
        c.Style.VerticalAlignment = ExcelVerticalAlignment.Bottom;
        return c;
    }
    #endregion

    #region RANGE
    public static ExcelRange BackgroundFillColor(this ExcelRange c, Color color)
    {
        c.Style.Fill.PatternType = ExcelFillStyle.Solid;
        c.Style.Fill.BackgroundColor.SetColor(color);
        return c;
    }
    public static ExcelRange LockField(this ExcelRange c)
    {
        c.Style.Fill.PatternType = ExcelFillStyle.Solid;
        c.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(242, 242, 242));
        c.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(212, 212, 212));
        c.Style.Locked = true;

        return c;
    }
    public static ExcelRange FontColor(this ExcelRange c, Color color)
    {
        c.Style.Font.Color.SetColor(color);
        return c;
    }
    public static ExcelRange UnlockField(this ExcelRange c)
    {
        c.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.FromArgb(212, 212, 212));
        c.Style.Locked = false;
        return c;
    }
    public static ExcelRange Format(this ExcelRange c, string format)
    {
        c.Style.Numberformat.Format = format;
        return c;
    }
    public static ExcelRange BorderAroundDark(this ExcelRange c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.BorderAround(borderStyle, Color.Black);
        return c;
    }
    public static ExcelRange BorderAroundLight(this ExcelRange c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.BorderAround(borderStyle, Color.FromArgb(212, 212, 212));
        return c;
    }
    public static ExcelRange BorderTop(this ExcelRange c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.Top.Style = borderStyle;
        return c;
    }
    public static ExcelRange BorderLeft(this ExcelRange c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.Left.Style = borderStyle;
        return c;
    }
    public static ExcelRange BorderRight(this ExcelRange c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.Right.Style = borderStyle;
        return c;
    }
    public static ExcelRange BorderBottom(this ExcelRange c, ExcelBorderStyle borderStyle)
    {
        c.Style.Border.Bottom.Style = borderStyle;
        return c;
    }
    public static ExcelRange WrapText(this ExcelRange c)
    {
        c.Style.WrapText = true;
        return c;
    }
    public static ExcelRange Bold(this ExcelRange c)
    {
        c.Style.Font.Bold = true;
        return c;
    }
    public static ExcelRange Size(this ExcelRange c, int fontsize)
    {
        c.Style.Font.Size = fontsize;
        return c;
    }
    public static ExcelRange Merge(this ExcelRange c)
    {
        c.Merge = true;
        return c;
    }
    public static ExcelRange Left(this ExcelRange c)
    {
        c.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
        return c;
    }
    public static ExcelRange Center(this ExcelRange c)
    {
        c.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        return c;
    }
    public static ExcelRange Right(this ExcelRange c)
    {
        c.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        return c;
    }
    public static ExcelRange Top(this ExcelRange c)
    {
        c.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
        return c;
    }
    public static ExcelRange Middle(this ExcelRange c)
    {
        c.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        return c;
    }
    public static ExcelRange Bottom(this ExcelRange c)
    {
        c.Style.VerticalAlignment = ExcelVerticalAlignment.Bottom;
        return c;
    }
    #endregion

}
