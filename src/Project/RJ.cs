using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Lista para armazenar jogadores registrados
    static List<Jogador> jogadoresRegistrados = new List<Jogador>();

    static void Main(string[] args)
    {
        while (true)
        {
            // Lê o comando do usuário
            string comando = Console.ReadLine();
            // Processa o comando e obtém a resposta
            string resposta = ProcessarComando(comando);
            // Exibe a resposta
            Console.WriteLine(resposta);
        }
    }

    // Método para processar os comandos
    static string ProcessarComando(string comando)
    {
        if (comando.StartsWith("RJ "))
        {
            // Chama o método para registrar jogador
            return RegistrarJogador(comando);
        }
        else if (comando == "LJ")
        {
            // Chama o método para listar jogadores
            return ListarJogadores();
        }
        else
        {
            // Retorna mensagem de instrução inválida
            return "Instrução inválida.";
        }
    }

    // Método para registrar um novo jogador
    static string RegistrarJogador(string comando)
    {
        // Extrai o nome do jogador (removendo "RJ ")
        string nomeJogador = comando.Substring(3).Trim();
        // Verifica se o jogador já está registrado
        if (jogadoresRegistrados.Any(j => j.Nome.Equals(nomeJogador, StringComparison.OrdinalIgnoreCase)))
        {
            return "Jogador existente.";
        }
        else
        {
            // Adiciona o novo jogador à lista
            jogadoresRegistrados.Add(new Jogador(nomeJogador));
            return "Jogador registado com sucesso.";
        }
    }

    // Método para listar os jogadores registrados
    static string ListarJogadores()
    {
        // Verifica se há jogadores registrados
        if (jogadoresRegistrados.Count == 0)
        {
            return "Sem jogadores registados.";
        }

        // Ordena os jogadores por número de vitórias e, em caso de empate, alfabeticamente
        var jogadoresOrdenados = jogadoresRegistrados
            .OrderByDescending(j => j.Vitorias)
            .ThenBy(j => j.Nome)
            .ToList();

        // Constrói a saída com as informações dos jogadores
        string resultado = "";
        foreach (var jogador in jogadoresOrdenados)
        {
            resultado += $"{jogador.Nome} {jogador.NumeroDeJogos} {jogador.Vitorias} {jogador.Empates} {jogador.Derrotas}\n";
        }

        return resultado.TrimEnd(); // Remove o último caractere de nova linha
    }
}
// Classe que representa um jogador
class Jogador
{
    public string Nome { get; private set; } // Nome do jogador
    public int Vitorias { get; private set; } // Número de vitórias do jogador
    public int Derrotas { get; private set; } // Número de derrotas do jogador
    public int Empates { get; private set; } // Número de empates do jogador
    public int NumeroDeJogos { get; private set; } // Número de jogos do jogador

    // Construtor da classe Jogador
    public Jogador(string nome)
    {
        Nome = nome;
        Vitorias = 0;
        Derrotas = 0;
        Empates = 0;
        NumeroDeJogos = 0;
    }

    // Métodos para registrar vitórias, derrotas e empates, atualizando o número de jogos
    public void RegistrarVitoria()
    {
        Vitorias++;
        NumeroDeJogos++;
    }

    public void RegistrarDerrota()
    {
        Derrotas++;
        NumeroDeJogos++;
    }

    public void RegistrarEmpate()
    {
        Empates++;
        NumeroDeJogos++;
    }
}
