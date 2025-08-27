using System;
using System.ComponentModel;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    public class Program
    {
        static List<Funcionario> List = new List<Funcionario>();

        static void Main(string[] args)
        {
            // CriarLista();
            // ObterPorNome(); // Exercício 1 
            // ObterFuncionariosRecentes(); // Exercício 2
            // ObterEstatisticas(); // Exercício 3 
            // ValidarSalarioAdmissao(); // Exercício 4
            // ValidarNome(); // Exercício 5
            // ObterPorTipo(); // Exercício 6 
            // CalcularDescontoINSS();
            DetalharData();

        }

        // EXERCICIOS
        public static void ObterPorNome() // Feito
        {
            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();
            Funcionario fBusca = List.Find(x => x.Nome == nome);

            if (fBusca == null) {
                Console.WriteLine("Não encontrado");
            } else {
                Console.WriteLine($"Funcionário encontrado: {fBusca.Nome}");
            }
        }

        public static void ObterFuncionariosRecentes() // Feito
        {
            // Remove funcionários com Id menor que 4
            List.RemoveAll(f => f.Id < 4);

            // Ordena a lista em ordem decrescente de salário
            List = List.OrderByDescending(f => f.Salario).ToList();

            // Exibe a lista filtrada e ordenada
            string dados = "";
            for (int i = 0; i < List.Count; i++) {
                dados += string.Format("Id: {0} \n", List[i].Id);
                dados += string.Format("Nome: {0} \n", List[i].Nome);
                dados += string.Format("CPF: {0} \n", List[i].Cpf);
                dados += string.Format("Admissao: {0:dd/MM/yyyy} \n", List[i].DataAdmissao);
                dados += string.Format("Salario: {0:c2} \n", List[i].Salario);
                dados += string.Format("Tipo: {0} \n",  List[i].TipoFuncionario);
                dados += "\n";
            }
            Console.WriteLine(dados);  
        }

        public static void ObterEstatisticas() // Feito
        {
            int qtdFuncionarios = List.Count;
            decimal somaSalarios = List.Sum(f => f.Salario);
            Console.WriteLine($"Quantidade de Funcionários: {qtdFuncionarios}");
            Console.WriteLine($"Soma dos Salários: {somaSalarios:c2}");
        }
        
        public static void ValidarSalarioAdmissao() // Feito
        {
            Funcionario funcionario = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            funcionario.Nome = Console.ReadLine();
            Console.WriteLine("Digite o salário: ");
            funcionario.Salario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite a data de admissão: ");
            funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if (funcionario.Salario <= 0) 
            {
                Console.WriteLine("Salário deve ser maior que zero.");
                return;
            } else if (funcionario.DataAdmissao > DateTime.Now) {
                Console.WriteLine("Data de admissão não pode ser futura.");
                return;
            } else {
                List.Add(funcionario);
                ExibirLista();
            }
        }

        public static void ValidarNome() // Feito
        {
            Funcionario funcionario = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            funcionario.Nome = Console.ReadLine();
            Console.WriteLine("Digite o salário: ");
            funcionario.Salario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite a data de admissão: ");
            funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if ((funcionario.Nome).Length < 2) 
            {
                Console.WriteLine("O nome deve ter pelo menos 2 caracteres.");
                return;
            } else {
                List.Add(funcionario);
                ExibirLista();
            }
        }

        public static void ObterPorTipo() // Feito 
        {
            Console.WriteLine("Digite o tipo (1 - CLT || 2 - Aprendiz): ");
            int tipo = int.Parse(Console.ReadLine());
            List = List.FindAll(x => (int)x.TipoFuncionario == tipo);
            ExibirLista();
        }

        // OUTROS
        public static void AdicionarFuncionario()
        {
            Funcionario funcionario = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            funcionario.Nome = Console.ReadLine();
            Console.WriteLine("Digite o salário: ");
            funcionario.Salario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite a data de admissão: ");
            funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(funcionario.Nome)) 
            {
                Console.WriteLine("O nome deve ser preenchido");
                return;
            } else if (funcionario.Salario == 0) {
                Console.WriteLine("Valor do salário não pode ser 0");
                return;
            } else {
                List.Add(funcionario);
                ExibirLista();
            }
        }
        public static void ObterPorId()
        {
            Console.WriteLine("Digite o Id");
            int id = int.Parse(Console.ReadLine());
            Funcionario fBusca = List.Find(x => x.Id == id);

            if (fBusca == null) {
                Console.WriteLine("Não encontrado");
            } else {
                Console.WriteLine($"Funcionario encontrado: {fBusca.Nome}");
            }
        }
        public static void ObterPorSalario()
        {
            Console.WriteLine("Digite o valor mínimo");
            decimal salario = decimal.Parse(Console.ReadLine());
            List = List.FindAll(x => x.Salario >= salario);
            ExibirLista();
        }
        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < List.Count; i++) {
                dados += string.Format("Id: {0} \n", List[i].Id);
                dados += string.Format("Nome: {0} \n", List[i].Nome);
                dados += string.Format("CPF: {0} \n", List[i].Cpf);
                dados += string.Format("Admissao: {0:dd/MM/yyyy} \n", List[i].DataAdmissao);
                dados += string.Format("Salario: {0:c2} \n", List[i].Salario);
                dados += string.Format("Tipo: {0} \n", List[i].TipoFuncionario);
            }
            Console.WriteLine(dados);
        }
        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Cavasoz";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            List.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Kaiser";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            List.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Rin";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            List.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Bachira";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            List.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Isagi";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            List.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Yoruichi";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            List.Add(f6);
        }

        public static void CalcularDescontoINSS() 
        {
            Console.WriteLine("Digite o seu salário: ");
            double salario = double.Parse(Console.ReadLine());
            double desconto;

            if (salario <= 1212.00)
            {
                desconto = salario * 0.075;
            } else if (salario <= 2427.35)
            {
                desconto = salario * 0.09;
            } else if (salario <= 3641.03)
            {
                desconto = salario * 0.12;
            } else if (salario <= 7087.22) 
            {
                desconto = salario * 0.14;
            } else 
            {
                desconto = salario * 0.14;
            }

            double salarioLiquido = salario - desconto;
            Console.WriteLine($"Valor do desconto do INSS: R$ {desconto:F2}");
            Console.WriteLine($"Salário líquido: R$ {salarioLiquido:F2}");
        }

        public static void DetalharData()
        {
            Console.WriteLine("Digite uma data (dd/mm/yyyy): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            string weekDay = data.ToString("dddd");
            string month = data.ToString("MMMM");

            Console.WriteLine($"Dia da semana: {weekDay}");
            Console.WriteLine($"Mês: {month}");

            if (data.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine($"Aproveite seu domingo! Hora atual: {DateTime.Now:HH:mm:ss}");
            }
        }
    }
}