using RoboAPI.Models;

namespace RoboAPI.Services
{
    public class RoboService
    {
        private Robo _robo;

        public RoboService()
        {
            _robo = new Robo();
        }

        public Robo GetEstadoAtual() => _robo;

        public bool MoverCotovelo(string lado, int estado)
        {
            if (estado < 1 || estado > 4)
            {
                return false;
            }

            if (lado.ToLower() == "esquerdo")
            {
                if (Math.Abs(_robo.CotoveloEsquerdo - estado) != 1)
                {
                    return false;
                }

                _robo.AlterarEstadoCotoveloEsquerdo(estado);
            }
            else if (lado.ToLower() == "direito")
            {
                if (Math.Abs(_robo.CotoveloDireito - estado) != 1)
                {
                    return false;
                }

                _robo.AlterarEstadoCotoveloDireito(estado);
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool MoverPulso(string lado, int estado)
        {
            if (estado < 1 || estado > 7)
            {
                return false;
            }

            if ((lado.ToLower() == "esquerdo" && _robo.CotoveloEsquerdo == 4) ||
                (lado.ToLower() == "direito" && _robo.CotoveloDireito == 4))
            {
                if (lado.ToLower() == "esquerdo")
                {
                    _robo.AlterarEstadoPulsoEsquerdo(estado);
                }
                else
                {
                    _robo.AlterarEstadoPulsoDireito(estado);
                }

                return true;
            }

            return false;
        }        
        
        public bool MoverJoelho(string lado, int estado)
        {
            if (estado < 1 || estado > 4)
            {
                return false;
            }

            if (lado.ToLower() == "esquerdo")
            {
                if (Math.Abs(_robo.JoelhoEsquerdo - estado) != 1)
                {
                    return false;
                }

                _robo.AlterarEstadoJoelhoEsquerdo(estado);
            }
            else if (lado.ToLower() == "direito")
            {
                if (Math.Abs(_robo.JoelhoDireito - estado) != 1)
                {
                    return false;
                }

                _robo.AlterarEstadoJoelhoDireito(estado);
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool MoverPe(string lado, int estado)
        {
            if (estado < 1 || estado > 4)
            {
                return false;
            }

            if ((lado.ToLower() == "esquerdo" && _robo.JoelhoEsquerdo == 1) ||
                (lado.ToLower() == "direito" && _robo.JoelhoDireito == 1))
            {
                if (lado.ToLower() == "esquerdo")
                {
                    _robo.AlterarEstadoPeEsquerdo(estado);
                }
                else
                {
                    _robo.AlterarEstadoPeDireito(estado);
                }

                return true;
            }

            return false;
        }

        public bool MoverRotacaoCabeca(int estado)
        {
            if (estado < 1 || estado > 5)
            {
                return false;
            }

            if (_robo.InclinacaoCabeca != 3)
            {
                _robo.AlterarEstadoRotacaoCabeca(estado);
                return true;
            }

            return false;
        }

        public bool MoverInclinacaoCabeca(int estado)
        {
            if (estado < 1 || estado > 3)
            {
                return false;
            }

            if (Math.Abs(_robo.InclinacaoCabeca - estado) != 1)
            {
                return false;
            }

            _robo.AlterarEstadoInclinacaoCabeca(estado);

            return true;
        }

        public void AlterarEstadoGeralParaReposuo()
        {
            _robo.AlterarEstadoGeralParaReposuo();
        }
    }
}
