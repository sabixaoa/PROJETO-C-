using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projecto
{
    class Program
    {
        public static ArrayList Contentor { get; private set; }

        static void Main(string[] args)
        {
            Contentor c = new Contentor();
            Porto porto = new Porto();

            do
            {
                Console.WriteLine("Escolha uma das seguintes opcoes");
                Console.WriteLine("1-Inserir Navio");
                Console.WriteLine("2-Remover Navio");
                Console.WriteLine("3-Inserir Contentor");
                Console.WriteLine("4-Remover Contentor");
                Console.WriteLine("5-Lista de navios");
                Console.WriteLine("6-Atribuir contentor a um certo navio");
                Console.WriteLine("7-Remover contentor de um navio");
                Console.WriteLine("8-Quantos navios estao no porto?");
                Console.WriteLine("9-Todos os contentores não atribuidos a um navio");
                Console.WriteLine("10-Lista do numero de contentores de um navio");
                Console.WriteLine("11-Lista de contentores de um navio");
                Console.WriteLine("12-Guardar Ficheiro");
                Console.WriteLine("13-Carregar Ficheiro");
                Console.WriteLine("0-Sair\n\n");

                int opcao = Convert.ToInt32(Console.ReadLine());
                BinaryFormatter formatter = new BinaryFormatter();



                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("\n-------------------------------------------\n");
                        porto.AdcionarNavio();
                        Console.WriteLine("\n-------------------------------------------\n");
                        break;


                    case 2:
                        Console.WriteLine("\n-------------------------------------------\n");
                        porto.RemoverNavio();
                        Console.WriteLine("\n-------------------------------------------\n");

                        break;


                    case 3:
                        Console.WriteLine("\n-------------------------------------------\n");
                        porto.AdicionarContentores();
                        Console.WriteLine("\n-------------------------------------------\n");

                        break;

                    case 4:
                        porto.RemoverContenor();
                        Console.WriteLine("\n-------------------------------------------\n");

                        break;


                    case 5:

                        Console.WriteLine("\n-------------------------------------------\n");
                        porto.listarnavios();
                        Console.WriteLine("\n-------------------------------------------\n");

                        break;

                    case 6:
                        Console.WriteLine("\n-------------------------------------------\n");
                        porto.Adicionarcontentornavio();
                        Console.WriteLine("\n-------------------------------------------\n");

                        break;


                    case 7:
                        Console.WriteLine("\n-------------------------------------------\n");
                        porto.removercontentornavio();
                        Console.WriteLine("\n-------------------------------------------\n");
                        break;


                    case 8:
                        Console.WriteLine("\n-------------------------------------------\n");
                        Console.WriteLine("Estão no porto: " + porto.Estadonavio() + " navios");
                        Console.WriteLine("\n-------------------------------------------\n");

                        break;


                    case 9:
                        Console.WriteLine("\n-------------------------------------------\n");
                        porto.ListarContentorsemnavio(true);
                        Console.WriteLine( "\n-------------------------------------------\n");

                        break;


                    case 10:
                        Console.WriteLine("\n-------------------------------------------\n");
                        porto.ListarContentorsemnavio(false);
                        Console.WriteLine("\n-------------------------------------------\n");
                        break;


                    case 11:
                        Console.WriteLine("\n-------------------------------------------\n");
                        porto.listarcontentoresnavio();
                        Console.WriteLine("\n-------------------------------------------\n");

                        break;


                    case 12:
                        porto.Guardar(porto);
                        break;

                        


                    case 13:
                        porto = porto.Carregar();
                        break;


                    

                    case 0:
                        Environment.Exit(0);
                        //return;
                        break;

                    default:
                        Console.WriteLine("Opção Inválida");
                        break;



                }
            } while (true);

        }
    }
}
