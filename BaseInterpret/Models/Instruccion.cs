
namespace BaseInterprete.Models
{
    public enum Instruccion
    {
        FIN = -1,

        SUMA = 1,
        RESTA = 2,
        MULTIPLICACION = 3,
        DIVISION = 4,
        POTENCIA = 5,
        MODULO = 6,
        DIVISION_ENTERA = 7,

        MENOR_QUE = 11,
        MAYOR_QUE = 12,
        IGUAL = 13,
        MENOR_IGUAL_QUE = 14,
        MAYOR_IGUAL_QUE = 15,
        DIFERENTE = 16,

        Y_LOGICO = 17,
        O_LOGICO = 18,
        NO_LOGICO = 19,

        PUSH_NUMERO_ENTERO = 100,
        PUSH_NUMERO_REAL = 101,
        PUSH_IDENTIFICADOR = 102,
        ASIGNACION = 103,
        PUSH_VARIABLE_CADENA = 104,
        PUSH_VARIABLE_TRUE = 105,
        PUSH_VARIABLE_FALSE = 106,

        PRINT = 200,
        POP = 201,



        RAIZ_CUADRADA = 400,
        VALOR_ABSOLUTO = 401,
        LOGARITMO_NATURAL = 402,
        EXPONENCIAL = 403,
        SENO = 404,
        COSENO = 405,
        TANGENTE = 406,
        ALEATORIO = 407
    }
}
