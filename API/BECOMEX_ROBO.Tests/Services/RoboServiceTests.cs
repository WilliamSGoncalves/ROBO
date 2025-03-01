using RoboAPI.Services;

namespace RoboAPI.Tests.Services
{
    public class RoboServiceTests
    {
        private readonly RoboService _roboService;

        public RoboServiceTests()
        {
            _roboService = new RoboService();
        }

        [Fact]
        public void MoverCotovelo_Valido_DeveRetornarTrue()
        {
            Assert.True(_roboService.MoverCotovelo("esquerdo", 2));
            Assert.Equal(2, _roboService.GetEstadoAtual().CotoveloEsquerdo);
        }

        [Fact]
        public void MoverCotovelo_PulandoEstado_DeveRetornarFalse()
        {
            Assert.False(_roboService.MoverCotovelo("esquerdo", 4));
        }

        [Fact]
        public void MoverCotovelo_Invalido_DeveRetornarFalse()
        {
            Assert.False(_roboService.MoverCotovelo("esquerdo", 5));
        }

        [Fact]
        public void MoverPulso_SemCotoveloContraido_DeveRetornarFalse()
        {
            Assert.False(_roboService.MoverPulso("esquerdo", 5));
        }

        [Fact]
        public void MoverPulso_ComCotoveloContraido_DeveRetornarTrue()
        {
            Assert.True(_roboService.MoverCotovelo("esquerdo", 2));
            Assert.True(_roboService.MoverCotovelo("esquerdo", 3));
            Assert.True(_roboService.MoverCotovelo("esquerdo", 4));
            Assert.True(_roboService.MoverPulso("esquerdo", 4));
            Assert.True(_roboService.MoverPulso("esquerdo", 5));

            Assert.Equal(5, _roboService.GetEstadoAtual().PulsoEsquerdo);
        }

        [Fact]
        public void MoverJoelho_Valido_DeveRetornarTrue()
        {
            Assert.True(_roboService.MoverJoelho("esquerdo", 2));
            Assert.Equal(2, _roboService.GetEstadoAtual().JoelhoEsquerdo);
        }

        [Fact]
        public void MoverJoelho_PulandoEstado_DeveRetornarFalse()
        {
            Assert.False(_roboService.MoverJoelho("esquerdo", 4));
        }

        [Fact]
        public void MoverJoelho_Invalido_DeveRetornarFalse()
        {
            Assert.False(_roboService.MoverJoelho("esquerdo", 5));
        }

        [Fact]
        public void MoverPe_SemJoelhoEmRepouso_DeveRetornarFalse()
        {
            Assert.True(_roboService.MoverJoelho("esquerdo", 2));
            Assert.False(_roboService.MoverPe("esquerdo", 4));
        }

        [Fact]
        public void MoverPe_ComJoelhoEmRepouso_DeveRetornarTrue()
        {
            Assert.True(_roboService.MoverPe("esquerdo", 3));
            Assert.True(_roboService.MoverPe("esquerdo", 4));

            Assert.Equal(4, _roboService.GetEstadoAtual().PeEsquerdo);
        }

        [Fact]
        public void MoverRotacaoCabeca_Invalido_DeveRetornarFalse()
        {
            Assert.True(_roboService.MoverInclinacaoCabeca(3));
            Assert.False(_roboService.MoverRotacaoCabeca(2));
        }

        [Fact]
        public void MoverRotacaoCabeca_Valido_DeveRetornarTrue()
        {
            Assert.True(_roboService.MoverRotacaoCabeca(2));
            Assert.Equal(2, _roboService.GetEstadoAtual().RotacaoCabeca);
        }

        [Fact]
        public void MoverInclinacaoCabeca_Valido_DeveRetornarTrue()
        {
            Assert.True(_roboService.MoverInclinacaoCabeca(1));
            Assert.Equal(1, _roboService.GetEstadoAtual().InclinacaoCabeca);
        }

        [Fact]
        public void MoverInclinacaoCabeca_Invalido_DeveRetornarFalse()
        {
            Assert.False(_roboService.MoverInclinacaoCabeca(5));
        }

        [Fact]
        public void ResetarMovimentos_Valido_DeveRetornarTrue()
        {
            Assert.True(_roboService.MoverCotovelo("esquerdo", 2));
            Assert.True(_roboService.MoverCotovelo("esquerdo", 3));
            Assert.True(_roboService.MoverCotovelo("esquerdo", 4));
            Assert.True(_roboService.MoverPulso("esquerdo", 4));
            Assert.True(_roboService.MoverPulso("esquerdo", 5));            
            
            Assert.True(_roboService.MoverCotovelo("direito", 2));
            Assert.True(_roboService.MoverCotovelo("direito", 3));
            Assert.True(_roboService.MoverCotovelo("direito", 4));
            Assert.True(_roboService.MoverPulso("direito", 4));
            Assert.True(_roboService.MoverPulso("direito", 5));            
            
            Assert.True(_roboService.MoverJoelho("esquerdo", 2));
            Assert.True(_roboService.MoverJoelho("esquerdo", 3));
            Assert.True(_roboService.MoverJoelho("esquerdo", 4));
            Assert.True(_roboService.MoverJoelho("esquerdo", 3));
            Assert.True(_roboService.MoverJoelho("esquerdo", 2));
            Assert.True(_roboService.MoverJoelho("esquerdo", 1));
            Assert.True(_roboService.MoverPe("esquerdo", 3));
            Assert.True(_roboService.MoverPe("esquerdo", 4));            
            
            Assert.True(_roboService.MoverJoelho("direito", 2));
            Assert.True(_roboService.MoverJoelho("direito", 3));
            Assert.True(_roboService.MoverJoelho("direito", 4));
            Assert.True(_roboService.MoverJoelho("direito", 3));
            Assert.True(_roboService.MoverJoelho("direito", 2));
            Assert.True(_roboService.MoverJoelho("direito", 1));
            Assert.True(_roboService.MoverPe("direito", 3));
            Assert.True(_roboService.MoverPe("direito", 4));

            Assert.True(_roboService.MoverInclinacaoCabeca(1));
            Assert.True(_roboService.MoverRotacaoCabeca(2));

            _roboService.AlterarEstadoGeralParaReposuo();

            Assert.Equal(1, _roboService.GetEstadoAtual().CotoveloEsquerdo);
            Assert.Equal(3, _roboService.GetEstadoAtual().PulsoEsquerdo);
            Assert.Equal(1, _roboService.GetEstadoAtual().CotoveloDireito);
            Assert.Equal(3, _roboService.GetEstadoAtual().PulsoDireito);
            Assert.Equal(2, _roboService.GetEstadoAtual().InclinacaoCabeca);
            Assert.Equal(3, _roboService.GetEstadoAtual().RotacaoCabeca);
        }
    }
}
