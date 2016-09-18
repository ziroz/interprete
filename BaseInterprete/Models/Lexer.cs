using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseInterprete.Models
{
    public class Lexer
    {

        private string expresion;
        private int posicion;
        private int longitud;
        private Token nuevoToken;

        public Lexer(String expresion)
        {
            establecer(expresion);
        }

        public void establecer(String expresion)
        {
            this.expresion = "" + expresion;
            posicion = 0;
            longitud = 0;
            nuevoToken = 0;
        }

        private Token getToken()
        {
            int n = expresion.Length;
            posicion += longitud;

            longitud = 1;

            while (posicion < n && expresion[posicion] == ' ')
            {
                ++posicion;
            }

            if (posicion < n)
            {
                char caracter = expresion[posicion];
                Token? valorToken = null;
                switch (caracter)
                {
                    case '+':
                        valorToken = Token.SUMA;
                        break;
                    case '-':
                        valorToken = Token.RESTA;
                        break;
                    case '*':
                        valorToken = Token.MULTIPLICACION;
                        break;
                    case '/':
                        valorToken = Token.DIVISION;
                        break;
                    case '(':
                        valorToken = Token.ABRIR_PARENTESIS;
                        break;
                    case ')':
                        valorToken = Token.CERRAR_PARENTESIS;
                        break;
                    case '%':
                        valorToken = Token.MODULO;
                        break;
                    case '^':
                        valorToken = Token.POTENCIA;
                        break;
                    case '<':
                        if (posicion + longitud < n
                                    && (expresion[posicion + longitud] == '='))
                        {
                            ++longitud;
                            valorToken = Token.MENOR_IGUAL_QUE;
                        }
                        else if (posicion + longitud + 1 < n
                                   && (expresion[posicion + longitud] == '>'))
                        {
                            ++longitud;
                            valorToken = Token.DIFERENTE;
                        }
                        else
                        {
                            valorToken = Token.MENOR_QUE;
                        }
                        break;
                    case '>':
                        if (posicion + longitud < n
                                    && (expresion[posicion + longitud] == '='))
                        {
                            ++longitud;
                            valorToken = Token.MAYOR_IGUAL_QUE;
                        }
                        else
                        {
                            valorToken = Token.MAYOR_QUE;
                        }
                        break;
                    case '=':
                        if (posicion + longitud < n
                                    && (expresion[posicion + longitud] == '='))
                        {
                            ++longitud;
                            valorToken = Token.IGUAL_QUE;
                        }
                        else
                        {
                            valorToken = Token.ASIGNACION;
                        }
                        break;
                    case '&':
                        if (posicion + longitud < n
                                    && (expresion[posicion + longitud] == '&'))
                        {
                            ++longitud;
                            valorToken = Token.Y_LOGICO;
                        }
                        break;

                    case '|':
                        if (posicion + longitud < n
                                    && (expresion[posicion + longitud] == '|'))
                        {
                            ++longitud;
                            valorToken = Token.O_LOGICO;
                        }
                        break;
                    case '!':
                        valorToken = Token.NO_LOGICO;
                        break;

                    case ',':
                        valorToken = Token.COMA;
                        break;

                    case ';':
                        valorToken = Token.PUNTO_COMA;
                        break;

                    case '[':
                        valorToken = Token.ABRIR_CORCHETE;
                        break;

                    case ']':
                        valorToken = Token.CERRAR_CORCHETE;
                        break;

                    case '{':
                        valorToken = Token.ABRIR_LLAVE;
                        break;

                    case '}':
                        valorToken = Token.CERRAR_LLAVE;
                        break;

                    case 'i':
                        if ((posicion + longitud < n && (expresion[posicion + longitud] == 'f'))
                            && (posicion + longitud+1 < n && (expresion[posicion + longitud +1] == ' ')))
                        {
                            longitud += 2;
                            valorToken = Token.RESERVADA_IF;
                            break;
                        }
                        goto case 'e';

                    case 'e':
                        if ((posicion + longitud < n && (expresion[posicion + longitud] == 'l'))
                            && (posicion + longitud + 1 < n && (expresion[posicion + longitud + 1] == 's'))
                            && (posicion + longitud + 2 < n && (expresion[posicion + longitud + 2] == 'e'))
                            && (posicion + longitud + 3 < n && (expresion[posicion + longitud + 3] == ' '))
                            )
                        {
                            longitud += 4;
                            valorToken = Token.RESERVADA_ELSE;
                            break;
                        }
                        goto case 'w';
                        
                    case 'w':
                        if ((posicion + longitud < n && (expresion[posicion + longitud] == 'h'))
                            && (posicion + longitud + 1 < n && (expresion[posicion + longitud + 1] == 'i'))
                            && (posicion + longitud + 2 < n && (expresion[posicion + longitud + 2] == 'l'))
                            && (posicion + longitud + 3 < n && (expresion[posicion + longitud + 3] == 'e'))
                            && (posicion + longitud + 4 < n && (expresion[posicion + longitud + 4] == ' '))
                            )
                        {
                            longitud += 5;
                            valorToken = Token.RESERVADA_WHILE;
                            break;
                        }
                        goto case 'f';

                    case 'f':
                        if ((posicion + longitud < n && (expresion[posicion + longitud] == 'o'))
                            && (posicion + longitud + 1 < n && (expresion[posicion + longitud + 1] == 'r'))
                            && (posicion + longitud + 2 < n && (expresion[posicion + longitud + 2] == ' '))
                            )
                        {
                            longitud += 3;
                            valorToken = Token.RESERVADA_FOR;
                            break;
                        }
                        goto default;
                    default:
                        if (char.IsDigit(caracter))
                        {
                            while (posicion + longitud < n
                                    && char.IsDigit(expresion[posicion + longitud]))
                            {
                                ++longitud;
                            }

                            if (posicion + longitud < n
                                    && (expresion[posicion + longitud] == '.' || expresion[posicion + longitud] == ','))
                            {

                                longitud++;

                                while (posicion + longitud < n
                                    && char.IsDigit(expresion[posicion
                                            + longitud]))
                                {
                                    ++longitud;
                                }

                                valorToken = Token.REAL;
                            }
                            else
                            {
                                valorToken = Token.VALOR_ENTERO;
                            }
                        }else
                            if(validarIdentificador(caracter.ToString())){

                                while (posicion + longitud < n
                                    && validarIdentificador(expresion.Substring(posicion, longitud+1)))
                            {
                                ++longitud;
                            }

                                valorToken = Token.IDENTIFICADOR;
                            }
                        break;
                }

                if (valorToken.HasValue) return valorToken.Value;
            }

            return Token.FIN_ARCHIVO;
        }

        public void advance()
        {
            nuevoToken = getToken();
        }

        public bool match(Token token)
        {
            if (nuevoToken == 0)
            {
                nuevoToken = getToken();
            }

            return token == nuevoToken;
        }

        public int obtenerEntero()
        {
            return Convert.ToInt32(expresion.Substring(posicion, longitud));
        }

        public double obtenerReal()
        {
            return Convert.ToDouble(expresion.Substring(posicion, longitud));
        }

        public string obtenerSimbolo()
        {
            return expresion.Substring(posicion, longitud);
        }

        public bool validarIdentificador(string cadena)
        {
            var regex = new Regex(@"^([a-zA-Z]([a-zA-Z0-9]|_)*)$");
            return regex.IsMatch(cadena);
        }
    }
}
