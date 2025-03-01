"use client";

import { useEffect, useState } from "react";
import { fetchRoboState, moverCotovelo, moverPulso, moverJoelho, moverPe, moverRotacaoCabeca, moverInclinacaoCabeca } from "../services/api";

interface RoboState {
  cotoveloEsquerdo: number;
  cotoveloDireito: number;
  pulsoEsquerdo: number;
  pulsoDireito: number;
  joelhoEsquerdo: number;
  joelhoDireito: number;
  peEsquerdo: number;
  peDireito: number;
  rotacaoCabeca: number;
  inclinacaoCabeca: number;
}

export default function RoboApp() {
  const [robo, setRobo] = useState<RoboState | null>(null);

  useEffect(() => {
    async function fetchData() {
      try {
        const data = await fetchRoboState();
        setRobo(data);
      } catch (error) {
        console.error(error);
      }
    }
    fetchData();
  }, []);

  return (
    <div className="p-4 text-center border-4 border-gray-800 rounded-lg max-w mx-auto bg-gray-200 shadow-xl min-h-screen flex flex-col justify-center">
      <h1 className="text-3xl font-bold mb-4 text-gray-900">R.O.B.O</h1>
      <div className="grid grid-cols-2 gap-2 text-left bg-white p-3 rounded-lg shadow-md mb-4 text-sm">
        <div>
          <h2 className="text-lg font-semibold mb-1">Regras de Movimento</h2>
          <li><strong>Cabeça</strong></li>
          <ul className="pl-4">
            <li>Rotação: 1. -90º, 2. -45º, 3. Repouso, 4. 45º, 5. 90º</li>
            <li>Inclinação: 1. Para Cima, 2. Repouso, 3. Para Baixo</li>
          </ul>
          <li><strong>Braços</strong></li>
          <ul className="pl-4">
            <li>Cotovelo: 1. Repouso, 2. Levemente Contraído, 3. Contraído, 4. Fortemente Contraído</li>
            <li>Pulso: 1. -90º, 2. -45º, 3. Repouso, 4. 45º, 5. 90º, 6. 135º, 7. 180º</li>
          </ul>
          <li><strong>Pernas</strong></li>
          <ul className="pl-4">
            <li>Joelho: 1. Repouso, 2. Levemente Contraído, 3. Contraído, 4. Fortemente Contraído</li>
            <li>Pé: 1. 10º, 2. 0º Repouso, 3. 45º, 4. 90º</li>
          </ul>
        </div>
        <div>
          <h2 className="text-lg font-semibold mb-1">Regras de Negócio</h2>
          <ul className="list-disc pl-4">
            <li>O estado inicial dos movimentos é Em Repouso.</li>
            <li>Só poderá movimentar o Pulso caso o Cotovelo esteja Fortemente Contraído.</li>
            <li>Só poderá movimentar o Pé caso o Joelho esteja em Repouso.</li>
            <li>Só poderá Rotacionar a Cabeça caso sua Inclinação da Cabeça não esteja em estado Para Baixo.</li>
            <li>Ao realizar a progressão de estados, é necessário que sempre siga a ordem crescente ou decrescente, sem pular estados.</li>
            <li>Atenção aos limites! Se tentar enviar um estado inválido você irá corromper o sistema do R.O.B.O.</li>
          </ul>
        </div>
      </div>
      {robo ? (
        <div className="grid grid-cols-5 gap-6">
          <div className="border p-4 rounded-lg shadow bg-white flex flex-col items-center">
            <h2 className="text-xl font-semibold mb-2">Cabeça</h2>
            <p className="font-medium">Rotação: {robo.rotacaoCabeca}</p>
            <div className="flex gap-2 mt-2">
              <button onClick={async () => setRobo(await moverRotacaoCabeca(robo.rotacaoCabeca - 1))} className="px-4 py-1 bg-red-500 text-white rounded-lg shadow hover:bg-red-600">-</button>
              <button onClick={async () => setRobo(await moverRotacaoCabeca(robo.rotacaoCabeca + 1))} className="px-4 py-1 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600">+</button>
            </div>
            <p className="font-medium mt-4">Inclinação: {robo.inclinacaoCabeca}</p>
            <div className="flex gap-2 mt-2">
              <button onClick={async () => setRobo(await moverInclinacaoCabeca(robo.inclinacaoCabeca - 1))} className="px-4 py-1 bg-red-500 text-white rounded-lg shadow hover:bg-red-600">-</button>
              <button onClick={async () => setRobo(await moverInclinacaoCabeca(robo.inclinacaoCabeca + 1))} className="px-4 py-1 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600">+</button>
            </div>
          </div>
          <div className="border p-4 rounded-lg shadow bg-white flex flex-col items-center">
            <h2 className="text-xl font-semibold mb-2">Braço Esquerdo</h2>
            <p className="font-medium">Cotovelo: {robo.cotoveloEsquerdo}</p>
            <div className="flex gap-2 mt-2">
              <button onClick={async () => setRobo(await moverCotovelo('esquerdo', robo.cotoveloEsquerdo - 1))} className="px-4 py-1 bg-red-500 text-white rounded-lg shadow hover:bg-red-600">-</button>
              <button onClick={async () => setRobo(await moverCotovelo('esquerdo', robo.cotoveloEsquerdo + 1))} className="px-4 py-1 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600">+</button>
            </div>
            <p className="font-medium mt-4">Pulso: {robo.pulsoEsquerdo}</p>
            <div className="flex gap-2 mt-2">
              <button onClick={async () => setRobo(await moverPulso('esquerdo', robo.pulsoEsquerdo - 1))} className="px-4 py-1 bg-red-500 text-white rounded-lg shadow hover:bg-red-600">-</button>
              <button onClick={async () => setRobo(await moverPulso('esquerdo', robo.pulsoEsquerdo + 1))} className="px-4 py-1 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600">+</button>
            </div>
          </div>
          <div className="border p-4 rounded-lg shadow bg-white flex flex-col items-center">
            <h2 className="text-xl font-semibold mb-2">Braço Direito</h2>
            <p className="font-medium">Cotovelo: {robo.cotoveloDireito}</p>
            <div className="flex gap-2 mt-2">
              <button onClick={async () => setRobo(await moverCotovelo('direito', robo.cotoveloDireito - 1))} className="px-4 py-1 bg-red-500 text-white rounded-lg shadow hover:bg-red-600">-</button>
              <button onClick={async () => setRobo(await moverCotovelo('direito', robo.cotoveloDireito + 1))} className="px-4 py-1 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600">+</button>
            </div>
            <p className="font-medium mt-4">Pulso: {robo.pulsoDireito}</p>
            <div className="flex gap-2 mt-2">
              <button onClick={async () => setRobo(await moverPulso('direito', robo.pulsoDireito - 1))} className="px-4 py-1 bg-red-500 text-white rounded-lg shadow hover:bg-red-600">-</button>
              <button onClick={async () => setRobo(await moverPulso('direito', robo.pulsoDireito + 1))} className="px-4 py-1 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600">+</button>
            </div>
          </div>

          <div className="border p-4 rounded-lg shadow bg-white flex flex-col items-center">
            <h2 className="text-xl font-semibold mb-2">Perna Esquerda</h2>
            <p className="font-medium">Joelho: {robo.joelhoEsquerdo}</p>
            <div className="flex gap-2 mt-2">
              <button onClick={async () => setRobo(await moverJoelho('esquerdo', robo.joelhoEsquerdo - 1))} className="px-4 py-1 bg-red-500 text-white rounded-lg shadow hover:bg-red-600">-</button>
              <button onClick={async () => setRobo(await moverJoelho('esquerdo', robo.joelhoEsquerdo + 1))} className="px-4 py-1 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600">+</button>
            </div>
            <p className="font-medium mt-4">Pé: {robo.peEsquerdo}</p>
            <div className="flex gap-2 mt-2">
              <button onClick={async () => setRobo(await moverPe('esquerdo', robo.peEsquerdo - 1))} className="px-4 py-1 bg-red-500 text-white rounded-lg shadow hover:bg-red-600">-</button>
              <button onClick={async () => setRobo(await moverPe('esquerdo', robo.peEsquerdo + 1))} className="px-4 py-1 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600">+</button>
            </div>
          </div>
          <div className="border p-4 rounded-lg shadow bg-white flex flex-col items-center">
            <h2 className="text-xl font-semibold mb-2">Perna Direita</h2>
            <p className="font-medium">Joelho: {robo.joelhoDireito}</p>
            <div className="flex gap-2 mt-2">
              <button onClick={async () => setRobo(await moverJoelho('direito', robo.joelhoDireito - 1))} className="px-4 py-1 bg-red-500 text-white rounded-lg shadow hover:bg-red-600">-</button>
              <button onClick={async () => setRobo(await moverJoelho('direito', robo.joelhoDireito + 1))} className="px-4 py-1 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600">+</button>
            </div>
            <p className="font-medium mt-4">Pé: {robo.peDireito}</p>
            <div className="flex gap-2 mt-2">
              <button onClick={async () => setRobo(await moverPe('direito', robo.peDireito - 1))} className="px-4 py-1 bg-red-500 text-white rounded-lg shadow hover:bg-red-600">-</button>
              <button onClick={async () => setRobo(await moverPe('direito', robo.peDireito + 1))} className="px-4 py-1 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600">+</button>
            </div>
          </div>
        </div>
      ) : (
        <p className="text-lg font-semibold text-gray-700">Carregando...</p>
      )}
    </div>
  );
}