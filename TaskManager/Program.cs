using System.ComponentModel;

internal class Program
{
    // esse list é uma coisa do c# para listar em ordem algo de alguma class. No caso na class Tarefa eu declarei la que vai ter titulo, descrição etc.
    static List<Tarefa> tarefas = new List<Tarefa>();
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Gerenciador de Tarefas");
            Console.WriteLine("1. Adicionar nova Tarefa.");
            Console.WriteLine("2. Listar tarefas");
            Console.WriteLine("3. Marcar tarefa como concluida.");
            Console.WriteLine("4. Editar tarefa.");
            Console.WriteLine("5. Excluir tarefa.");
            Console.WriteLine("6. Sair.");
            string opcao = Console.ReadLine();

            if(int.TryParse(opcao, out int numeroOpcao)) // aqui é: se coneguir converter a string opcao em um numero int, prossiga com o switch | se não ele vai pro else e dizer que
                                                           //é uma opção invalida.
            {
                switch (numeroOpcao)
                {
                    case 1:
                        AdicionarTarefa();
                        break;
                    case 2: 
                        ListarTarefas();
                        break;
                    case 3:
                        MarcarTarefaComoConcluida();
                        break;
                    case 4:
                        EditarTarefa();
                        break;
                    case 5:
                        return;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }
    }
    static void AdicionarTarefa()
    {
        //aqui estou armazenando os dados sobre uma tarefa.
        Console.WriteLine("Digite o título da tarefa: ");
        string tituloTarefa  = Console.ReadLine();

        Console.WriteLine("Adicione uma descrição: ");
        string descTarefa = Console.ReadLine();

        Console.WriteLine("Adicione uma data (dd/mm/yyyy) ");
        DateTime dataVencimento;
        // esse DateTime é uma função do c# para utilizar datas
        if(DateTime.TryParse(Console.ReadLine(), out dataVencimento))
            //aqui ele vai receber o input do usuário e verificar se é uma data válida ou não.
            //se tudo estiver certo ele vai armazenar os puxando la da class Tarefa
        {
            //agora vai ser que nem o exemplo do carro, que eu crio uma lista com carros que puxa os dados, por exemplo cor modelo ano marca
            Tarefa tarefa = new Tarefa(tituloTarefa, descTarefa, dataVencimento, false);
            tarefas.Add(tarefa);
            //adicionando na lista tarefa
            Console.WriteLine("Tarefa adicionada com sucesso! ");
        }
        else
        {
            Console.WriteLine("Data inválida!");
        }

    }

    static void ListarTarefas()
    {
        //aqui uma estrutura for padrão para listar todos os itens em uma lista
        //nesse caso o ele puxa os itens da lista tarefas criada la no inicio e esse Count vai listar tudo
        for(int i = 0; i< tarefas.Count; i++)
        {
            var tarefa = tarefas[i];
            Console.WriteLine($"{i+1}. {tarefa.Titulo} - {tarefa.Descricao} | {tarefa.DataVencimento.ToShortDateString()} - {(tarefa.Concluido? "Concluido":"Pendente")}");
            //esse [i+1] vai adicionando numero nas tarefas por ordem | 1. 2.
        }
    }


    static void MarcarTarefaComoConcluida()
    {
        Console.WriteLine("Marque a tarefa a ser concluida: ");
        if(int.TryParse(Console.ReadLine(), out int numero)&& numero>0 && numero <= tarefas.Count)
        {
            tarefas[numero - 1].Concluido = true; //aqui ele esta puxando a bool e modificando 
            Console.WriteLine("Tarefa marcada como conlcuída!" );
        }
        else
        {
            Console.WriteLine("Número inválido");
        }
    }

    static void EditarTarefa()
    {
        Console.WriteLine("Selecione qual tarefa você deseja editar: ");
        ListarTarefas();
        if(int.TryParse(Console.ReadLine(),out int numero) && numero>0 && numero <= tarefas.Count)
        {
            Tarefa tarefa = tarefas[numero - 1];


            Console.WriteLine("Escolha um novo título: ");
            string novoTitulo = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoTitulo)){ //se a string novoTitulo não for nula nem espaço em branco, ai continua
                tarefa.Titulo = novoTitulo; //o tarefa esta referenciando o Tarefa class
            }

            Console.WriteLine("Escolha uma nova descrição?: ");
            string novaDescricao = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novaDescricao))
            {
                tarefa.Descricao = novaDescricao;
            }

            Console.WriteLine("Digite uma nova data de vencimento: (dd/mm/yyyy)");
            string novaData = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(novaData) && DateTime.TryParse(novaData, out DateTime novaDataVencimento))
            {
                tarefa.DataVencimento = novaDataVencimento;
            }
            Console.WriteLine("Tarefa atualizada com sucesso! ");
        }
        else
        {
            Console.WriteLine("Número inválido");
        }
    }


    static void ExcluirTarefa()
    {
        Console.WriteLine("Você deseja excluir uma tarefa? (S/N) ");
        string opcao = Console.ReadLine();
        opcao = opcao.ToUpper();
        if(opcao == "S")
        {
            Console.WriteLine("Digite o número da tarefa que deseja excluir: ");
            if (int.TryParse(Console.ReadLine(), out int numeroTarefa) && numeroTarefa>0 && numeroTarefa <= tarefas.Count)
            {
                tarefas.RemoveAt(numeroTarefa - 1); //RemoveAt remove o item localizado no índice especificado da lista. O índice sera o numero escolhido menos 1 já que o índice começa no 0
                Console.WriteLine("Tarefa removida");
            }
            else
            {
                Console.WriteLine("Número inválido");
            }
        }
        else
        {
            return;
        }

    }
}






class Tarefa
{
    public string Titulo;
    public string Descricao;
    public DateTime DataVencimento;
    public bool Concluido;

    public Tarefa(String Titulo, String Descricao, DateTime DataVencimento, bool Concluido)
    {
        this.Titulo = Titulo;
        this.Descricao = Descricao;
        this.DataVencimento = DataVencimento;
        this.Concluido = Concluido;
    }
    
}
