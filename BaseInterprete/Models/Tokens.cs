using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterprete.Models
{
    public enum Token
    {

        FIN_ARCHIVO = -1,
        ERROR = -2,

        SUMA = 1,
        RESTA = 2,
        MULTIPLICACION = 3,
        DIVISION = 4,
        POTENCIA = 5,
        MODULO = 6,
        DIVISION_ENTERA = 7,

        ABRIR_PARENTESIS = 8,
        CERRAR_PARENTESIS = 9,
        PI = 10,


        MENOR_QUE = 11,
        MAYOR_QUE = 12,
        IGUAL_QUE = 13,
        MENOR_IGUAL_QUE = 14,
        MAYOR_IGUAL_QUE = 15,
        DIFERENTE = 16,

        Y_LOGICO = 17,
        O_LOGICO = 18,
        NO_LOGICO = 19,

        COMA = 21,
        PUNTO_COMA = 22,
        ABRIR_CORCHETE = 23,
        CERRAR_CORCHETE = 24,
        ABRIR_LLAVE = 25,
        CERRAR_LLAVE = 26,

        RESERVADA_IF = 26,
        RESERVADA_ELSE = 27,
        RESERVADA_FOR = 28,
        RESERVADA_WHILE = 29,

        CADENA_STRING = 30,

        RESERVADA_TRUE = 31,
        RESERVADA_FALSE = 32,

        VALOR_ENTERO = 100,
        VALOR_REAL = 101,
        VALOR_LOGICO = 102,
        VALOR_CARACTER = 103,
        VALOR_CADENA = 104,
        IDENTIFICADOR = 105,
        ASIGNACION = 106,
    }
}
