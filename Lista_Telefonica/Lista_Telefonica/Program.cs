using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

// Classe ComparadorNome para comparar os valores na coluna de nomes
public class ComparadorNome : IComparer
{
    public int Compare(object x, object y)
    {
        string nome1 = ((string[,])x)[((string[,])x).GetLowerBound(0), 1];
        string nome2 = ((string[,])y)[((string[,])y).GetLowerBound(0), 1];

        return string.Compare(nome1, nome2);
    }
}

class ListaTelefonica
{
    public static string[,] listaTel = new string[9999, 3];
    public static int ID = 0;
    static void Main()
    {
        listaTel[0, 0] = "0";
        listaTel[0, 1] = "Carioca";
        listaTel[0, 2] = "8984";

        listaTel[1, 0] = "1";
        listaTel[1, 1] = "Davi";
        listaTel[1, 2] = "666";

        listaTel[2, 0] = "2";
        listaTel[2, 1] = "Julio";
        listaTel[2, 2] = "56654";

        ID = 3;



        while (true)
        {
            menu();
        }

    }

    static void menu()
    {
        Console.WriteLine("_________________________________________________________");
        Console.WriteLine("Lista Telefônica");
        Console.WriteLine("Pressione 1. Adicionar Contato");
        Console.WriteLine("Pressione 2. Buscar Contato por Telefone");
        Console.WriteLine("Pressione 3. Buscar Contato por nome");
        Console.WriteLine("Pressione 4. Excluir Contato Completo por Telefone");
        Console.WriteLine("Pressione 5. Excluir Contato Completo por Nome");
        Console.WriteLine("Pressione 6. Ordenar Contatos por Telefone");
        Console.WriteLine("Pressione 7. Ordenar Contatos por Nome");
        Console.WriteLine("Pressione 8. Lista Todos os Contatos");
        Console.WriteLine("_________________________________________________________");

        int escolha = int.Parse(Console.ReadLine());

        escolheAcao(escolha);
    }
    static void escolheAcao(int escolha)
    {

        switch (escolha)
        {
            case 1:
                lerInformacoes();
                break;
            case 2:
                buscarContatoTelefone();
                break;
            case 3:
                buscarContatoNome();
                break;
            case 4:
                excluirContatoTelefone();
                break;
            case 5:
                excluirContatoNome();
                break;
            case 6:
                ordenarContatoTelefone();
                break;
            case 7:
                ordenarContatoNome();
                break;
            case 8:
                listarListaTel();
                break;
        }
    }

    static void listarListaTel()
    {
        Console.WriteLine("-------------------------------------");
        for (int i = 0; i < ID; i++)
        {
            if (listaTel[i, 0] != null)
            {
                mostrarRegistro(i);
            }
        }
        Console.WriteLine("-------------------------------------");
    }

    static void excluirRegistro(int i)
    {
        listaTel[i, 0] = " ";
        listaTel[i, 1] = " ";
        listaTel[i, 2] = " ";
    }

    static void excluirContatoNome()
    {
        Console.WriteLine("Digite um nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("-------------------------------------");

        for (int i = 0; i < listaTel.GetLength(0); i++)
        {
            if (listaTel[i, 1] == nome)
            {
                excluirRegistro(i);
                Console.WriteLine("Contato Excluído!");
            }
        }
        Console.WriteLine("-------------------------------------");
    }

    static void excluirContatoTelefone()
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Digite um número de telefone:");
        uint telefone = uint.Parse(Console.ReadLine());
        Console.WriteLine("-------------------------------------");

        for (int i = 0; i < listaTel.GetLength(0); i++)
        {
            if (uint.TryParse(listaTel[i, 2], out uint numero) && numero == telefone)
            {
                excluirRegistro(i);
                Console.WriteLine("Contato Excluído!");
            }
        }
        Console.WriteLine("-------------------------------------");
    }

    static void mostrarRegistro(int i)
    {
        Console.Write("ID: " + listaTel[i, 0]);
        Console.Write(" | Nome: " + listaTel[i, 1]);
        Console.WriteLine(" | Telefone: " + listaTel[i, 2]);
    }

    static void buscarContatoNome()
    {
        Console.WriteLine("Digite um nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("-------------------------------------");

        for (int i = 0; i < listaTel.GetLength(0); i++)
        {
            if (listaTel[i, 1] == nome)
            {
                mostrarRegistro(i);
            }
        }
        Console.WriteLine("-------------------------------------");
    }

    static void buscarContatoTelefone()
    {
        Console.WriteLine("Digite um número de telefone:");
        uint telefone = uint.Parse(Console.ReadLine());
        Console.WriteLine("-------------------------------------");

        for (int i = 0; i < listaTel.GetLength(0); i++)
        {
            if (uint.TryParse(listaTel[i, 2], out uint numero) && numero == telefone)
            {
                mostrarRegistro(i);
            }
        }
        Console.WriteLine("-------------------------------------");
    }

    static void adicionarContato(string nome, uint telefone)
    {
        listaTel[ID, 0] = ID.ToString();
        listaTel[ID, 1] = nome;
        listaTel[ID, 2] = telefone.ToString();
        ID++;
    }

    static void lerInformacoes()
    {
        uint telefone;
        string nome;
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Insira um Nome:");
        nome = Console.ReadLine();
        Console.WriteLine("Insira um Telefone:");
        telefone = uint.Parse(Console.ReadLine());
        adicionarContato(nome, telefone);
        Console.WriteLine("-------------------------------------");
    }

    static void ordenarContatoNome()
    {
        Console.WriteLine("-------------------------------------");
        for (int i = 0; i < ID - 1; i++)
        {
            for (int j = 0; j < ID - i - 1; j++)
            {
                string nome1 = listaTel[j, 1];
                string nome2 = listaTel[j + 1, 1];

                if (string.Compare(nome1, nome2) > 0)
                {
                    // Trocar os elementos de posição
                    string tempID = listaTel[j, 0];
                    string tempNome = listaTel[j, 1];
                    string tempTelefone = listaTel[j, 2];

                    listaTel[j, 0] = listaTel[j + 1, 0];
                    listaTel[j, 1] = listaTel[j + 1, 1];
                    listaTel[j, 2] = listaTel[j + 1, 2];

                    listaTel[j + 1, 0] = tempID;
                    listaTel[j + 1, 1] = tempNome;
                    listaTel[j + 1, 2] = tempTelefone;
                }
            }
        }
        listarListaTel();
        Console.WriteLine("-------------------------------------");
    }

    static void ordenarContatoTelefone()
    {
        Console.WriteLine("-------------------------------------");
        for (int i = 0; i < ID - 1; i++)
        {
            for (int j = 0; j < ID - i - 1; j++)
            {
                uint telefone1, telefone2;

                if (uint.TryParse(listaTel[j, 2], out telefone1) && uint.TryParse(listaTel[j + 1, 2], out telefone2))
                {
                    if (telefone1 > telefone2)
                    {
                        // Trocar os elementos de posição
                        string tempID = listaTel[j, 0];
                        string tempNome = listaTel[j, 1];
                        string tempTelefone = listaTel[j, 2];

                        listaTel[j, 0] = listaTel[j + 1, 0];
                        listaTel[j, 1] = listaTel[j + 1, 1];
                        listaTel[j, 2] = listaTel[j + 1, 2];

                        listaTel[j + 1, 0] = tempID;
                        listaTel[j + 1, 1] = tempNome;
                        listaTel[j + 1, 2] = tempTelefone;
                    }
                }
            }
        }
        listarListaTel();
        Console.WriteLine("-------------------------------------");
    }

}