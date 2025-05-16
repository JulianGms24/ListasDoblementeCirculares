using System;

class Nodo
{
    public int Dato;
    public Nodo Siguiente;
    public Nodo Anterior;

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
        Anterior = null;
    }
}

class ListaDobleCircular
{
    private Nodo inicio;

    public void InsertarInicio(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        if (inicio == null)
        {
            nuevo.Siguiente = nuevo;
            nuevo.Anterior = nuevo;
            inicio = nuevo;
        }
        else
        {
            Nodo ultimo = inicio.Anterior;
            nuevo.Siguiente = inicio;
            nuevo.Anterior = ultimo;
            ultimo.Siguiente = nuevo;
            inicio.Anterior = nuevo;
            inicio = nuevo;
        }
    }

    public void InsertarFinal(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        if (inicio == null)
        {
            nuevo.Siguiente = nuevo;
            nuevo.Anterior = nuevo;
            inicio = nuevo;
        }
        else
        {
            Nodo ultimo = inicio.Anterior;
            nuevo.Siguiente = inicio;
            nuevo.Anterior = ultimo;
            ultimo.Siguiente = nuevo;
            inicio.Anterior = nuevo;
        }
    }

    public bool Eliminar(int dato)
    {
        if (inicio == null) return false;

        Nodo actual = inicio;
        do
        {
            if (actual.Dato == dato)
            {
                if (actual.Siguiente == actual)
                {
                    inicio = null;
                }
                else
                {
                    actual.Anterior.Siguiente = actual.Siguiente;
                    actual.Siguiente.Anterior = actual.Anterior;
                    if (actual == inicio)
                        inicio = actual.Siguiente;
                }
                return true;
            }
            actual = actual.Siguiente;
        } while (actual != inicio);

        return false;
    }

    public void MostrarAdelante()
    {
        if (inicio == null)
        {
            Console.WriteLine("Lista vacía");
            return;
        }

        Nodo actual = inicio;
        do
        {
            Console.Write($"{actual.Dato} ");
            actual = actual.Siguiente;
        } while (actual != inicio);
        Console.WriteLine();
    }

    public void MostrarAtras()
    {
        if (inicio == null)
        {
            Console.WriteLine("Lista vacía");
            return;
        }

        Nodo actual = inicio.Anterior;
        do
        {
            Console.Write($"{actual.Dato} ");
            actual = actual.Anterior;
        } while (actual != inicio.Anterior);
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        ListaDobleCircular lista = new ListaDobleCircular();
        int opcion;

        do
        {
            Console.WriteLine("\n--- Lista Doblemente Circular ---");
            Console.WriteLine("1. Insertar al inicio");
            Console.WriteLine("2. Insertar al final");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Mostrar adelante");
            Console.WriteLine("5. Mostrar atrás");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Dato a insertar al inicio: ");
                    lista.InsertarInicio(int.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.Write("Dato a insertar al final: ");
                    lista.InsertarFinal(int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.Write("Dato a eliminar: ");
                    bool eliminado = lista.Eliminar(int.Parse(Console.ReadLine()));
                    Console.WriteLine(eliminado ? "Eliminado." : "Dato no encontrado.");
                    break;
                case 4:
                    Console.WriteLine("Lista hacia adelante:");
                    lista.MostrarAdelante();
                    break;
                case 5:
                    Console.WriteLine("Lista hacia atrás:");
                    lista.MostrarAtras();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }
}
