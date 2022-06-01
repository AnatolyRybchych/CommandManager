using System.Text;

namespace CommandManager
{
    public static class StringExt
    {

        public static string Times(this string str, int times)
        {
            string result = "";
            for (int i = 0; i < times; i++)
                result += str;
            return result;
        }

        public static string FormatJson(this string json)
        {
            StringBuilder result = new StringBuilder();

            int tabs = 0;
            bool inLine = false;
            bool newLineBefore = false;
            bool newLineAfter = false;
            char prevChar = (char)0;
            char prevPrev = prevChar;
            foreach (var ch in json)
            {
                switch (ch)
                {
                    case '\"':
                        if (prevChar != '\\' || prevPrev == '\\') inLine = !inLine;
                        break;
                    case '[':
                    case '{':
                        if (!inLine) tabs++;
                        newLineAfter = true;
                        break;
                    case ']':
                    case '}':
                        if (!inLine) tabs--;
                        newLineBefore = true;
                        break;
                    case ',':
                        newLineAfter = true;
                        break;

                }

                if (inLine)
                {
                    result.Append(ch);
                }
                else
                {
                    if (newLineBefore) result.Append("\n" + "    ".Times(tabs));
                    result.Append(ch);
                    if (newLineAfter) result.Append("\n" + "    ".Times(tabs));
                }

                prevPrev = prevChar;
                prevChar = ch;

                newLineAfter = newLineBefore = false;
            }
            return result.ToString();
        }
    }
}
