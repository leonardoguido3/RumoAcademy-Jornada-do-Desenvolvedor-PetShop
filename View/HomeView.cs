using PetShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.View
{
    public class HomeView
    {
        private void TitleSystem()
        {
            //Funcao de titulo do sistema
            Console.WriteLine("  =============================================\n");
            Console.WriteLine("  ================= PET SHOP ==================\n");
            Console.WriteLine($"  ============ {DateTime.Now.ToString("dd/MM/yyyy HH:mm")} ===============\n");
            Console.WriteLine("  =============================================\n");
        }

        public void DashBoard()
        {
            while (true)
            {
                // tela inicial do sistema PetShop
                Console.Clear();
                TitleSystem();
                Console.WriteLine(" BEM VINDO!");
                Console.WriteLine(" ESCOLHA ABAIXO UMA OPÇÃO");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" [1] - CADASTRAR UM NOVO CLIENTE");
                Console.WriteLine(" [2] - LISTAR TODOS OS CLIENTES");
                Console.WriteLine(" [3] - BUSCAR CLIENTE POR CPF");
                Console.WriteLine(" [4] - LISTAR OS ANIVERSARIANTES DO MÊS");
                Console.WriteLine(" [5] - EXCLUIR UM CLIENTE POR CPF");
                Console.WriteLine(" [0] - SAIR DO SISTEMA");
                Console.WriteLine(Environment.NewLine);
                Console.Write(" DIGITE A OPERAÇÃO QUE DESEJA: ");
                var option = Console.ReadLine();

                // try catch para tratar os erros dos dados
                try
                {
                    // switch para que o cliente escolha o que deseja fazer
                    switch (option)
                    {
                        case "1":
                            // caso escolha 1, ela irá limpar a tela console e enviar para a funcao de captura de valores, para adicionar um cliente
                            Console.Clear();
                            InsertClient();
                            break;
                        case "2":
                            // caso escolha 2, também limpara a tela, mas irá para o metodo de listar todos os clientes
                            Console.Clear();
                            GetAllClient();
                            break;
                        case "3":
                            // caso seja 3, o console irá para o metodo de buscar cliente específico por nome ou cpf
                            Console.Clear();
                            //BuscarCliente();
                            break;
                        case "4":
                            // caso 4, entrara no metodo de buscar aniversariantes do mês
                            Console.Clear();
                            //BuscarAniversarianteData();
                            break;
                        case "5":
                            // caso 5, entrara no metodo de exclusao do cliente
                            Console.Clear();
                            //ExcluirCliente();
                            break;
                        case "0":
                            // caso 0 ele irá enviar uma mensagem de finalização. e apos um delay de 2s irá sair
                            Console.Clear();
                            TitleSystem();
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine(" SISTEMA FINALIZADO, OBRIGADO!");
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine(Environment.NewLine);
                            Environment.Exit(2);
                            break;
                        default:
                            // o default eu deixei como uma opção de erro, que retorna uma mensagem junto com a dashboard
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine(" A OPÇÃO ESCOLHIDA É INVÁLIDA, TENTE NOVAMENTE!");
                            Console.WriteLine(Environment.NewLine);
                            System.Threading.Thread.Sleep(1000);
                            continue;
                    }
                }
                // retorno dos erros da tratativa
                catch (InvalidOperationException ex)
                {
                    Console.Clear();
                    TitleSystem();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(Environment.NewLine);
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        public void InsertClient()
        {
            ClienteController cliente = new ClienteController();

            // chamo o titulo do sistema e capturo os valores
            TitleSystem();
            Console.Write(" DIGITE O NOME DO CLIENTE: ");
            var name = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException(" O NOME NÃO PODE SER NULO OU ESTAR EM BRANCO.");

            Console.Write($" DIGITE O CPF DO CLIENTE {name.ToUpper()} (123.456.789-00): ");
            var CPFCliente = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            if (string.IsNullOrWhiteSpace(CPFCliente))
                throw new InvalidOperationException(" O CPF NÃO PODE SER NULO OU ESTAR EM BRANCO.");

            Console.Write($" DIGITE A DATA DE NASCIMENTO (dd/mm/aaaa): {name.ToUpper()}: ");
            var dataNascimento = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            if (string.IsNullOrWhiteSpace(dataNascimento))
                throw new InvalidOperationException(" A DATA DE NASCIMENTO NÃO SER NULA OU ESTAR EM BRANCO.");

            Console.Write($" DIGITE O TELEFONE DE CONTATO {name.ToUpper()} ((DDD) XXXXX-XXXX): ");
            var telefone = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);

            var insert = cliente.Insert(name, CPFCliente, dataNascimento, telefone);

            if (!insert)
                throw new InvalidOperationException($" HOUVE UM NA INSERÇÃO DOS DADOS, TENTE NOVAMENTE!");
          
            // caso adicionado, ele retorna uma mensagem de sucesso e volta para a dashboard de opções
            Console.Clear();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($" CLIENTE CADASTRADO COM SUCESSO!");
            Console.WriteLine(Environment.NewLine);
            System.Threading.Thread.Sleep(1000);
            DashBoard();          
        }

        public void GetAllClient()
        {
            ClienteController controller = new ClienteController();
            List<Models.ClienteModel> Clientes = new List<Models.ClienteModel>();

            // limpo a tela e chamo novamente o titulo do sistema com a função escolhida pelo cliente
            Console.Clear();
            TitleSystem();
            var name = "";

            Console.Write(" DESEJA REALIZAR A PESQUISA COM UM NOME ESPECÍFICO? [S] SIM OU [N] NÃO: ");
            var option = Console.ReadLine().ToUpper();
            
            switch (option)
            {
                case "S":
                    Console.WriteLine(Environment.NewLine);
                    Console.Write(" DIGITE O NOME DA PESSOA QUE DESEJA PROCURAR: ");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                        throw new InvalidOperationException(" O NOME NÃO PODE SER NULO OU ESTAR EM BRANCO.");

                        Clientes = controller.GetAll(name);
                    break;
                case "N":
                    Clientes = controller.GetAll(name);
                    break;

                default:
                    Console.WriteLine(" COMANDO NÃO ENTENDIDO.");
                    Console.WriteLine(" PRESSIONE QUALQUER TECLA PARA VOLTAR AO MENU PRINCIAL.");
                    Console.ReadLine();
                    Console.Clear();
                    DashBoard();
                    break;
            }
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine(" LISTAGEM DE CLIENTES");
            Console.WriteLine(Environment.NewLine);

            if (Clientes is null)
                throw new InvalidOperationException($" HOUVE UM ERRO NA BUSCA DOS DADOS, TENTE NOVAMENTE!");

            foreach (var cliente in Clientes)
            {
                Console.WriteLine($"  NOME: {cliente.Nome.ToUpper()} || CPF: {cliente.CpfCliente} || NASCIMENTO: {cliente.Nascimento.ToString("dd/MM/yyy")} || TELEFONE: {cliente.Telefone}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(" FIM DA LISTA");
            Console.WriteLine(Environment.NewLine);
            Console.Write(" PRESSIONE QUALQUER TECLA PARA VOLTAR AO MENU PRINCIAL.");
            Console.ReadLine();
            Console.Clear();
            DashBoard();
        }
    }
}
