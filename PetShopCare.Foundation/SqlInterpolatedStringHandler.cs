using System.Runtime.CompilerServices;
using System.Text;

namespace PetShopCare.Foundation
{
    [InterpolatedStringHandler]
    public readonly ref struct SqlInterpolatedStringHandler
    {
        // Storage for the built-up string
        private readonly StringBuilder _builder;

        public SqlInterpolatedStringHandler(int literalLength, int _) => _builder = new StringBuilder(literalLength);

        public void AppendLiteral(string s) => _builder.Append(s);

        public void AppendFormatted<T>(T value) => _ = value switch
        {
            null => _builder.Append("NULL"),
            string text => _builder.Append(SqlUtilities.FormatSqlLiteral(text)),
            int number => _builder.Append(SqlUtilities.FormatSqlLiteral(number)),
            DateTime dateTime => _builder.Append(SqlUtilities.FormatSqlLiteral(dateTime)),
            DateOnly date => _builder.Append(SqlUtilities.FormatSqlLiteral(date)),
            TimeOnly time => _builder.Append(SqlUtilities.FormatSqlLiteral(time)),
            //Raw(string text) => _builder.Append(text),
            //Null => _builder.Append("NULL"),
            Guid guid => _builder.Append(SqlUtilities.FormatSqlLiteral(guid)),
            _ => throw new Exception("unsupported type")
        };

        //public void AppendFormatted<T>(T value, string format) /*where T : IFormattable*/ => _ = value switch
        //{
        //    null => _builder.Append("NULL"),
        //    string text => _builder.Append(SqlUtilities.FormatSqlLiteral(text)),
        //    int number => _builder.Append(SqlUtilities.FormatSqlLiteral(number)),
        //    DateTime dateTime => _builder.Append(SqlUtilities.FormatSqlLiteral(dateTime)),
        //    Raw(string text) => _builder.Append(text),
        //    Null => _builder.Append("NULL"),
        //    _ => throw new Exception("unsupported type")
        //};

        public string GetFormattedText() => _builder.ToString();
    }
}
