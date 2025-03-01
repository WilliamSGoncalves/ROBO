namespace RoboAPI.Models
{
    public class Robo
    {
        public int CotoveloEsquerdo { get; private set; } = 1;
        public int PulsoEsquerdo { get; private set; } = 3;
        public int CotoveloDireito { get; private set; } = 1;
        public int PulsoDireito { get; private set; } = 3;        
        public int JoelhoEsquerdo { get; private set; } = 1;
        public int PeEsquerdo { get; private set; } = 2;
        public int JoelhoDireito { get; private set; } = 1;
        public int PeDireito { get; private set; } = 2;
        public int RotacaoCabeca { get; private set; } = 3;
        public int InclinacaoCabeca { get; private set; } = 2;

        public void AlterarEstadoCotoveloEsquerdo(int estado) => CotoveloEsquerdo = estado;
        public void AlterarEstadoPulsoEsquerdo(int estado) => PulsoEsquerdo = estado;
        public void AlterarEstadoCotoveloDireito(int estado) => CotoveloDireito = estado;
        public void AlterarEstadoPulsoDireito(int estado) => PulsoDireito = estado;        
        public void AlterarEstadoJoelhoEsquerdo(int estado) => JoelhoEsquerdo = estado;
        public void AlterarEstadoPeEsquerdo(int estado) => PeEsquerdo = estado;
        public void AlterarEstadoJoelhoDireito(int estado) => JoelhoDireito = estado;
        public void AlterarEstadoPeDireito(int estado) => PeDireito = estado;
        public void AlterarEstadoRotacaoCabeca(int estado) => RotacaoCabeca = estado;
        public void AlterarEstadoInclinacaoCabeca(int estado) => InclinacaoCabeca = estado;
        public void AlterarEstadoGeralParaReposuo()
        {
            CotoveloEsquerdo = 1;
            PulsoEsquerdo = 3;
            CotoveloDireito = 1;
            PulsoDireito = 3;
            JoelhoEsquerdo = 1;
            PeEsquerdo = 2;
            JoelhoDireito = 1;
            PeDireito = 2;
            RotacaoCabeca = 3;
            InclinacaoCabeca = 2;
        }
    }
}