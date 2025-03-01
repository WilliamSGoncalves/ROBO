const API_BASE = "/api/robo";

async function fetchHandling(url, options) {
  const response = await fetch(url, options);
  const data = await response.json();
  return data;
}

export async function fetchRoboState() {
  return fetchHandling(API_BASE);
}

export async function moverCotovelo(lado, estado) {
  return fetchHandling(`${API_BASE}/mover-cotovelo/${lado}/${estado}`, {
    method: "POST",
  });
}

export async function moverPulso(lado, estado) {
  return fetchHandling(`${API_BASE}/mover-pulso/${lado}/${estado}`, {
    method: "POST",
  });
}

export async function moverJoelho(lado, estado) {
  return fetchHandling(`${API_BASE}/mover-joelho/${lado}/${estado}`, {
    method: "POST",
  });
}

export async function moverPe(lado, estado) {
  return fetchHandling(`${API_BASE}/mover-pe/${lado}/${estado}`, {
    method: "POST",
  });
}
export async function moverRotacaoCabeca(estado) {
  return fetchHandling(`${API_BASE}/mover-cabeca/rotacao/${estado}`, {
    method: "POST",
  });
}

export async function moverInclinacaoCabeca(estado) {
  return fetchHandling(`${API_BASE}/mover-cabeca/inclinacao/${estado}`, {
    method: "POST",
  });
}
