using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterprete.Models
{
    public class KeyWords
    {
        public static Dictionary<string, Token> Keys = new Dictionary<string, Token>()
        {
            { "if", Token.RESERVADA_IF },
            { "true", Token.RESERVADA_TRUE },
            { "false", Token.RESERVADA_FALSE }
        };
    }
}
