using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterprete.Models
{
    public class Lexer
    {
        
    private string expresion;
    private int posicion;
    private int longitud;
    private Token nuevoToken;

    public Lexer(String expresion) {
        establecer(expresion);
    }

    public void establecer(String expresion) {
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

        while (posicion < n && expresion[posicion] == ' ') {
            ++posicion;
        }

        if (posicion < n) {
            char caracter = expresion[posicion];
            Token? valorToken = null;
            switch (caracter) {
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
                case '<':
                    if (posicion + longitud < n
                                && (expresion[posicion + longitud] == '=')){
                        ++longitud;
                        valorToken = Token.MENOR_IGUAL_QUE;
                    }else if (posicion + longitud+1 < n
                                && (expresion[posicion + longitud] == '>')){
                        ++longitud;
                        valorToken = Token.DIFERENTE;
                    }else{
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
                    valorToken = Token.IGUAL_QUE;
                    break;
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
                    }
                    break;
            }

            if (valorToken.HasValue) return valorToken.Value;
        }

        return Token.FIN_ARCHIVO;
    }

    public void advance() {
        nuevoToken = getToken();
    }

    public bool match(Token token)
    {
        if (nuevoToken == 0) {
            nuevoToken = getToken();
        }

        return token == nuevoToken;
    }

    public int obtenerEntero() {
        return Convert.ToInt32(expresion.Substring(posicion, longitud));
    }

    public double obtenerReal() {
        return Convert.ToDouble(expresion.Substring(posicion, longitud));
    }

    public string obtenerSimbolo()
    {
        return expresion.Substring(posicion, longitud);
    }
    }
}
