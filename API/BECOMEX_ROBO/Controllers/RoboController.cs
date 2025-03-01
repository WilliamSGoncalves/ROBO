using Microsoft.AspNetCore.Mvc;
using RoboAPI.Models;
using RoboAPI.Services;

namespace RoboAPI.Controllers
{
    [ApiController]
    [Route("api/robo")]
    public class RoboController : ControllerBase
    {
        private readonly RoboService _roboService;

        public RoboController(RoboService roboService)
        {
            _roboService = roboService;
        }

        /// <summary>
        /// Obtém o estado atual do robô.
        /// </summary>
        [HttpGet]
        public ActionResult<Robo> GetEstadoAtual()
        {
            return Ok(_roboService.GetEstadoAtual());
        }

        /// <summary>
        /// Move o cotovelo do robô para um estado específico.
        /// Estados permitidos: 
        /// 1: Repouso, 
        /// 2: Levemente Contraído, 
        /// 3: Contraído, 
        /// 4: Fortemente Contraído.
        /// </summary>
        [HttpPost("mover-cotovelo/{lado}/{estado}")]
        public IActionResult MoverCotovelo(string lado, int estado)
        {
            if (!_roboService.MoverCotovelo(lado, estado))
            {
                return BadRequest("Movimento inválido");
            }

            return Ok(_roboService.GetEstadoAtual());
        }

        /// <summary>
        /// Move o pulso do robô para um estado específico.
        /// Somente permitido se o cotovelo estiver no estado 4 (Fortemente Contraído).
        /// Estados permitidos: 
        /// 1: -90º, 
        /// 2: -45º, 
        /// 3: 0º (Repouso),
        /// 4: 45º, 
        /// 5: 90º, 
        /// 6: 135º, 
        /// 7: 180º.
        /// </summary>
        [HttpPost("mover-pulso/{lado}/{estado}")]
        public IActionResult MoverPulso(string lado, int estado)
        {
            if (!_roboService.MoverPulso(lado, estado))
            {
                return BadRequest("Movimento inválido. Cotovelo deve estar Fortemente Contraído.");
            }

            return Ok(_roboService.GetEstadoAtual());
        }

        /// <summary>
        /// Move o joelho do robô para um estado específico.
        /// Estados permitidos: 
        /// 1: Repouso, 
        /// 2: Levemente Contraído, 
        /// 3: Contraído, 
        /// 4: Fortemente Contraído.
        /// </summary>
        [HttpPost("mover-joelho/{lado}/{estado}")]
        public IActionResult MoverJoelho(string lado, int estado)
        {
            if (!_roboService.MoverJoelho(lado, estado))
            {
                return BadRequest("Movimento inválido");
            }

            return Ok(_roboService.GetEstadoAtual());
        }

        /// <summary>
        /// Move o pé do robô para um estado específico.
        /// Somente permitido se o joelho estiver no estado 1 (Repouso).
        /// Estados permitidos: 
        /// 1: 10º, 
        /// 2: 0º (Repouso),
        /// 3: -45º, 
        /// 4: -90º.
        /// </summary>
        [HttpPost("mover-pe/{lado}/{estado}")]
        public IActionResult MoverPe(string lado, int estado)
        {
            if (!_roboService.MoverPe(lado, estado))
            {
                return BadRequest("Movimento inválido. Joelho deve estar em Repouso.");
            }

            return Ok(_roboService.GetEstadoAtual());
        }

        /// <summary>
        /// Move a rotação da cabeça do robô para um estado específico.
        /// Não permitido se a inclinação da cabeça estiver para baixo.
        /// Estados permitidos:        
        /// 1: -90º, 
        /// 2: -45º, 
        /// 3: 0º (Repouso),
        /// 4: 45º, 
        /// 5: 90º.
        /// </summary>
        [HttpPost("mover-cabeca/rotacao/{estado}")]
        public IActionResult MoverRotacaoCabeca(int estado)
        {
            if (!_roboService.MoverRotacaoCabeca(estado))
            {
                return BadRequest("Movimento inválido. Cabeça não pode estar inclinada para baixo.");
            }

            return Ok(_roboService.GetEstadoAtual());
        }

        /// <summary>
        /// Move a inclinação da cabeça do robô para um estado específico.
        /// Estados permitidos: 
        /// 1: Para Cima, 
        /// 2: Repouso, 
        /// 3: Para Baixo.
        /// </summary>
        [HttpPost("mover-cabeca/inclinacao/{estado}")]
        public IActionResult MoverInclinacaoCabeca(int estado)
        {
            if (!_roboService.MoverInclinacaoCabeca(estado))
            {
                return BadRequest("Movimento inválido");
            }

            return Ok(_roboService.GetEstadoAtual());
        }

        /// <summary>
        /// Retorna todos os movimentos para o estado de repouso.
        /// </summary>
        [HttpGet("resetar")]
        public ActionResult<Robo> ResetarMovimentos()
        {
            _roboService.AlterarEstadoGeralParaReposuo();

            return Ok(_roboService.GetEstadoAtual());
        }
    }
}
