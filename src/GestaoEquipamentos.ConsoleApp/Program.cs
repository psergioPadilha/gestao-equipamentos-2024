
using System.Reflection.Metadata.Ecma335;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        public static Equipamento[] listaEquipamentos = new Equipamento[100];
        public static int indiceLista = -1;

        static void Main(string[] args)
        {
            while (true)
            {
                string opcao = Menu();

                VerificaOpcoesDeMenu(opcao);

                Console.ReadLine();
            }
        }

        #region Cabecalho
        static void Cabecalho(string titulo)
        {
            Console.Clear();
            Console.WriteLine("***************************************************");
            Console.WriteLine("*****         ACADEMIA DO PROGRAMADOR         *****");
            Console.WriteLine("*****     Programa Gestor de Equipamento      *****");
            Console.WriteLine("***************************************************");
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine();
        }
        #endregion

        #region Menu
        static string Menu()
        {
            Cabecalho("O que deseeja realizar?");
            Console.WriteLine("(1)Cadastrar Equimapento;");
            Console.WriteLine("(2)Relatório de Estoque;");
            Console.WriteLine("(3)Editar listaEquipamentos;");
            Console.WriteLine("(4)Excluir listaEquipamentos;");
            Console.WriteLine("(5)Sair do sistema.");
            Console.WriteLine();
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();
            return opcao;
        }
        #endregion

        #region Função verificadora e validadora da opção de menu
        public static void VerificaOpcoesDeMenu(string opcao)
        {
            while ((opcao != "1") && (opcao != "2") && (opcao != "3") && (opcao != "4") && (opcao != "5"))
            {
                Cabecalho("Opção inválida, por favor digite novamente...");
                //Console.Write("Opção inválida, por favor digite novamente...");
                Console.ReadKey();
                opcao = Menu();
            }
            switch (opcao)
            {
                case "1":
                    MenuCadastro();
                    break;
                case "2":
                    MenuRelatorio();
                    break;
                case "3":
                    MenuEditar();
                    break;
                case "4":
                    MenuExcluir();
                    break;
                case "5":       //Se opção for igaual a sair deve perguntar para o usuário confirmar saída
                    if (ConfirmaSaida())
                        Environment.Exit(0);
                    break;
            }
        }
        #endregion

        #region Confirmação de saída do sistema
        private static bool ConfirmaSaida()
        {
            Cabecalho("Deseja mesmo sair do Sistema?");

            Console.WriteLine("(1)Sair\t(2)Continuar");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();
            
            while ((opcao != "1") && (opcao != "2"))
            {
                Cabecalho("Deseja mesmo sair do Sistema?");

                Console.Write("Opção inválida, por favor digite novamente...");
                Console.ReadKey();
                Cabecalho("Deseja mesmo sair do Sistema?");
                Console.WriteLine("(1)Sair\t(2)Continuar");
                Console.Write("Opção: ");
                opcao = Console.ReadLine();
            }
            if(opcao == "1")
                return true;
            else
            return false;
        }
        #endregion

        public static void MenuCadastro()
        {
            Cabecalho("Cadastrar Equipamento!");

            Console.Write("Equipamento: ");
            string nomeEquipamento = Console.ReadLine();

            Console.Write("Preço R$: ");
            decimal precoEquipamento = decimal.Parse(Console.ReadLine());

            Console.Write("Número de série: ");
            string serieEquipamento = Console.ReadLine();

            Console.Write("Data de fabricação: ");
            string dataFabricacao = Console.ReadLine();

            Console.Write("Fabricante: ");
            string fabricanteEquipamento = Console.ReadLine();

            Fabricante fabricante = new Fabricante(fabricanteEquipamento);
            Equipamento equipamento = new Equipamento(nomeEquipamento, precoEquipamento, serieEquipamento, dataFabricacao, fabricante);
            indiceLista = indiceLista + 1;
            listaEquipamentos[indiceLista] = equipamento;
        }

        private static void MenuRelatorio()
        {
            Cabecalho("Relatório de Equipamentos!");

            for (int i = 0; i < listaEquipamentos.Length; i++)
            {
                if (listaEquipamentos[i] != null)
                {
                    Console.WriteLine("Equipamento: " + listaEquipamentos[i].nomeEquipamento);
                    Console.WriteLine("Preço R$: " + listaEquipamentos[i].preco);
                    Console.WriteLine("Nº série: " + listaEquipamentos[i].numeroSerie);
                    Console.WriteLine("Data fabricação: " + listaEquipamentos[i].dataFabricacao);
                    Console.WriteLine("Fabricante: " + listaEquipamentos[i].novoFabricante.fabricante);
                    Console.WriteLine();
                }
                else
                    continue;
            }
        }
        private static void MenuEditar()
        {
            Cabecalho("Editar Equipamento!");
        }

        private static void MenuExcluir()
        {
            Cabecalho("Excluir Equipamento!");
        }
    }
}
