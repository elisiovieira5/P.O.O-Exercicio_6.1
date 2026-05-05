using System;
using System.Collections.Generic;

class Veiculo
{
    // atributos privados
    private string matricula;
    private string marca;
    private string modelo;
    private int ano;
    private double quilometragem;

    // construtor sem parametros
    public Veiculo()
    {
        matricula = "";
        marca = "";
        modelo = "";
        ano = 0;
        quilometragem = 0;
    }

    // construtor com parametros
    public Veiculo(string mat, string mar, string mod, int a, double km)
    {
        matricula = mat;
        marca = mar;
        modelo = mod;
        ano = a;
        quilometragem = km;
    }

    // propriedades
    public string Matricula
    {
        get { return matricula; }
        set { matricula = value; }
    }

    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }

    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }

    public int Ano
    {
        get { return ano; }
        set { ano = value; }
    }

    public double Quilometragem
    {
        get { return quilometragem; }
        set { quilometragem = value; }
    }

    // actualiza quilometragem depois de um aluguer
    public void ActualizarQuilometragem(double km)
    {
        quilometragem = quilometragem + km;
    }

    // mostra os dados do veiculo
    public void ApresentarDados()
    {
        Console.WriteLine("Matricula: " + matricula);
        Console.WriteLine("Marca: " + marca);
        Console.WriteLine("Modelo: " + modelo);
        Console.WriteLine("Ano: " + ano);
        Console.WriteLine("Quilometragem: " + quilometragem + " km");
        Console.WriteLine("----------------------------");
    }
}

class Program
{
    // lista de veiculos registados
    static List<Veiculo> listaVeiculos = new List<Veiculo>();

    static void Main()
    {
        int opcao = 0;

        while (opcao != 4)
        {
            Console.WriteLine("\n============================");
            Console.WriteLine("  SISTEMA DE ALUGUER");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Registar veiculo");
            Console.WriteLine("2. Actualizar quilometragem");
            Console.WriteLine("3. Ver dados de um veiculo");
            Console.WriteLine("4. Sair");
            Console.WriteLine("------------------------------");
            Console.Write("Escolha uma opcao: ");

            string entrada = Console.ReadLine();
            opcao = int.Parse(entrada);

            if (opcao == 1)
            {
                RegistarVeiculo();
            }
            else if (opcao == 2)
            {
                ActualizarQuilometragem();
            }
            else if (opcao == 3)
            {
                VerDadosVeiculo();
            }
            else if (opcao == 4)
            {
                Console.WriteLine("A sair do programa...");
            }
            else
            {
                Console.WriteLine("Opcao invalida! Tente novamente.");
            }
        }
    }

    static void RegistarVeiculo()
    {
        Console.WriteLine("\n--- Registar novo veiculo ---");

        Veiculo v = new Veiculo();

        Console.Write("Matricula: ");
        v.Matricula = Console.ReadLine();

        Console.Write("Marca: ");
        v.Marca = Console.ReadLine();

        Console.Write("Modelo: ");
        v.Modelo = Console.ReadLine();

        Console.Write("Ano de fabricacao: ");
        v.Ano = int.Parse(Console.ReadLine());

        Console.Write("Quilometragem actual: ");
        v.Quilometragem = double.Parse(Console.ReadLine());

        listaVeiculos.Add(v);

        Console.WriteLine("Veiculo registado com sucesso!");
    }

    static void ActualizarQuilometragem()
    {
        if (listaVeiculos.Count == 0)
        {
            Console.WriteLine("Nao ha veiculos registados!");
            return;
        }

        Console.WriteLine("\n--- Actualizar quilometragem ---");
        Console.WriteLine("Veiculos disponiveis:");

        for (int i = 0; i < listaVeiculos.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + listaVeiculos[i].Matricula + " - " + listaVeiculos[i].Marca + " " + listaVeiculos[i].Modelo);
        }

        Console.Write("Escolha o numero do veiculo: ");
        int numero = int.Parse(Console.ReadLine());

        if (numero < 1 || numero > listaVeiculos.Count)
        {
            Console.WriteLine("Numero invalido!");
            return;
        }

        Console.Write("Quantos km percorreu neste aluguer: ");
        double km = double.Parse(Console.ReadLine());

        listaVeiculos[numero - 1].ActualizarQuilometragem(km);

        Console.WriteLine("Quilometragem actualizada! Nova quilometragem: " + listaVeiculos[numero - 1].Quilometragem + " km");
    }

    static void VerDadosVeiculo()
    {
        if (listaVeiculos.Count == 0)
        {
            Console.WriteLine("Nao ha veiculos registados!");
            return;
        }

        Console.WriteLine("\n--- Ver dados de veiculo ---");
        Console.WriteLine("Veiculos disponiveis:");

        for (int i = 0; i < listaVeiculos.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + listaVeiculos[i].Matricula + " - " + listaVeiculos[i].Marca + " " + listaVeiculos[i].Modelo);
        }

        Console.Write("Escolha o numero do veiculo: ");
        int numero = int.Parse(Console.ReadLine());

        if (numero < 1 || numero > listaVeiculos.Count)
        {
            Console.WriteLine("Numero invalido!");
            return;
        }

        Console.WriteLine("\n--- Dados do veiculo ---");
        listaVeiculos[numero - 1].ApresentarDados();
    }
}