string mensagemDeBoasVindas = "Boas vindas ao Screen Sound\n";
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("The Beatles", new List<int> { 10, 8, 10 });
bandasRegistradas.Add("Red Hot Chili Peppers", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    int opcaoEscolhidaNumerica = int.Parse(Console.ReadLine());

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBandas();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: CalcularMediaDeUmaBanda();
            break;
        case -1:
            Console.WriteLine($"Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void CalcularMediaDeUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média de avaliações de uma banda");
    Console.Write("Digite o nome da banda que deseja calcular a média: ");
    string banda = Console.ReadLine()!;
    if(bandasRegistradas.ContainsKey(banda))
    {
        List<int> avaliacao = bandasRegistradas[banda];
        
        if(avaliacao.Count > 0)
        {
            Console.WriteLine($"\nA média da banda {banda} é: {avaliacao.Average():F2}\n");
        }
        else
        {
            Console.WriteLine($"Não existe avaliação para a banda {banda} :(\n");
            Console.Write("Pressione qualquer tecla para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
    }
    else
    {
        Console.WriteLine($"A banda {banda} não está cadastrada :(\n");
        Console.Write("Pressione qualquer tecla para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void AvaliarUmaBanda()
{
    //Qual banda quer avaliar
    //Verificar se essa banda existe no dicionario

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if(bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece? ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com SUCESSO para a banda {nomeDaBanda}!");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada :( \n");
        Console.Write("Digite uma tecla para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    foreach (var banda in bandasRegistradas.Keys)
    {
        Console.WriteLine("Banda: " + banda);
    }
    Console.Write("\nDigite uma tecla para voltar ao menu principal ");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void RegistrarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(3000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

//Start

ExibirOpcoesDoMenu();