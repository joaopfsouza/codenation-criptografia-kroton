namespace AnswerCodenation
{
    class Answer
    {

        public int numero_casas { get; set; }
        public string token { get; set; }
        public string cifrado { get; set; }
        public string decifrado { get; set; }
        public string resumo_criptografico { get; set; }



        public override string ToString()
        {
            return $"Numero de casas: {numero_casas}\nToken: {token}\nCifrado: {cifrado}\nDecifrado: {decifrado}\nResumo:{resumo_criptografico}";

        }

    }


}
