using System;

namespace PetShopCare.Foundation
{
    public static class SqlUtilities
    {
        public static string FormatSqlLiteral(string? text) => text is not null ? "'" + text.Replace("'", "''") + "'" : "NULL";
        public static string FormatSqlLiteral(int? number) => number is not null ? number.Value.ToString() : "NULL";
        public static string FormatSqlLiteral(DateTime? dateTime) => dateTime is not null ? $"'{dateTime:yyyy-MM-dd HH:mm:ss}'" : "NULL";
        public static string FormatSqlLiteral(DateOnly? date) => date is not null ? $"'{date:yyyy-MM-dd}'" : "NULL";
        public static string FormatSqlLiteral(TimeOnly? time) => time is not null ? $"'{time:HH:mm:ss}'" : "NULL";
        public static string FormatSqlLiteral(Guid? guid) => guid is not null ? $"'{guid}'" : "NULL";
    }
}
