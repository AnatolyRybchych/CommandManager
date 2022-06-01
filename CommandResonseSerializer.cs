
using System.Text.Json;

namespace CommandManager
{
    internal class CommandResonseSerializer
    {
        public CommandResonseSerializer()
        {

        }

        public string Serialize(object obj)
        {
            if(obj.GetType().GetMethod("ToString", new Type[0])?.DeclaringType != typeof(object))
            {
                return obj.ToString() ?? "empty response";
            }
            else  
            {
                if((obj.GetType().IsAssignableTo(typeof(IEnumerable<object>))))
                {
                    if (((IEnumerable<object>)obj).Count() == 0) 
                        return "[]";
                    else
                        return  "[\n    " + string.Join("\n    ", ((IEnumerable<object>)obj).Select(o => Serialize(o))) + "\n]";
                }
                else
                    return JsonSerializer.Serialize(obj).FormatJson();
            }
        }
    }
}
