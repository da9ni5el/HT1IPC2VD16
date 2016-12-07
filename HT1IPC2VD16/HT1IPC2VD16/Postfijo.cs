using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace HT1IPC2VD16
{
    class Postfijo
    {

        Stack<int> precedencia = new Stack<int>();
        Stack<char> pila_operador = new Stack<char>();
        List<String> postfijo = new List<string>();

        public double post_fijo(string texto)
        {
            postfijo.Clear();

            string temporalPF = string.Empty;
            double num1, num2, resultado = 0;
            Stack<double> salida = new Stack<double>();
            precedencia.Clear();
            pila_operador.Clear();

            for (int i = 0; i <= texto.Length - 1; i++)
            {
                if (char.IsDigit(texto[i]) == true || texto[i] == '.')
                {
                    temporalPF += texto[i];
                    if (i == texto.Length - 1)
                    {
                        postfijo.Add(temporalPF);
                        //limpiar();
                    }
                } else
                {
                    postfijo.Add(temporalPF);
                    temporalPF = string.Empty;
                    if (pila_operador.Count() == 0)
                    {
                        //llamar aqui a insertar :v
                        insertar(texto[i]);

                    } else
                    {
                        if (prec(texto[i]) > precedencia.Peek())
                        {
                            insertar(texto[i]);
                        } else if (prec(texto[i]) == precedencia.Peek())
                        {
                            postfijo.Add(pila_operador.Pop().ToString());
                            precedencia.Pop();
                            insertar(texto[i]);
                        } else if (prec(texto[i]) < precedencia.Peek())
                        {
                            limpiar();
                            insertar(texto[i]);
                        }
                    }

                }
            }
            //for(int j=0;j<=postfijo.Count -1; j++)
            //{
            //    if(char.IsDigit(postfijo[j])== true)
            //    {
            //        postfijo.i
            //    }
            //}
            foreach (var item in postfijo)
            {
                if (char.IsDigit(Convert.ToChar(item)) == true || char.IsNumber(Convert.ToChar(item)) == true)
                {
                    salida.Push(Convert.ToDouble(item));
                }
                else
                {
                    try
                    {
                        num1 = salida.Pop();
                        num2 = salida.Pop();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    if (item == "+")
                    {
                        resultado = num1 + num2;
                        salida.Push(resultado);
                    }
                    else if (item == "-")
                    {
                        resultado = num1 - num2;
                        salida.Push(resultado);
                    }
                    else if (item == "*")
                    {
                        resultado = num1 * num2;
                        salida.Push(resultado);
                    } else if (item == "/")
                    {
                        resultado = num1 / num2;
                        salida.Push(resultado);
                    } else if (item == "^")
                    {
                        //resultado = num1 ^ num2;
                        salida.Push(resultado);
                    }
                }
            }
            return resultado;
        }

        public int prec(char texto)
        {
            if (texto=='+' || texto == '-')
            {
                return 1;
            }else if (texto=='*' || texto =='/')
            {
                return 2;
            }else if (texto == '^')
            {
                return 3;
            }else
            {
                return 100;
            }
        }



        public void insertar(char op)
        {
            if (op == '+' || op =='-')
            {
                precedencia.Push(1);
                pila_operador.Push(op);
            } else if (op == '*' || op == '/')
            {
                precedencia.Push(2);
                pila_operador.Push(op);
            } else if (op == '^')
            {
                precedencia.Push(3);
                pila_operador.Push(op);
            }
        }

        public void limpiar()
        {
            for(int i=0;i<=pila_operador.Count - 1; i++)
            {
                pila_operador.Pop();
                precedencia.Pop();
            }
            
        }


    }
}
