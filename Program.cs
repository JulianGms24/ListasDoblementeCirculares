using System;

// Clase Nodo: representa un elemento de la lista
public class Nodo
{
    public int Dato;           // Valor que guarda el nodo
    public Nodo Siguiente;     // Referencia al siguiente nodo
    public Nodo Anterior;      // Referencia al nodo anterior

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
        Anterior = null;
    }
}

// Clase ListaDobleCircular: representa toda la lista
public class ListaDobleCircular
{
    private Nodo inicio;   // Nodo que marca el inicio de la lista

    public ListaDobleCircular()
    {
        inicio = null;     // La lista comienza vacía
    }

    // Insertar al inicio de la lista
    public void InsertarInicio(int dato)
    {
        Nodo nuevo = new Nodo(dato); // Creamos un nuevo nodo
        if (inicio == null) // Si la lista está vacía
        {
            nuevo.Siguiente = nuevo;
            nuevo.Anterior = nuevo;
            inicio = nuevo;
        }
        else
        {
            Nodo ultimo = inicio.Anterior; // Último nodo (circular)
            nuevo.Siguiente = inicio;
            nuevo.Anterior = ultimo;
            inicio.Anterior = nuevo;
            ultimo.Siguiente = nuevo;
            inicio = nuevo; // Actualizamos el inicio
        }
    }

    // Insertar al final de la lista
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
            // El inicio no cambia aquí
        }
    }

    // Eliminar un nodo por su valor
    public void Eliminar(int dato)
    {
        if (inicio == null)
        {
            Console.WriteLine("Lista vacía.");
            return;
        }

        Nodo actual = inicio;

        // Recorremos la lista hasta volver al inicio
        do
        {
            if (actual.Dato == dato)
            {
                if (actual.Siguiente == actual) // Solo hay un nodo
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

                Console.WriteLine($"Nodo con valor {dato} eliminado.");
                return;
            }

            actual = actual.Siguiente;

        } while (actual != inicio);

        Console.WriteLine($"Valor {dato} no encontrado.");
    }

    // Mostrar la lista hacia adelante
    public void MostrarAdelante()
    {
        if (inicio == null)
        {
            Console.WriteLine("Lista vacía.");
            return;
        }

        Nodo actual = inicio;
        Console.Write("Lista hacia adelante: ");
        do
        {
            Console.Write(actual.Dato + " ");
            actual = actual.Siguiente;
        } while (actual != inicio);
        Console.WriteLine();
    }

    // Mostrar la lista hacia atrás
    public void MostrarAtras()
    {
        if (inicio == null)
        {
            Console.WriteLine("Lista vacía.");
            return;
        }

        Nodo ultimo = inicio.Anterior;
        Nodo actual = ultimo;
        Console.Write("Lista hacia atrás: ");
        do
        {
            Console.Write(actual.Dato + " ");
            actual = actual.Anterior;
        } while (actual != ultimo);
        Console.WriteLine();
    }
}

// Clase principal para probar todo
class Program
{
    static void Main(string[] args)
    {
        ListaDobleCircular lista = new ListaDobleCircular();

        Console.WriteLine("Insertando nodos...");
        lista.InsertarFinal(10);
        lista.InsertarFinal(20);
        lista.InsertarInicio(5);
        lista.InsertarFinal(30);

        lista.MostrarAdelante(); // Esperado: 5 10 20 30
        lista.MostrarAtras();    // Esperado: 30 20 10 5

        Console.WriteLine("\nEliminando nodo 20...");
        lista.Eliminar(20);

        lista.MostrarAdelante(); // Esperado: 5 10 30

        Console.WriteLine("\nEliminando nodo 5...");
        lista.Eliminar(5);

        lista.MostrarAdelante(); // Esperado: 10 30

        Console.WriteLine("\nEliminando nodo 100 (no existe)...");
        lista.Eliminar(100);     // Esperado: Valor 100 no encontrado
    }
}
