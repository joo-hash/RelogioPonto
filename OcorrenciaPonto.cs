namespace RelogioPonto
{
    public class OcorrenciaPonto
    {
        public string Prontuario { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Filler { get; set; }

        public OcorrenciaPonto()
        {
        }

        public OcorrenciaPonto(string linha)
        {
            Prontuario = linha.Substring(0, 15);
            Data = linha.Substring(15, 6);
            Hora = linha.Substring(21, 4);
            Filler = linha.Substring(25, 8);
        }
    }
}
