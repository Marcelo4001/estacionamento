namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            if(veiculos.Count() < 1)
            {
                veiculos.Add("INVALID");
            }
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            placa = this.ValidarPlaca(placa);
            if
            (placa != "INVALID")
            {
                int jaExiste = veiculos.IndexOf(placa);
                if(jaExiste < 0){  
                    //IMPEDINDO QUE O MESMO VEÍCULO OCUPE DUAS VAGAS DO ESTACIONAMENTO              
                    veiculos.Add(placa);
                    int vaga = veiculos.IndexOf(placa);
                    Console.WriteLine($"Veículo de placa {placa} estacionado com sucesso na vaga {vaga}.");
                }
                else
                {
                    Console.WriteLine($"O veículo de placa {placa} já estava estacionado na {jaExiste}ª vaga.");
                    Console.WriteLine("Verifique a placa foi digitada corretamente.");
                }
    
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            this.ListarVeiculos();

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = "";
            placa = Console.ReadLine();
            placa = ValidarPlaca(placa);

            string padraoNumerico = "[0-9]+";

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string strHoras = Console.ReadLine();

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = 0;
                decimal valorTotal = 0; 
                if
                (System.Text.RegularExpressions.Regex.IsMatch(strHoras, padraoNumerico))
                {
                    //SE ENTRADA DO USUÁRIO FOR UM NÚMERO VÁLIDO
                    horas = int.Parse(strHoras);
                }

                valorTotal = this.precoPorHora * horas + this.precoInicial;
                


                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                for
                (int contador = 1; contador < veiculos.Count(); contador++)
                {
                    Console.WriteLine($"{contador} - {veiculos[contador]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public string ValidarPlaca(string placaEntrada)
        {
            //VERIFICA SE A PLACA É VÁLIDA E PADRONIZA NO FORMATO ABC-1234
            string placaSaida = "INVALID";

            /*
                O padrão define a busca por uma string contendo:
                três letras maiúsculas
                seguidas, OU NÃO, por um espaço ou hífem
                e, por fim 4 dígitos, sendo o primeiro diferente de zero
            */
            string padrao = "[A-Z]{3}[\\-|\\s]?[1-9][0-9]{3}";
            string padraoNumerico = "[1-9][0-9]*";

            placaEntrada = placaEntrada.Trim().ToUpper();

            if
            (System.Text.RegularExpressions.Regex.IsMatch(placaEntrada, padrao))
            {
                placaSaida = placaEntrada.Replace(" ", "-");
                if
                (placaSaida.IndexOf("-") < 0)
                {
                    placaSaida = placaSaida.Insert(3, "-");
                }
            }
            else if
            (System.Text.RegularExpressions.Regex.IsMatch(placaEntrada, padraoNumerico))
            {
                //SE A ENTRADA É UM NÚMERO VÁLIDO, CONVERTA PARA int
                int indexPlaca = int.Parse(placaEntrada);
                //SE indexPlaca CONSTA EM veiculos, PEGA O SEU VALOR E JOGA EM placa
                if(indexPlaca < veiculos.Count())
                {
                    placaSaida = veiculos[indexPlaca];
                }
            }
            else
            {
                Console.WriteLine($"A placa digitada ({placaEntrada}) não é válida.");
                Console.WriteLine("Digite apenas 3 letras, um espaço ou um hífen e 4 dígitos.");
                Console.WriteLine("Ou digite somente três letras seguidas de 4 dígitos, sem qualquer outro tipo de carácter entre os dois grupos.");
            }

            return placaSaida;
        }
    }
}
