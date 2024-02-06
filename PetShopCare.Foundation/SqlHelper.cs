namespace PetShopCare.Foundation
{
    public static class SqlHelper
    {
        public static string Sql(SqlInterpolatedStringHandler sql) => sql.GetFormattedText();
        public static Null Null => new();
        public static Raw Raw(string Text) => new(Text);
    }
}
