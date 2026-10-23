using System.Xml.Serialization;

namespace RelogioPonto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "Abril 2017.txt";

            List<OcorrenciaPonto> ocorrencias = new List<OcorrenciaPonto>();

            StreamReader file = new StreamReader(filename);

            string linha;

            while ((linha = file.ReadLine()) != null)
            {
                if (linha.Length < 33)
                {
                    Console.WriteLine("Linha inválida: " + linha);
                    continue;
                }

                OcorrenciaPonto ocorrencia =
                    new OcorrenciaPonto(linha);

                ocorrencias.Add(ocorrencia);

                Console.WriteLine("Prontuário: " + ocorrencia.Prontuario);
                Console.WriteLine("Data: " + ocorrencia.Data);
                Console.WriteLine("Hora: " + ocorrencia.Hora);
                Console.WriteLine("Filler: " + ocorrencia.Filler);
                Console.WriteLine("--------------------------");
            }

            file.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(List<OcorrenciaPonto>));

            using (FileStream arquivoXML = new FileStream("ocorrencias.xml", FileMode.Create))
            {
                serializer.Serialize(arquivoXML, ocorrencias);
            }

            Console.WriteLine("Arquivo XML gerado com sucesso!");
            Console.ReadKey();
        }
    }
}
