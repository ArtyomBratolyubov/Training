using System;
using System.Text;

namespace HexLibrary
{
    /// <summary>
    /// Custom formater. Represents special formater argument "h(H)" to convert number to hex system
    /// </summary>
    public sealed class HexStringFormatter : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format
        /// </summary>
        /// <param name="format">A format string containing formatting specifications</param>
        /// <param name="arg">An object to format</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance</param>
        /// <returns>The string representation of the value of arg, formatted as specified by format</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
                return "";

            if (format != "H" && format != "h")
                return string.Format(formatProvider, "{0:" + format + "}", arg);

            if (arg is byte) return GetHexString((byte)arg);
            if (arg is ushort) return GetHexString((ushort)arg);
            if (arg is uint) return GetHexString((uint)arg);
            if (arg is ulong) return GetHexString((ulong)arg);

            if (arg is sbyte) return GetHexString((sbyte)arg);
            if (arg is short) return GetHexString((short)arg);
            if (arg is int) return GetHexString((int)arg);
            if (arg is long) return GetHexString((long)arg);

            throw new ArgumentException("Incompatible type", "arg");
        }
        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return</param>
        /// <returns>An instance of the object specified by formatType</returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        //converts number to hex string
        private string GetHexString(long arg)
        {
            return (arg < 0 ? "-" : "") + GetHexString((ulong)(arg < 0?(arg * -1):arg));
        }
        //converts number to hex string
        private string GetHexString(ulong arg)
        {
            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            StringBuilder res = new StringBuilder();

            while (true)
            {
                res.Insert(0, digits[arg % 16]);
                arg /= 16;

                if (arg == 0)
                    break;
            }

            return res.ToString();
        }
    }
}
