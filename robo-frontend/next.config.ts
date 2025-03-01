/** @type {import('next').NextConfig} */
const nextConfig = {
  async rewrites() {
    return [
      {
        source: "/api/:path*",
        destination: "http://localhost:5235/api/:path*",
      },
    ];
  },
};

module.exports = nextConfig;
