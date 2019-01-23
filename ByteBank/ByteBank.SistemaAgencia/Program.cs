using Bytebank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 1),
                new ContaCorrente(342, 999),
                null,
                new ContaCorrente(340, 4),
                new ContaCorrente(340, 456),
                new ContaCorrente(340, 10),
                null,
                null,
                new ContaCorrente(290, 123)
            };

            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }

            Console.ReadLine();

        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

        static void TestaDataHumanize()
        {
            // Dia 17 de Agosto de 2018
            DateTime dataFimPagamento = new DateTime(2018, 8, 17);
            // Data corrente no momento de execução do código
            DateTime dataCorrente = DateTime.Now;
            TimeSpan diferenca = dataFimPagamento - dataCorrente;

            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);
            Console.ReadLine();
        }

        static void TestaArraydeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(3032, 346458),
                new ContaCorrente(3562, 256845),
                new ContaCorrente(0587, 451258)
            };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                Console.WriteLine($"Conta {indice} {contas[indice].Numero}");
            }

            Console.ReadLine();
        }

        public void TestaStringERegex()
        {
            {
                // Olá, meu nome é Ricardo e você pode entrar em contato comigo
                // através do número 8457-4456!

                // Meu nome é Ricardo, me ligue em 4784-4546

                //  "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
                //  "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
                //  "[0-9]{4,5}[-][0-9]{4}";
                //  "[0-9]{4,5}[-]{0,1}[0-9]{4}";
                //  "[0-9]{4,5}-{0,1}[0-9]{4}";
                string padrao = "[0-9]{4,5}-?[0-9]{4}";

                // 879.546.120-20
                // 879546120-20

                string textoDeTeste = "idyufdgfugfjksdhf 99871--5456 sdjkfgsdjgsjgh sfsdjgsdjghsdfj";

                Match resultado = Regex.Match(textoDeTeste, padrao);

                Console.WriteLine(resultado.Value);
                Console.ReadLine();



                string urlTeste = "https://www.bytebank.com/cambio";
                int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");


                Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
                Console.WriteLine(urlTeste.EndsWith("cambio/"));


                Console.WriteLine(urlTeste.Contains("ByteBank"));


                Console.ReadLine();

                // pagina?argumentos
                // 012345678



                //moedaOrigem=real&moedaDestino=dolar
                //          |
                //  -------´

                string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
                ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(urlParametros);

                string valor = extratorDeValores.GetValor("moedaDestino");
                Console.WriteLine("Valor de moedaDestino: " + valor);

                string valorMoedaOrigem = extratorDeValores.GetValor("moedaOrigem");
                Console.WriteLine("Valor de moedaOrigem: " + valorMoedaOrigem);

                Console.WriteLine(extratorDeValores.GetValor("VALOR"));

                Console.ReadLine();



                //Testando ToLower
                string mensagemOrigem = "PALAVRA";
                string termoBusca = "ra";

                Console.WriteLine(mensagemOrigem.ToLower());


                // Testando Replace
                termoBusca = termoBusca.Replace('r', 'R');
                Console.WriteLine(termoBusca);

                termoBusca = termoBusca.Replace('a', 'A');
                Console.WriteLine(termoBusca);

                Console.WriteLine(mensagemOrigem.IndexOf(termoBusca));
                Console.ReadLine();

                // Testando o método Remove
                string testeRemocao = "primeiraParte&123456789";
                int indiceEComercial = testeRemocao.IndexOf('&');
                Console.WriteLine(testeRemocao.Remove(indiceEComercial, 4));
                Console.ReadLine();


                // <nome>=<valor>
                string palavra = "moedaOrigem=moedaDestino&moedaDestino=dolar";
                string nomeArgumento = "moedaDestino=";

                int indice = palavra.IndexOf(nomeArgumento);
                Console.WriteLine(indice);

                Console.WriteLine("Tamanho da string nomeArgumento: " + nomeArgumento.Length);

                Console.WriteLine(palavra);
                Console.WriteLine(palavra.Substring(indice));
                Console.WriteLine(palavra.Substring(indice + nomeArgumento.Length));
                Console.ReadLine();





                // Testando o IsNullOrEmpty
                string textoVazio = "";
                string textoNulo = null;
                string textoQualquer = "kjhfsdjhgsdfjksdf";
                Console.WriteLine(String.IsNullOrEmpty(textoVazio));
                Console.WriteLine(String.IsNullOrEmpty(textoNulo));
                Console.WriteLine(String.IsNullOrEmpty(textoQualquer));
                Console.ReadLine();

                ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL("");

                string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

                int indiceInterrogacao = url.IndexOf('?');

                Console.WriteLine(indiceInterrogacao);

                Console.WriteLine(url);
                string argumentos = url.Substring(indiceInterrogacao + 1);
                Console.WriteLine(argumentos);
            }
        }
    }
}
