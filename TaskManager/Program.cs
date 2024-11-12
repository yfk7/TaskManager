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
            Console.WriteLine("3. Editar Tarefa existente.");
            Console.WriteLine("4. Excluir nova Tarefa.");
            Console.WriteLine("5. Marcar como concluída.");
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
                        break;
                    case 4:
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
                                        //static para poder acessar do metodo main
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
